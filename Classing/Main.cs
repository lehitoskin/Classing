// Main.cs
using System;

namespace Classing
{
    class Program
    {
        // TODO: add part helper function (int pn, DB.Table table)
        // TODO: delete part helper function (int pn, DB.Table table)
        // TODO: get part helper function (int pn, DB.Table table)
        // TODO: list table helper function (DB.Table table)

        static void Main()
        {
            /*Laptop laptop = new(1, "pro", "Toshiba", "Windows 10", 13);
            Desktop desktop = new(2, "Giganto", "Alienware", "Windows 10",
                new string[] { "BDR", "S/PDIF Card" });
            Tablet tablet = new(3, "Iconia", "Acer", "Android", 10, false);

            //Console.WriteLine("DB stuff:");

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
            db.DisplayTable(DB.Table.TABLET);*/

            string selection;
            Console.WriteLine("\tInventory Management System");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Add New Part");
                Console.WriteLine("2: Delete Part");
                Console.WriteLine("3: Get Part By Number And Type");
                Console.WriteLine("4: List A Table");
                Console.WriteLine("0: Exit");
                Console.Write("> ");
                selection = Console.ReadLine();
                Console.WriteLine("\nRead string \"{0}\"", selection);
            } while (selection != "0");
        }
    }
}
