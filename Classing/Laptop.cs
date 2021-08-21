// Laptop.cs
using System;

namespace Classing
{
    public class Laptop : IPart
    {
        private int partNumber, size;
        private string model, manufacturer, os;

        public Laptop(int pn, int s, string model, string man, string os)
        {
            partNumber = pn;
            size = s;
            this.model = model;
            manufacturer = man;
            this.os = os;
        }

        public int GetPartNumber() { return partNumber; }
        public void SetPartNumber(int pn) { partNumber = pn; }

        public int GetSize() { return size; }
        public void SetSize(int s) { size = s; }

        public string GetModel() { return model; }
        public void SetModel(string m) { model = m; }

        public string GetManufacturer() { return manufacturer; }
        public void SetManufacturer(string m) { manufacturer = m; }

        public string GetOS() { return os; }
        public void SetOS(string os) { this.os = os; }

        public void Display()
        {
            Console.WriteLine("Laptop:");
            Console.WriteLine("Part #{0}", partNumber);
            Console.WriteLine("Type {0}", model);
            Console.WriteLine("Manufacturer {0}", manufacturer);
            Console.WriteLine("Size (inches) {0}", size);
            Console.WriteLine("OS {0}", os);
        }
    }
}
