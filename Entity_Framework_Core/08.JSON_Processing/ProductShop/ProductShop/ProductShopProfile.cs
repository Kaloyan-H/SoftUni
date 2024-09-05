using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            // User
            CreateMap<User, ImportUserDto>();
            CreateMap<ImportUserDto, User>();

            // Product
            CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerName, opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            // Category
            CreateMap<Category, ImportCategoryDto>();
            CreateMap<ImportCategoryDto, Category>();

            // CategoryProduct
            CreateMap<CategoryProduct, ImportCategoryProductDto>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
