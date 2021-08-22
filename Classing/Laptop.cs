// Laptop.cs
using System;

namespace Classing
{
    public class Laptop : Computer
    {
        private int size;

        public Laptop(int pn, string model, string man, string os, int s)
            : base(pn, model, man, os)
        {
            size = s;
        }

        public int GetSize() { return size; }
        public void SetSize(int s) { size = s; }

        public override void Display()
        {
            Console.WriteLine("Laptop:");
            base.Display();
            Console.WriteLine("Size (inches) {0}", size);
        }
    }
}
