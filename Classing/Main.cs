// Main.cs
using System;

namespace Classing
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop l = new Laptop(0, 15, "mini", "Acer", "FreeBSD");
            // display generated laptop object
            l.display();

            Console.WriteLine();

            // rewrite laptop object
            l.setPartNumber(1);
            l.setModel("pro");
            l.setManufacturer("Toshiba");
            l.setSize(13);
            l.setOS("Windows 10");
            // display modified object
            l.display();
        }
    }
}
