namespace Boardgames.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;

using Data.Models;
using ImportDto;
using Data;
using Utilities;
using Data.Models.Enums;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        XmlHelper xmlHelper = new XmlHelper();

        XmlImportCreatorDto[] creatorDtos =
            xmlHelper.Deserialize<XmlImportCreatorDto[]>(xmlString, "Creators");

        ICollection<Creator> validCreators = new HashSet<Creator>();

        StringBuilder sb = new StringBuilder();

        foreach (var creatorDto in creatorDtos)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Creator creator = new Creator()
            {
                FirstName = creatorDto.FirstName!,
                LastName = creatorDto.LastName!,
            };

            foreach (var boardgameDto in creatorDto.Boardgames)
            {
                if (!IsValid(boardgameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Boardgame boardgame = new Boardgame()
                {
                    Name = boardgameDto.Name!,
                    Rating = (double)boardgameDto.Rating!,
                    YearPublished = (int)boardgameDto.YearPublished!,
                    CategoryType = (CategoryType)boardgameDto.CategoryType!,
                    Mechanics = boardgameDto.Mechanics!,
                };

                creator.Boardgames.Add(boardgame);
            }

            validCreators.Add(creator);

            sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count()));
        }

        context.Creators.AddRange(validCreators);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        JsonImportSellerDto[] sellerDtos =
            JsonConvert.DeserializeObject<JsonImportSellerDto[]>(jsonString)!;

        ICollection<Seller> validSellers = new HashSet<Seller>();

        StringBuilder sb = new StringBuilder();

        foreach (var sellerDto in sellerDtos)
        {
            if (!IsValid(sellerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Seller seller = new Seller()
            {
                Name = sellerDto.Name!,
                Address = sellerDto.Address!,
                Country = sellerDto.Country!,
                Website = sellerDto.Website!
            };

            foreach (var boardgameId in sellerDto.BoardgameIds.Distinct())
            {
                if (!context.Boardgames.Any(b => b.Id == boardgameId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                BoardgameSeller boardgameSeller = new BoardgameSeller()
                {
                    BoardgameId = boardgameId,
                    Seller = seller
                };

                seller.BoardgamesSellers.Add(boardgameSeller);
            }

            validSellers.Add(seller);

            sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
        }

        context.Sellers.AddRange(validSellers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
