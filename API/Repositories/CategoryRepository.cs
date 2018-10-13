using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Interfaces;
using API.Models;
using API.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IFieldRepository fieldRepository;
        public CategoryRepository(DataContext context, IMapper mapper, IFieldRepository fieldRepository)
        {
            this.fieldRepository = fieldRepository;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await context.Categories
                .Include(c => c.Products)
                .Include(c => c.AdditionalFields)
                .SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await context.Categories
                .Include(c => c.Products)
                .Include(c => c.AdditionalFields)
                .ToListAsync();

            return categories;
        }

        public async Task<Category> CreateCategory(PostCategoryDto dto)
        {
            var category = mapper.Map<PostCategoryDto, Category>(dto);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            await fieldRepository.AddOrUpdateFields(category, dto.AdditionalFields);

            return category;
        }

        public async Task<bool> UpdateCategory(int id, PostCategoryDto dto)
        {
            var category = await GetCategory(id);
            if (category == null)
                throw new Exception("Category does not exist.");

            mapper.Map<PostCategoryDto, Category>(dto, category);

            var response = await fieldRepository.AddOrUpdateFields(category, dto.AdditionalFields);

            return response;
        }

        public async Task<bool> DeleteCategory(int id, bool deleteRelatedProducts)
        {
            var category = await GetCategory(id);
            if (category == null)
                throw new Exception("Category does not exist.");

            if (deleteRelatedProducts)
                context.Products.RemoveRange(category.Products);

            context.Categories.Remove(category);

            return await context.SaveChangesAsync() > 0;
        }

    }
}