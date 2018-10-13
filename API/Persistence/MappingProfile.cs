using System.Linq;
using API.Dtos;
using API.Dtos.GET;
using API.Dtos.POST;
using API.Models;
using AutoMapper;

namespace API.Persistence
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //GET Mappings
            CreateMap<Product, GetProductDto>();
            CreateMap<Field, GetFieldDto>();
            CreateMap<Category, GetCategoryDto>()
                .ForMember(dto => dto.ProductsCount, opt => opt.MapFrom(c => c.Products.Count));          

            //POST Mappings
            CreateMap<PostProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Category, opt => opt.Ignore())
                .AfterMap((productDto, product) => {
                    if(product.CategoryId == 0)
                        product.CategoryId = null;
                });

            CreateMap<PostFieldDto, Field>();

            CreateMap<PostCategoryDto, Category>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Products, opt => opt.Ignore())
                .ForMember(c => c.AdditionalFields, opt => opt.Ignore());

            //Other
            CreateMap<FieldValue, FieldValueDto>();
            CreateMap<FieldValueDto, FieldValue>();
        }
    }
}