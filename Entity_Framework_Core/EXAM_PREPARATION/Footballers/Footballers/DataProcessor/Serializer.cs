namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Utilities;
    using AutoMapper.QueryableExtensions;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            IMapper mapper = InitializeAutoMapper();

            var teams = context.Teams
                .AsNoTracking()
                .Where(t => t.TeamsFootballers
                    .Any(tf => tf.Footballer.ContractStartDate >= date))
                .OrderByDescending(t => t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date).Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ProjectTo<JsonExportTeamDto>(mapper.ConfigurationProvider)
                .ToArray();


            foreach (var team in teams)
            {
                HashSet<JsonExportTeamFootballerDto> footballersToBeRemoved = new HashSet<JsonExportTeamFootballerDto>();

                foreach (var footballer in team.Footballers)
                {
                    if (!(DateTime.ParseExact(footballer.ContractStartDate, "MM/dd/yyyy", null) >= date))
                    {
                        footballersToBeRemoved.Add(footballer);
                    }
                }

                foreach (var footballer in footballersToBeRemoved)
                {
                    team.Footballers.Remove(footballer);
                }
            }

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }

        private static IMapper InitializeAutoMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
        }
    }
}
