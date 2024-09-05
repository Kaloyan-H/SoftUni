using AutoMapper;
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

            // Part
            this.CreateMap<ImportPartDto, Part>();

            // Customer
            this.CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate))
                .ForMember(d => d.IsYoungDriver, opt => opt.MapFrom(s => s.IsYoungDriver));

            // Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
