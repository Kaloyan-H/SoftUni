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
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportUserDto>()
                .ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold));
            this.CreateMap<User[], ExportUsersDto>()
                .ForMember(d => d.UserCount, opt => opt.MapFrom(s => s.Count()))
                .ForMember(d => d.Users, opt => opt.MapFrom(s => s));
            this.CreateMap<User, ExportUsersUserDto>()
                .ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold.ToArray()));

            // Product
            this.CreateMap<ImportProductDto, Product>()
                .ForMember(d => d.BuyerId,
                    opt => opt.MapFrom(s => s.BuyerId == 0
                    ? null
                    : s.BuyerId));
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.BuyerName,
                    opt => opt.MapFrom(s => s.Buyer == null
                    ? null
                    : s.Buyer.FirstName + " " + s.Buyer.LastName));
            this.CreateMap<Product, ExportUserProductDto>();
            this.CreateMap<Product[], ExportSoldProductsDto>()
                .ForMember(d => d.ProductsCount, opt => opt.MapFrom(s => s.Count()))
                .ForMember(d => d.Products, opt => opt.MapFrom(s => s.OrderByDescending(s => s.Price)));
            this.CreateMap<Product, ExportSoldProductsProductDto>();

            // Category
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<Category, ExportCategoryDto>()
                .ForMember(d => d.ProductsCount, opt => opt.MapFrom(s => s.CategoryProducts.Count()))
                .ForMember(d => d.AveragePrice, opt => opt.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(d => d.TotalRevenue, opt => opt.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));

            // CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
