using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories() 
        {
            var categories = await repository.GetCategories();
            var categoriesDto = mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await repository.GetCategory(id);
            var categoryDto = mapper.Map<Category, GetCategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]PostCategoryDto categoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await repository.CreateCategory(categoryDto);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody]PostCategoryDto categoryDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await repository.UpdateCategory(id, categoryDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, [FromQuery]bool deleteRelatedProducts = false) 
        {
            var response = await repository.DeleteCategory(id, deleteRelatedProducts);
            return Ok(response);
        }
    }
}