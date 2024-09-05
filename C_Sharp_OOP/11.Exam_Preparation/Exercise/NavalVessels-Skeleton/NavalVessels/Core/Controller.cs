namespace NavalVessels.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using Models;
    using Contracts;
    using Repositories;
    using Models.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private HashSet<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.Models.FirstOrDefault(v => v.Name == attackingVesselName);
            IVessel defendingVessel = vessels.Models.FirstOrDefault(v => v.Name == defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attackingVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendingVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);

            return string.Format(OutputMessages.SuccessfullyAttackVessel,
                defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }
        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

            if (captain == null)
            {
                return null;
            }

            return captain.Report();
        }
        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(new Captain(fullName));
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => typeof(IVessel).IsAssignableFrom(t) && t.Name == vesselType);

            if (vessels.Models.Any(v => v.Name == name))
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (type == null)
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel vessel = (IVessel)Activator
                .CreateInstance(type, new object[] { name, mainWeaponCaliber, speed });

            vessels.Add(vessel);

            return string
                .Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            string type = vessel.GetType().Name;

            switch (type)
            {
                case "Battleship":

                    Battleship battleship = (Battleship)vessel;

                    battleship.ToggleSonarMode();

                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);

                case "Submarine":

                    Submarine submarine = (Submarine)vessel;

                    submarine.ToggleSubmergeMode();

                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

                default:
                    return null;
            }
        }
        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel == null)
            {
                return null;
            }

            return vessel.ToString();
        }
    }
}
