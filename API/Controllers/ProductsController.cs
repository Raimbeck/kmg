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
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await repository.GetProducts();
            var productsDto = mapper.Map<IEnumerable<Product>, IEnumerable<GetProductDto>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDto = await repository.GetProductDto(id);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]PostProductDto productDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.CreateProduct(productDto);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]PostProductDto productDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var response = await repository.UpdateProduct(id, productDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            var response = await repository.DeleteProduct(id);

            return Ok(response);
        }
    }
}