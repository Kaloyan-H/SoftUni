using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
		private string brand;
		private int cores;
		private double frequency;

		public CPU() { }
		public CPU(string brand, int cores, double frequency)
		{
			this.brand = brand;
			this.cores = cores;
			this.frequency = frequency;
		}

		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}
		public int Cores
		{
			get { return cores; }
			set { cores = value; }
		}
		public double Frequency
		{
			get { return frequency; }
			set { frequency = value; }
		}

		public override string ToString()
		{
			return $"{brand} CPU:{Environment.NewLine}" +
                $"Cores: {cores}{Environment.NewLine}" +
                $"Frequency: {frequency:f1} GHz";
		}
	}
}
