﻿namespace Formula1.Models
{
    using System;
    using Contracts;
    using static Utilities.ExceptionMessages;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(InvalidF1CarModel, value));
                }
                model = value;
            }
        }
        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(string.Format(InvalidF1EngineDisplacement, value));
                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
