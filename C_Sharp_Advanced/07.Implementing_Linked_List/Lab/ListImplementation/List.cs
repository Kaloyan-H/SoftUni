using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListImplementation
{
    public class List
    {
        private int[] internalArray;
        private int index = 0;
        public int Count = 0;

        public List(int capacity = 4)
        {
            internalArray = new int[capacity];
        }

        public int this[int index]
        {
            get { return internalArray[index]; }
        }

        public void Add(int value)
        {
            Count++;
            if (index >= internalArray.Length)
            {
                Resize();
            }

            internalArray[index++] = value;
        }
        public void RemoveAt(int index)
        {
            Count--;
            for (int i = index; i < internalArray.Length; i++)
            {
                if (i == internalArray.Length - 1)
                {
                    internalArray[i] = 0;
                }
                internalArray[i] = internalArray[i + 1];
            }
        }
        private void Resize()
        {
            int[] newArray = new int[internalArray.Length * 2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                newArray[i] = internalArray[i];
            }

            internalArray = newArray;
        }
    }
}
