using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.POST;
using API.Interfaces;
using API.Models;
using API.Persistence;
using AutoMapper;

namespace API.Repositories
{
    public class FIeldRepository: IFieldRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public FIeldRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> AddOrUpdateFields(Category category, List<PostFieldDto> fieldsDto)
        {
            foreach(var fieldDto in fieldsDto) 
            {
                if(fieldDto.Id == 0) 
                {
                    var field = mapper.Map<PostFieldDto, Field>(fieldDto);
                    category.AdditionalFields.Add(field);
                }
                    
                else 
                {
                    var field = category.AdditionalFields.SingleOrDefault(af => af.Id == fieldDto.Id);
                    mapper.Map<PostFieldDto, Field>(fieldDto, field);
                }
            }    

            var fieldsToRemove = category.AdditionalFields.Where(af => !fieldsDto.Any(fd => fd.Id == af.Id)).ToList();
            context.Fields.RemoveRange(fieldsToRemove);   
            
            return await context.SaveChangesAsync() > 0;
        }
    }
}