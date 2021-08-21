// Main.cs
using System;

namespace Classing
{
    class Program
    {
        static void Main()
        {
            Laptop l = new(0, 15, "mini", "Acer", "FreeBSD");
            // display generated laptop object
            l.Display();

            Console.WriteLine();

            // rewrite laptop object
            l.SetPartNumber(1);
            l.SetModel("pro");
            l.SetManufacturer("Toshiba");
            l.SetSize(13);
            l.SetOS("Windows 10");
            // display modified object
            l.Display();
        }
    }
}
