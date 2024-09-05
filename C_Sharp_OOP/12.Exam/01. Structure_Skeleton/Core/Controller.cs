namespace ChristmasPastryShop.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Repositories;
    using Models.Booths;
    using Models.Delicacies;
    using Models.Delicacies.Contracts;
    using Models.Cocktails;
    using Models.Cocktails.Contracts;
    using Models.Booths.Contracts;
    using static Utilities.Messages.OutputMessages;
    using System.Collections.Generic;
    using System.Text;

    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);

            return string.Format(NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail;

            if (size != "Small"
                &&
                size != "Middle"
                &&
                size != "Large")
            {
                return string.Format(InvalidCocktailSize, size);
            }
            switch (cocktailTypeName)
            {
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    return string.Format(InvalidCocktailType, cocktailTypeName);
            }

            if (this.booths
                .Models
                .FirstOrDefault(b => b.BoothId == boothId)
                .CocktailMenu
                .Models
                .Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(CocktailAlreadyAdded, size, cocktailName);
            }

            this.booths
                .Models
                .FirstOrDefault(b => b.BoothId == boothId)
                .CocktailMenu
                .AddModel(cocktail);

            return string.Format(NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    return string.Format(InvalidDelicacyType, delicacyTypeName);
            }

            if (this.booths
                .Models
                .FirstOrDefault(b => b.BoothId == boothId)
                .DelicacyMenu
                .Models
                .Any(d => d.Name == delicacyName))
            {
                return string.Format(DelicacyAlreadyAdded, delicacyName);
            }

            this.booths
                .Models
                .FirstOrDefault(b => b.BoothId == boothId)
                .DelicacyMenu
                .AddModel(delicacy);

            return string.Format(NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {bill:f2} lv");
            sb.AppendLine(string.Format(BoothIsAvailable, boothId));

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> availableBooths = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();

            if (availableBooths.Count == 0)
            {
                return string.Format(NoAvailableBooth, countOfPeople);
            }

            IBooth firstAvailableBooth = availableBooths
                .First();
            firstAvailableBooth.ChangeStatus();

            return string.Format(BoothReservedSuccessfully, firstAvailableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] args = order.Split('/');
            string itemTypeName = args[0];
            string itemName = args[1];
            int countOfOrderedPieces = int.Parse(args[2]);

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            switch (itemTypeName)
            {
                case "Gingerbread":
                case "Stolen":

                    if (!booth.DelicacyMenu.Models
                        .Where(d => d.GetType().Name == itemTypeName)
                        .Any(d => d.Name == itemName))
                    {
                        return string.Format(NotRecognizedItemName, itemTypeName, itemName);
                    }
                    if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                    {
                        return string.Format(DelicacyStillNotAdded, itemTypeName, itemName);
                    }

                    IDelicacy delicacy = booth.DelicacyMenu.Models
                        .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName);

                    booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);

                    return string.Format(SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
                case "Hibernation":
                case "MulledWine":

                    string size = args[3];
                    if (!booth.CocktailMenu.Models
                        .Where(c => c.GetType().Name == itemTypeName)
                        .Any(c => c.Name == itemName))
                    {
                        return string.Format(NotRecognizedItemName, itemTypeName, itemName);
                    }
                    if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName && c.Size == size))
                    {
                        return string.Format(CocktailStillNotAdded, size, itemName);
                    }

                    ICocktail cocktail = booth.CocktailMenu.Models
                        .FirstOrDefault(c => c.Name == itemName && c.Size == size);

                    booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);

                    return string.Format(SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
                default:
                    return string.Format(NotRecognizedType, itemTypeName);
            }
        }
    }
}
