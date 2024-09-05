namespace Footballers;

using System.Globalization;

using AutoMapper;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ExportDto;
using Footballers.DataProcessor.ImportDto;

// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
public class FootballersProfile : Profile
{
    public FootballersProfile()
    {
        // Coach
        this.CreateMap<XmlImportCoachDto, Coach>()
            .ForMember(d => d.Footballers, opt => opt.MapFrom(s => new HashSet<Footballer>()))
            /*.ForSourceMember(s => s.Footballers, opt => opt.DoNotValidate())*/;

        // Footballer
        this.CreateMap<XmlImportCoachFootballerDto, Footballer>()
            .ForMember(d => d.ContractStartDate, opt => opt.MapFrom(s => DateTime.ParseExact(s.ContractStartDate!, "dd/MM/yyyy", null)))
            .ForMember(d => d.ContractEndDate, opt => opt.MapFrom(s => DateTime.ParseExact(s.ContractEndDate!, "dd/MM/yyyy", null)))
            .ForMember(d => d.BestSkillType, opt => opt.MapFrom(s => (BestSkillType)s.BestSkillType!))
            .ForMember(d => d.PositionType, opt => opt.MapFrom(s => (PositionType)s.PositionType!));

        this.CreateMap<Footballer, JsonExportTeamFootballerDto>()
            .ForMember(d => d.ContractStartDate, opt => opt.MapFrom(s => s.ContractStartDate.ToString("d", CultureInfo.InvariantCulture)))
            .ForMember(d => d.ContractEndDate, opt => opt.MapFrom(s => s.ContractEndDate.ToString("d", CultureInfo.InvariantCulture)))
            .ForMember(d => d.BestSkillType, opt => opt.MapFrom(s => (BestSkillType)s.BestSkillType))
            .ForMember(d => d.PositionType, opt => opt.MapFrom(s => (PositionType)s.PositionType));

        // Team
        this.CreateMap<JsonImportTeamDto, Team>()
            .ForMember(d => d.TeamsFootballers, opt => opt.MapFrom(s => new HashSet<TeamFootballer>()));

        this.CreateMap<Team, JsonExportTeamDto>()
            .ForMember(d => d.Footballers, opt => opt.MapFrom(s => s.TeamsFootballers
                                                                    .Select(tf => tf.Footballer)
                                                                    .OrderByDescending(f => f.ContractEndDate)
                                                                    .ThenBy(f => f.Name)));
    }
}
