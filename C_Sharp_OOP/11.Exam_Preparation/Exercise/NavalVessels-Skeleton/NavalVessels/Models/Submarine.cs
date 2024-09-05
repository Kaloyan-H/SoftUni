namespace NavalVessels.Models
{
    using System.Text;
    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double DEFAULT_ARMOR_THICKNESS = 200;
        private const double MAIN_WEAPON_CALIBER_CHANGE = 40;
        private const double SPEED_CHANGE = 4;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNESS)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get { return this.submergeMode; }
            private set { this.submergeMode = value; }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = DEFAULT_ARMOR_THICKNESS;
        }
        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;

            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += MAIN_WEAPON_CALIBER_CHANGE;
                this.Speed -= SPEED_CHANGE;
            }
            else
            {
                this.MainWeaponCaliber -= MAIN_WEAPON_CALIBER_CHANGE;
                this.Speed += SPEED_CHANGE;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string submergeModeText = this.SubmergeMode ?
                "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {submergeModeText}");

            return sb.ToString().TrimEnd();
        }
    }
}
