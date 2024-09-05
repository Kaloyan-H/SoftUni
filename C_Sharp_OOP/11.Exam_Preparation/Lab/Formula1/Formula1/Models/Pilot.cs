namespace Formula1.Models
{
    using System;
    using Contracts;
    using static Utilities.ExceptionMessages;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        private Pilot()
        {
            CanRace = false;
        }
        public Pilot(string fullName)
            : this()
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(InvalidPilot, value));
                }
                fullName = value;
            }
        }
        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(InvalidCarForPilot);
                }
                car = value;
            }
        }
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }
        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }
        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
