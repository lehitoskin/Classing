// Main.cs
using System;

namespace Classing
{
    class Program
    {
        // TODO: delete part helper function (int pn, DB.Table table)
        // TODO: get part helper function (int pn, DB.Table table)
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
            } while (selection != "0");
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
                Console.WriteLine("4: List A Table");
                Console.WriteLine("0: Exit");
                Console.Write("> ");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        AddPart(db);
                        break;
                    case "2":
                        Console.WriteLine("Found string \"2\"");
                        break;
                    case "3":
                        Console.WriteLine("Found string \"3\"");
                        break;
                    case "4":
                        Console.WriteLine("Found string \"4\"");
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        break;
                }
            } while (selection != "0");
        }
    }
}
