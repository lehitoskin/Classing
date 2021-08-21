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

        public int getPartNumber() { return partNumber; }
        public void setPartNumber(int pn) { partNumber = pn; }

        public int getSize() { return size; }
        public void setSize(int s) { size = s; }

        public string getModel() { return model; }
        public void setModel(string m) { model = m; }

        public string getManufacturer() { return manufacturer; }
        public void setManufacturer(string m) { manufacturer = m; }

        public string getOS() { return os; }
        public void setOS(string os) { this.os = os; }

        public void display()
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
