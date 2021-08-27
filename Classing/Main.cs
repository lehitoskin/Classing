// Main.cs
using System;

namespace Classing
{
    class Program
    {
        static void Main()
        {
            Laptop laptop = new(1, "pro", "Toshiba", "Windows 10", 13);
            Desktop desktop = new(2, "Giganto", "Alienware", "Windows 10",
                new string[] { "BDR", "S/PDIF Card" });
            Tablet tablet = new(3, "Iconia", "Acer", "Android", 10, false);

            Console.WriteLine("DB stuff:");

            // database connection
            DB db = new();
            // reset db
            //db.ResetDatabase();

            // add objects to the database
            //db.AddPart(laptop);
            //db.AddPart(desktop);
            //db.AddPart(tablet);

            Console.WriteLine("DB Laptop:");
            db.DisplayTable(DB.Table.LAPTOP);
            Console.WriteLine("DB Desktop:");
            db.DisplayTable(DB.Table.DESKTOP);
            Console.WriteLine("DB Tablet:");
            db.DisplayTable(DB.Table.TABLET);
        }
    }
}
