namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using static Utilities.ExceptionMessages;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;

        private Race()
        {
            tookPlace = false;
            pilots = new List<IPilot>();
        }
        public Race(string raceName, int numberOfLaps)
            : this()
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(InvalidRaceName, value));
                }
                raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }
        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }
        public ICollection<IPilot> Pilots
        {
            get { return pilots; }
        }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }
        public string RaceInfo()
        {
            string yesOrNo = TookPlace ? "Yes" : "No";

            return $"The {RaceName} race has:{Environment.NewLine}" +
                $"Participants: {Pilots.Count}{Environment.NewLine}" +
                $"Number of laps: {NumberOfLaps}{Environment.NewLine}" +
                $"Took place: {yesOrNo}";
        }
    }
}
