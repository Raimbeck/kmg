using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.POST;
using API.Interfaces;
using API.Models;
using API.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class FIeldValueRepository: IFieldValueRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public FIeldValueRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> AddOrUpdateValues(int productId, List<PostFieldDto> fieldsDto)
        {
            var activeValuesId = new List<int>();

            for(int i = 0; i < fieldsDto.Count; i ++)
            {
                //Add new fields or update existing.
                var fieldValue = await GetFieldValueById(productId, fieldsDto[i].FieldValue.Id);
                if(fieldValue == null)
                {
                    fieldValue = mapper.Map<FieldValueDto, FieldValue>(fieldsDto[i].FieldValue);
                    fieldValue.ProductId = productId;
                    fieldValue.FieldId = fieldsDto[i].Id;
                    await context.FieldValues.AddAsync(fieldValue);
                }
                else 
                {
                    mapper.Map<FieldValueDto, FieldValue>(fieldsDto[i].FieldValue, fieldValue);
                    activeValuesId.Add(fieldValue.Id);
                }
            }

            var productFields = await GetFieldValues(productId);
            var inactiveProductFields = productFields.Where(pf => !activeValuesId.Contains(pf.Id)).ToList();

            context.FieldValues.RemoveRange(inactiveProductFields);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<FieldValue> GetFieldValueById(int productId, int id)
        {
            return await context.FieldValues.SingleOrDefaultAsync(fv => fv.ProductId == productId && fv.Id == id); 
        }

        public async Task<IEnumerable<FieldValue>> GetFieldValues(int productId, List<int> ids = null)
        {
            return ids != null
                ? await context.FieldValues.Where(fv => fv.ProductId == productId && ids.Contains(fv.Id)).ToListAsync()
                : await context.FieldValues.Where(fv => fv.ProductId == productId).ToListAsync();
        }
    }
}