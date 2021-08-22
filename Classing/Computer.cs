// Computer.cs
// Computer superclass for Laptop and Desktop
using System;

namespace Classing
{
    public abstract class Computer : IPart
    {
        private int partNumber;
        private string model, manufacturer, os;

        public Computer(int pn, string model, string man, string os)
        {
            partNumber = pn;
            this.model = model;
            manufacturer = man;
            this.os = os;
        }

        public int GetPartNumber() { return partNumber; }
        public void SetPartNumber(int pn) { partNumber = pn; }

        public string GetModel() { return model; }
        public void SetModel(string m) { model = m; }

        public string GetManufacturer() { return manufacturer; }
        public void SetManufacturer(string m) { manufacturer = m; }

        public string GetOS() { return os; }
        public void SetOS(string os) { this.os = os; }

        public virtual void Display()
        {
            Console.WriteLine("Part #{0}", partNumber);
            Console.WriteLine("Type {0}", model);
            Console.WriteLine("Manufacturer {0}", manufacturer);
            Console.WriteLine("OS {0}", os);
        }
    }
}
