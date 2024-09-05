namespace Formula1.Core
{
    using Contracts;
    using Models;
    using Repositories;
    using Models.Contracts;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using static Utilities.ExceptionMessages;
    using static Utilities.OutputMessages;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            Pilot pilot = (Pilot)pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName);

            if (pilot == null
                || 
                pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (!carRepository.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException(string.Format(CarDoesNotExistErrorMessage, carModel));
            }

            FormulaOneCar car = (FormulaOneCar)carRepository.Models.FirstOrDefault(c => c.Model == carModel);

            carRepository.Remove(car);
            pilot.AddCar(car);

            return string.Format(SuccessfullyPilotToCar, pilot.FullName, car.GetType().Name, car.Model);
        }
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            Pilot pilot = (Pilot)pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);
            Race race = (Race)raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot == null
                ||
                !pilot.CanRace
                ||
                race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(string.Format(CarExistErrorMessage, model));
            }

            switch (type)
            {
                case "Ferrari":
                    carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                    break;
                case "Williams":
                    carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                    break;
                default:
                    throw new InvalidOperationException(string.Format(InvalidTypeCar, type));
            }

            return string.Format(SuccessfullyCreateCar, type, model);
        }
        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(PilotExistErrorMessage, fullName));
            }

            pilotRepository.Add(new Pilot(fullName));

            return string.Format(SuccessfullyCreatePilot, fullName);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(RaceExistErrorMessage, raceName));
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));

            return string.Format(SuccessfullyCreateRace, raceName);
        }
        public string PilotReport()
        {
            List<IPilot> pilotsOrderedByWins = pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins)
                .ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pilotsOrderedByWins.Count; i++)
            {
                sb.AppendLine(pilotsOrderedByWins[i].ToString());
            }

            return sb.ToString().Trim();
        }
        public string RaceReport()
        {
            List<IRace> executedRaces = raceRepository.Models
                .Where(r => r.TookPlace == true)
                .ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < executedRaces.Count(); i++)
            {
                sb.AppendLine(executedRaces[i].RaceInfo());
            }

            return sb.ToString().Trim();
        }
        public string StartRace(string raceName)
        {
            Race race = (Race)raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> topThreePilots = pilotRepository.Models
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToList();

            Pilot firstPlacePilot = (Pilot)topThreePilots[0];
            Pilot secondPlacePilot = (Pilot)topThreePilots[1];
            Pilot thirdPlacePilot = (Pilot)topThreePilots[2];

            firstPlacePilot.WinRace();

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(PilotFirstPlace, firstPlacePilot.FullName, raceName));
            sb.AppendLine(string.Format(PilotSecondPlace, secondPlacePilot.FullName, raceName));
            sb.AppendLine(string.Format(PilotThirdPlace, thirdPlacePilot.FullName, raceName));

            return sb.ToString().Trim();
        }
    }
}
