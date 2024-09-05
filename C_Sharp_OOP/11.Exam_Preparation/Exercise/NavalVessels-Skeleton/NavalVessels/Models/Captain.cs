namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;

        private Captain()
        {
            this.CombatExperience = 0;
            this.vessels = new List<IVessel>();
        }
        public Captain(string fullName)
            : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(FullName), ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }
        public int CombatExperience
        {
            get { return this.combatExperience; }
            private set { this.combatExperience = value; }
        }
        public ICollection<IVessel> Vessels
            => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.vessels.Add(vessel);
        }
        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            foreach (var vessel in this.Vessels)
            {
                sb
                    .AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
