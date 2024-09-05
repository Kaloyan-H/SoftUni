namespace NavalVessels.Models
{
    using System.Text;
    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double DEFAULT_ARMOR_THICKNESS = 300;
        private const double MAIN_WEAPON_CALIBER_CHANGE = 40;
        private const double SPEED_CHANGE = 5;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNESS)
        {
            this.SonarMode = false;
        }

        public bool SonarMode
        {
            get { return this.sonarMode; }
            private set { this.sonarMode = value; }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = DEFAULT_ARMOR_THICKNESS;
        }
        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;

            if (this.SonarMode)
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

            string sonarModeText = this.SonarMode ?
                "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Sonar mode: {sonarModeText}");

            return sb.ToString().TrimEnd();
        }
    }
}
