﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public interface IShape
    {
        public void Draw()
        {
            Console.WriteLine($"I am {this.GetType().Name}");
        }
    }
}
