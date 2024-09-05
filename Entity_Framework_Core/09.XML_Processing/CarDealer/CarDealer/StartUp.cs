using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //Console.WriteLine(ImportSuppliers(context, File.ReadAllText(@"../../../Datasets/suppliers.xml")));
            //Console.WriteLine(ImportParts(context, File.ReadAllText(@"../../../Datasets/parts.xml")));
            Console.WriteLine(ImportCars(context, File.ReadAllText(@"../../../Datasets/cars.xml")));
            //Console.WriteLine(ImportCustomers(context, File.ReadAllText(@"../../../Datasets/customers.xml")));
            //Console.WriteLine(ImportSales(context, File.ReadAllText(@"../../../Datasets/sales.xml")));


            //string result = GetCarsWithTheirListOfParts(context);
            //Console.WriteLine(result);
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDto[] supplierDtos =
                xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supllierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supllierDto.Name))
                    continue;
                
                Supplier supplier = mapper.Map<Supplier>(supllierDto);

                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count()}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos =
                xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();

            foreach (var carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) ||
                    string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                ICollection<PartCar> validParts = new HashSet<PartCar>();

                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };

                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (string.IsNullOrEmpty(customerDto.Name))
                {
                    continue;
                }

                Customer customer = mapper.Map<Customer>(customerDto);

                validCustomers.Add(customer);
            }

            context.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<Sale> validSales = new HashSet<Sale>();

            foreach (var saleDto in saleDtos)
            {
                if (saleDto.Discount > 100 ||
                    saleDto.Discount < 0 ||
                    saleDto.CustomerId == 0 ||
                    saleDto.CarId == 0 ||
                    !context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);

                validSales.Add(sale);
            }

            context.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var cars = context.Cars
                .AsNoTracking()
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarDto[]>(cars, "cars");
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var bmwCars = context.Cars
                .AsNoTracking()
                .Where(c => c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportBmwCarDto[]>(bmwCars, "cars");
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var suppliers = context.Suppliers
                .AsNoTracking()
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportSupplierDto[]>(suppliers, "suppliers");
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var cars = context.Cars
                .AsNoTracking()
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(cars, "cars");

            //ExportCarWithPartsDto[] carsPartsDtos = context.Cars
            //    .OrderByDescending(c => c.TraveledDistance)
            //    .ThenBy(c => c.Model)
            //    .Take(5)
            //    .Select(c => new ExportCarWithPartsDto()
            //    {
            //        Make = c.Make,
            //        Model = c.Model,
            //        TraveledDistance = c.TraveledDistance,
            //        Parts = c.PartsCars.Select(pc => new ExportCarPartDto()
            //        {
            //            Name = pc.Part.Name,
            //            Price = pc.Part.Price
            //        })
            //        .OrderByDescending(p => p.Price)
            //        .ToArray()
            //    })
            //    .ToArray();

            //return xmlHelper.Serialize<ExportCarWithPartsDto[]>(carsPartsDtos, "cars");
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var customers = context.Customers
                .AsNoTracking()
                .Where(c => c.Sales.Any())
                .Include(c => c.Sales)
                    .ThenInclude(s => s.Car)
                        .ThenInclude(s => s.PartsCars)
                            .ThenInclude(pc => pc.Part)
                .ToArray()
                .AsQueryable()
                .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => double.Parse(c.SpentMoney)) // Judge e izpuskan po glava kato maluk :)
                .ToArray();

            return xmlHelper.Serialize(customers, "customers");
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var sales = context.Sales
                .AsNoTracking()
                .ProjectTo<ExportSaleDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(sales, "sales");

            //ExportSaleDto[] salesDtos = context.Sales
            //    .Select(s => new ExportSaleDto()
            //    {
            //        Car = new ExportSaleCarDto()
            //        {
            //            Make = s.Car.Make,
            //            Model = s.Car.Model,
            //            TraveledDistance = s.Car.TraveledDistance
            //        },
            //        Discount = (int)s.Discount,
            //        CustomerName = s.Customer.Name,
            //        Price = s.Car.PartsCars.Sum(p => p.Part.Price),
            //        PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
            //    })
            //    .ToArray();

            //return xmlHelper.Serialize<ExportSaleDto[]>(salesDtos, "sales");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}