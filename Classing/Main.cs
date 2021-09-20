// Main.cs
using System;

namespace Classing
{
    class Program
    {
        // TODO: list table helper function (DB.Table table)

        private static void AddPart(DB db)
        {
            string selection;
            Console.WriteLine("\tAdd Part");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Add Laptop");
                Console.WriteLine("2: Add Desktop");
                Console.WriteLine("3: Add Tablet");
                Console.WriteLine("0: Return to main menu");
                Console.Write("> ");
                selection = Console.ReadLine();

                int pn;
                string model, man, os;

                if (selection.Equals("1"))
                {
                    int s;

                    Console.Write("Part number: ");
                    pn = Int32.Parse(Console.ReadLine());
                    Console.Write("Model: ");
                    model = Console.ReadLine();
                    Console.Write("Manufacturer: ");
                    man = Console.ReadLine();
                    Console.Write("Operating System: ");
                    os = Console.ReadLine();
                    Console.Write("Size (inches): ");
                    s = Int32.Parse(Console.ReadLine());

                    Laptop laptop = new(pn, model, man, os, s);
                    db.AddPart(laptop);

                    Console.WriteLine("Added new laptop");
                }
                else if (selection.Equals("2"))
                {
                    string[] peripherals;

                    Console.Write("Part number: ");
                    pn = Int32.Parse(Console.ReadLine());
                    Console.Write("Model: ");
                    model = Console.ReadLine();
                    Console.Write("Manufacturer: ");
                    man = Console.ReadLine();
                    Console.Write("Operating System: ");
                    os = Console.ReadLine();
                    Console.Write("Peripherals (separated by commas): ");
                    peripherals = Console.ReadLine().Split(", ");

                    Desktop desktop = new(pn, model, man, os, peripherals);
                    db.AddPart(desktop);

                    Console.WriteLine("Added new desktop");
                }
                else if (selection.Equals("3"))
                {
                    int s;
                    Boolean stylus;

                    Console.Write("Part number: ");
                    pn = Int32.Parse(Console.ReadLine());
                    Console.Write("Model: ");
                    model = Console.ReadLine();
                    Console.Write("Manufacturer: ");
                    man = Console.ReadLine();
                    Console.Write("Operating System: ");
                    os = Console.ReadLine();
                    Console.Write("Size (inches): ");
                    s = Int32.Parse(Console.ReadLine());
                    Console.Write("Stylus included? ");
                    stylus = Boolean.Parse(Console.ReadLine());

                    Tablet tablet = new(pn, model, man, os, s, stylus);
                    db.AddPart(tablet);

                    Console.WriteLine("Added new tablet");
                }
                else if (selection.Equals("0"))
                {
                    Console.WriteLine("Returning to the main menu");
                }
                else
                {
                    Console.WriteLine
                        ($"Selection \"{selection}\" is not understood");
                }
            } while (!selection.Equals("0"));
        }

        private static void DeletePart(DB db)
        {
            string selection;
            int pn;
            Console.WriteLine("\tDelete Part");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Delete Laptop");
                Console.WriteLine("2: Delete Desktop");
                Console.WriteLine("3: Delete Tablet");
                Console.WriteLine("0: Return to main menu");
                Console.Write("> ");
                selection = Console.ReadLine();

                if (selection.Equals("1"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Laptop laptop = (Laptop)db.GetPart(DB.Table.LAPTOP, pn);

                    if (laptop is null)
                        Console.WriteLine("No laptop found with that number.");
                    else
                        db.DeletePart(laptop);
                }
                else if (selection.Equals("2"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Desktop desktop = (Desktop)db.GetPart(DB.Table.DESKTOP, pn);

                    if (desktop is null)
                        Console.WriteLine("No desktop found with that number.");
                    else
                        db.DeletePart(desktop);
                }
                else if (selection.Equals("3"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Tablet tablet = (Tablet)db.GetPart(DB.Table.TABLET, pn);

                    if (tablet is null)
                        Console.WriteLine("No tablet found with that number.");
                    else
                        db.DeletePart(tablet);
                }
                else if (selection.Equals("0"))
                {
                    Console.WriteLine("Returning to the main menu");
                }
                else
                {
                    Console.WriteLine
                        ($"Selection \"{selection}\" is not understood");
                }
            } while (!selection.Equals("0"));
        }

        private static void GetPart(DB db)
        {
            string selection;
            int pn;
            Console.WriteLine("\tGet Part");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Get Laptop");
                Console.WriteLine("2: Get Desktop");
                Console.WriteLine("3: Get Tablet");
                Console.WriteLine("0: Return to main menu");
                Console.Write("> ");
                selection = Console.ReadLine();
                
                if (selection.Equals("1"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Laptop laptop = (Laptop)db.GetPart(DB.Table.LAPTOP, pn);

                    if (laptop is null)
                        Console.WriteLine("No laptop found with that number.");
                    else
                        laptop.Display();
                }
                else if (selection.Equals("2"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Desktop desktop = (Desktop)db.GetPart(DB.Table.DESKTOP, pn);

                    if (desktop is null)
                        Console.WriteLine("No desktop found with that number.");
                    else
                        desktop.Display();
                }
                else if (selection.Equals("3"))
                {
                    Console.Write("Please enter a part number: ");
                    pn = Int32.Parse(Console.ReadLine());

                    Tablet tablet = (Tablet)db.GetPart(DB.Table.TABLET, pn);

                    if (tablet is null)
                        Console.WriteLine("No tablet found with that number.");
                    else
                        tablet.Display();
                }
                else if (selection.Equals("0"))
                {
                    Console.WriteLine("Returning to the main menu");
                }
                else
                {
                    Console.WriteLine
                        ($"Selection \"{selection}\" is not understood");
                }
            } while (!selection.Equals("0"));
        }

        private static void DisplayTable(DB db)
        {
            string selection;

            Console.WriteLine("\tDisplayTable");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Display Table Laptop");
                Console.WriteLine("2: Display Table Desktop");
                Console.WriteLine("3: Display Table Tablet");
                Console.WriteLine("0: Return to main menu");
                Console.Write("> ");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        db.DisplayTable(DB.Table.LAPTOP);
                        break;
                    case "2":
                        db.DisplayTable(DB.Table.DESKTOP);
                        break;
                    case "3":
                        db.DisplayTable(DB.Table.TABLET);
                        break;
                    case "0":
                        Console.WriteLine("Returning to the main menu");
                        break;
                    default:
                        Console.WriteLine
                            ($"Selection \"{selection}\" is not understood.");
                        break;
                }
            } while (!selection.Equals("0"));
        }

        public static void Main()
        {
            DB db = new();
            string selection;
            Console.WriteLine("\tInventory Management System");

            do
            {
                Console.WriteLine("Selections:");
                Console.WriteLine("1: Add New Part");
                Console.WriteLine("2: Delete Part");
                Console.WriteLine("3: Get Part By Number And Type");
                Console.WriteLine("4: Display A Table");
                Console.WriteLine("0: Exit");
                Console.Write("> ");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        AddPart(db);
                        break;
                    case "2":
                        DeletePart(db);
                        break;
                    case "3":
                        GetPart(db);
                        break;
                    case "4":
                        DisplayTable(db);
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        break;
                }
            } while (!selection.Equals("0"));
        }
    }
}
