namespace Boardgames.DataProcessor;

using Boardgames.Data;
using ExportDto;
using Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var creators = context.Creators
            .AsNoTracking()
            .Where(c => c.Boardgames.Any())
            .Select(c => new XmlExportCreatorDto()
            {
                BoardgamesCount = c.Boardgames.Count(),
                Name = c.FirstName + " " + c.LastName,
                //Name = string.Join(" ", new string[] { c.FirstName, c.LastName }),
                Boardgames = c.Boardgames
                    .OrderBy(b => b.Name)
                    .Select(b => new XmlExportCreatorBoardgameDto()
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished,
                    })
                    .ToArray()
            })
            .OrderByDescending(c => c.BoardgamesCount)
            .ThenBy(c => c.Name)
            .ToArray();

        return xmlHelper.Serialize(creators, "Creators");
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellers = context.Sellers
            .AsNoTracking()
            .Where(s => s.BoardgamesSellers
                .Any(bs => bs.Boardgame.YearPublished >= year &&
                           bs.Boardgame.Rating <= rating))
            .Select(s => new JsonExportSellerDto()
            {
                Name = s.Name,
                Website = s.Website,
                Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year &&
                                 bs.Boardgame.Rating <= rating)
                    .OrderByDescending(bs => bs.Boardgame.Rating)
                    .ThenBy(bs => bs.Boardgame.Name)
                    .Select(bs => new JsonExportSellerBoardgameDto()
                    {
                        Name = bs.Boardgame.Name,
                        Rating = bs.Boardgame.Rating,
                        Mechanics = bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Count())
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(sellers, Formatting.Indented);
    }
}