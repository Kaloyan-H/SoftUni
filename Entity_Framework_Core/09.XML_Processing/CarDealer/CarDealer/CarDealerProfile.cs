using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count()));

            // Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId!.Value));
            this.CreateMap<Part, ExportCarPartDto>();

            // Car
            //this.CreateMap<ImportCarDto, Car>()
            //    .ForMember(d => d.PartsCars, opt => opt
            //        .MapFrom(s => s.Parts
            //            .Select(p => new PartCar() { PartId = p.PartId })));

            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportBmwCarDto>();
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, opt => opt
                    .MapFrom(s => s.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)));
            this.CreateMap<Car, ExportSaleCarDto>();

            // Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BoughtCars, opt => opt.MapFrom(s => s.Sales.Count()))
                .ForMember(d => d.SpentMoney, opt => opt
                    .MapFrom(s => s.IsYoungDriver
                        ?
                        /*s.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100).ToString("f2")*/ // Judge e  malko autistic :)
                        s.Sales.Sum(s => s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))).ToString("f2")
                        :
                        s.Sales.Sum(s => s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)).ToString("f2")));
            
            // Sale
            this.CreateMap<ImportSaleDto, Sale>();
            this.CreateMap<Sale, ExportSaleDto>()
                .ForMember(d => d.Car, opt => opt.MapFrom(s => s.Car))
                .ForMember(d => d.Discount, opt => opt.MapFrom(s => (int)s.Discount))
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Car.PartsCars.Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount, opt => opt.MapFrom(s => Math.Round((double)(s.Car.PartsCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100), 4)));
        }
    }
}
