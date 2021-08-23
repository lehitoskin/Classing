// Main.cs
using System;

namespace Classing
{
    class Program
    {
        static void Main()
        {
            Laptop laptop = new(0, "mini", "Acer", "FreeBSD", 15);
            // display generated laptop object
            laptop.Display();

            Console.WriteLine();

            // rewrite laptop object
            laptop.SetPartNumber(1);
            laptop.SetModel("pro");
            laptop.SetManufacturer("Toshiba");
            laptop.SetSize(13);
            laptop.SetOS("Windows 10");
            // display modified object
            laptop.Display();

            //Console.WriteLine();

            Desktop desktop = new(2, "Giganto", "Alienware", "Windows 10",
                new string[] { "BDR", "S/PDIF Card" });
            desktop.Display();

            Console.WriteLine("DB stuff:");

            // database connection
            DB db = new();
            // reset db
            //db.ResetDatabase();

            // add objects to the database
            //db.AddPart(laptop);
            //db.AddPart(desktop);

            Console.WriteLine("DB Laptop:");
            db.DisplayTable(DB.Table.LAPTOP);
            Console.WriteLine("DB Desktop:");
            db.DisplayTable(DB.Table.DESKTOP);

            // can throw an exception
            Desktop d2 = (Desktop)db.GetPart(DB.Table.DESKTOP, 3);
            if (d2 is not null)
                d2.Display();

            // delete single laptop object
            //db.DeletePart(laptop);
            // delete single desktop object
            //db.DeletePart(desktop);

            //Console.WriteLine("DB Laptop:");
            //db.DisplayTable(DB.Table.LAPTOP);
            //Console.WriteLine("DB Desktop:");
            //db.DisplayTable(DB.Table.DESKTOP);
        }
    }
}
