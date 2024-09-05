using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
		private string model;
		private int capacity;
		private List<CPU> multiprocessor;

		public Computer() { }
		public Computer(string model, int capacity)
		{
			this.model = model;
			this.capacity = capacity;
			this.multiprocessor = new List<CPU>(); ;
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		public int Capacity
		{
			get { return capacity; }
			set { capacity = value; }
		}
		public List<CPU> Multiprocessor
		{
			get { return multiprocessor; }
			set { multiprocessor = value; }
		}
		public int Count
		{
			get { return multiprocessor.Count; } 
		}

		public void Add(CPU cpu)
		{
			if (this.multiprocessor.Count < capacity)
			{
				this.multiprocessor.Add(cpu);
			}
		}
		public bool Remove(string brand) => multiprocessor.Remove(multiprocessor.Find(x => x.Brand == brand));
		public CPU MostPowerful() => multiprocessor.OrderByDescending(x => x.Frequency).First();
		public CPU GetCPU(string brand) => multiprocessor.Find(x => x.Brand == brand);
		//{
		//	if (multiprocessor.Where(x => x.Brand == brand).Count() == 0)
		//	{
		//		return null;
		//	}
		//	return multiprocessor.Find(x => x.Brand == brand);
		//}
		public string Report() => $"CPUs in the Computer {this.model}:{Environment.NewLine}" +
            $"{string.Join(Environment.NewLine, multiprocessor)}";
	}
}
