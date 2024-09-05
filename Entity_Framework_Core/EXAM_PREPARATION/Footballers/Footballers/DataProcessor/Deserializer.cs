namespace Footballers.DataProcessor;

using System.ComponentModel.DataAnnotations;

using AutoMapper;

using Data;
using ImportDto;
using Utilities;
using Data.Models;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        XmlImportCoachDto[] coachDtos =
            xmlHelper.Deserialize<XmlImportCoachDto[]>(xmlString, "Coaches");

        ICollection<Coach> validCoaches = new HashSet<Coach>();

        StringBuilder sb = new StringBuilder();

        foreach (var coachDto in coachDtos)
        {
            if (!IsValid(coachDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Coach coach = mapper.Map<Coach>(coachDto);

            ICollection<Footballer> validFootballers = new HashSet<Footballer>();

            foreach (var footballerDto in coachDto.Footballers)
            {
                if (!IsValid(footballerDto) ||
                    DateTime.ParseExact(footballerDto.ContractStartDate!, "dd/MM/yyyy", null) > DateTime.ParseExact(footballerDto.ContractEndDate!, "dd/MM/yyyy", null))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Footballer footballer = mapper.Map<Footballer>(footballerDto);

                coach.Footballers.Add(footballer);
            }

            sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count()));

            validCoaches.Add(coach);
        }

        context.Coaches.AddRange(validCoaches);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        IMapper mapper = InitializeAutoMapper();

        JsonImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<JsonImportTeamDto[]>(jsonString)!;

        ICollection<Team> validTeams = new HashSet<Team>();
        ICollection<TeamFootballer> teamsFootballers = new HashSet<TeamFootballer>();

        StringBuilder sb = new StringBuilder();

        foreach (var teamDto in teamDtos)
        {
            if (!IsValid(teamDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Team team = mapper.Map<Team>(teamDto);

            validTeams.Add(team);

            ICollection<TeamFootballer> teamFootballers = new HashSet<TeamFootballer>();

            foreach (var footballerId in teamDto.FootballerIds.Distinct())
            {
                if (!context.Footballers.Any(f => f.Id == footballerId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TeamFootballer teamFootballer = new TeamFootballer()
                {
                    Team = team,
                    FootballerId = footballerId
                };

                teamFootballers.Add(teamFootballer);
                teamsFootballers.Add(teamFootballer);
            }

            sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, teamFootballers.Count()));

            validTeams.Add(team);
        }

        var uniqueFootballersAddedCount = teamsFootballers.DistinctBy(tf => tf.FootballerId).ToArray();

        context.Teams.AddRange(validTeams);
        context.TeamsFootballers.AddRange(teamsFootballers);

        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static IMapper InitializeAutoMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<FootballersProfile>();
        }));
    }
}
