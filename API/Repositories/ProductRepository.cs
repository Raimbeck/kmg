using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Interfaces;
using API.Models;
using API.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IFieldValueRepository valueRepository;
        public ProductRepository(DataContext context, IMapper mapper, IFieldValueRepository valueRepository)
        {
            this.valueRepository = valueRepository;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.AdditionalFields)
                .SingleOrDefaultAsync(p => p.Id == id);
                
            return product;
        }

        public async Task<GetProductDto> GetProductDto(int id)
        {
            var product = await GetProduct(id);

            var productDto = mapper.Map<Product, GetProductDto>(product);

            if(productDto.Category != null) {
                var fieldValues = await valueRepository.GetFieldValues(id);
                foreach(var field in productDto.Category.AdditionalFields)
                {
                    var fieldValue = fieldValues.SingleOrDefault(fv => fv.FieldId == field.Id);
                    field.FieldValue = fieldValue != null
                        ? mapper.Map<FieldValue, FieldValueDto>(fieldValue)
                        : new FieldValueDto();
                }
            }
                
            return productDto;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await context.Products
                .Include(c => c.Category)
                .ThenInclude(c => c.AdditionalFields)
                .ToListAsync();

            return products;
        }

        public async Task<Product> CreateProduct(PostProductDto dto)
        {
            var product = mapper.Map<PostProductDto, Product>(dto);

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            await valueRepository.AddOrUpdateValues(product.Id, dto.Category.AdditionalFields);

            return product;
        }

        public async Task<bool> UpdateProduct(int id, PostProductDto dto)
        {
            var product = await GetProduct(id);
            if (product == null)
                throw new Exception("Product does not exist.");

            mapper.Map<PostProductDto, Product>(dto, product);

            if(dto.Category != null)
                return await valueRepository.AddOrUpdateValues(product.Id, dto.Category.AdditionalFields);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProduct(id);
            if (product == null)
                throw new Exception("Product does not exist.");

            var fieldValues = await valueRepository.GetFieldValues(product.Id);

            context.FieldValues.RemoveRange(fieldValues);
            context.Products.Remove(product);

            return await context.SaveChangesAsync() > 0;
        }
    }
}