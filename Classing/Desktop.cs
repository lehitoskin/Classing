// Desktop.cs
using System;

namespace Classing
{
    public class Desktop : Computer
    {
        private string[] peripherals;

        public Desktop(int pn, string model, string man, string os, string[] p)
            : base(pn, model, man, os)
        {
            peripherals = p;
        }

        public string[] GetPeripherals() { return peripherals; }
        public void SetPeripherals(string[] p) { peripherals = p; }

        public override void Display()
        {
            Console.WriteLine("Desktop:");
            base.Display();
            Console.WriteLine("Peripherals [{0}]",
                string.Join(", ", peripherals));
        }
    }
}
