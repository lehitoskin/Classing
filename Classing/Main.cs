// Main.cs
using System;

namespace Classing
{
    class Program
    {
        static void Main()
        {
            Laptop l = new(0, "mini", "Acer", "FreeBSD", 15);
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

            Console.WriteLine();

            Desktop d = new(2, "Giganto", "Alienware", "Windows 10",
                new string[] { "BDR", "S/PDIF Card" });
            d.Display();

            Console.WriteLine("\nDB stuff:");

            // database connection
            DB db = new();
            // reset db
            //db.ResetDatabase();
            //db.AddLaptop(l);
            //db.AddDesktop(d);

            Console.WriteLine("DB Laptop:");
            db.DisplayTable(DB.Table.LAPTOP);

            Console.WriteLine("DB Desktop:");
            db.DisplayTable(DB.Table.DESKTOP);
        }
    }
}
