namespace ProductShop;

using Data;
using ProductShop.Models;
using Newtonsoft.Json;
using ProductShop.DTOs.Import;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.DTOs.Export;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json.Serialization;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        string result = GetUsersWithProducts(context);
        Console.WriteLine(result);
    }

    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson)!;

        ICollection<User> validUsers = new HashSet<User>();

        foreach (var userDto in userDtos)
        {
            User user = mapper.Map<User>(userDto);

            validUsers.Add(user);
        }

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return $"Successfully imported {validUsers.Count()}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson)!;

        ICollection<Product> validProducts = new HashSet<Product>();

        foreach (var productDto in productDtos)
        {
            Product product = mapper.Map<Product>(productDto);

            validProducts.Add(product);
        }

        context.Products.AddRange(validProducts);
        context.SaveChanges();

        return $"Successfully imported {validProducts.Count}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)!;

        ICollection<Category> validCategories = new HashSet<Category>();

        foreach (var categoryDto in categoryDtos)
        {
            if (string.IsNullOrEmpty(categoryDto.Name))
            {
                continue;
            }

            Category category = mapper.Map<Category>(categoryDto);

            validCategories.Add(category);
        }

        context.Categories.AddRange(validCategories);
        context.SaveChanges();

        return $"Successfully imported {validCategories.Count}";
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson)!;

        ICollection<CategoryProduct> validCategoriesProducts = new HashSet<CategoryProduct>();

        foreach (var categoryProductDto in categoryProductDtos)
        {
            // Judge doesn't like this validation
            if (!context.Categories.Any(c => c.Id == categoryProductDto.CategoryId) ||
                !context.Products.Any(p => p.Id == categoryProductDto.ProductId))
            {
                continue;
            }

            CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);

            validCategoriesProducts.Add(categoryProduct);
        }

        context.CategoriesProducts.AddRange(validCategoriesProducts);
        context.SaveChanges();

        return $"Successfully imported {validCategoriesProducts.Count}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context)
    {
        //var products = context.Products
        //    .AsNoTracking()
        //    .Where(p => p.Price >= 500 && p.Price <= 1000)
        //    .OrderBy(p => p.Price)
        //    .Select(p => new
        //    {
        //        name = p.Name,
        //        price = p.Price,
        //        seller = p.Seller.FirstName + ' ' + p.Seller.LastName
        //    })
        //    .ToArray();

        IMapper mapper = CreateMapper();

        ExportProductInRangeDto[] productDtos = context.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
            .ToArray();

        return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var users = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer!.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
            })
            .ToArray();

        return JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IContractResolver contractResolver = ConfigureCamelCaseNaming();

        var categories = context.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoriesProducts.Count())
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count(),
                AveragePrice = c.CategoriesProducts.Any() ?
                    c.CategoriesProducts
                    .Average(cp => cp.Product.Price)
                    .ToString("f2") : "0",
                TotalRevenue = c.CategoriesProducts.Any() ?
                    c.CategoriesProducts
                    .Sum(cp => cp.Product.Price)
                    .ToString("f2") : "0"
            })
            .ToArray();

        return JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IContractResolver contractResolver= ConfigureCamelCaseNaming();

        var users = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold
                .Any(p => p.Buyer != null))
            .OrderByDescending(u => u.ProductsSold
                .Count(p => p.Buyer != null))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold
                        .Count(p => p.Buyer != null),
                    Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                }
            })
            .ToArray();

        var outputObj = new
        {
            UsersCount = users.Count(),
            Users = users
        };

        return JsonConvert.SerializeObject(outputObj, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            NullValueHandling = NullValueHandling.Ignore,
        });
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
    }

    private static IContractResolver ConfigureCamelCaseNaming()
    {
        return new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy(false, true)
        };
    }
}