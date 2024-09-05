using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private int speed;
        private int power;
        private string model;
        private int? displacement = null;
        private string efficiency;

        public Engine() { }
        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }
        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.displacement = displacement;
        }
        public Engine(string model, int power,string efficiency) : this(model, power)
        {
            this.efficiency = efficiency;
        }
        public Engine(string model, int power,int displacement, string efficiency) : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int? Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
