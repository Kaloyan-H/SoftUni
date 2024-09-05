namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        private Vessel()
        {
            targets = new List<string>();
        }
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : this()
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), InvalidVesselName);
                }
                this.name = value;
            }
        }
        public ICaptain Captain
        {
            get { return this.captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return this.armorThickness; }
            set
            {
                if (value < 0)
                {
                    this.armorThickness = 0;
                }
                else
                {
                    this.armorThickness = value;
                }
            }
        }
        public double MainWeaponCaliber
        {
            get { return this.mainWeaponCaliber; }
            protected set { this.mainWeaponCaliber = value; }
        }
        public double Speed
        {
            get { return this.speed; }
            protected set { this.speed = value; }
        }
        public ICollection<string> Targets
        {
            get { return this.targets; }
            private set { this.targets = value; }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            this.Targets.Add(target.Name);

            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }
        public abstract void RepairVessel();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsOutput = this.Targets.Any() ?
                string.Join(", ", this.Targets) : "None";

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {this.ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
                .AppendLine($" *Speed: {this.Speed} knots")
                .AppendLine($" *Targets: {targetsOutput}");

            return sb.ToString().TrimEnd();
        }
    }
}
