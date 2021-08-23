// DB.cs
// ref https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli
using System;
using Microsoft.Data.Sqlite;

namespace Classing
{
    public class DB
    {
        private readonly SqliteConnection conn;
        public enum Table { LAPTOP, DESKTOP }

        public DB()
        {
            conn = new SqliteConnection("Data Source=inventory.sqlite");
            conn.Open();
            Init();
        }

        // initialize DB if necessary
        private void Init()
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"create table if not exists Laptop(PartNumber int primary key,
                  Model string, Manufacturer string, OS string, Size int);

                  create table if not exists Desktop(PartNumber int primary key,
                  Model string, Manufacturer string, OS string, Peripherals
                  string);";
            int ret = cmd.ExecuteNonQuery();
            Console.WriteLine($"DEBUG; ret: {ret}");
        }

        ~DB() { conn.Close(); }

        public void DisplayTable(Table table)
        {
            using var cmd = conn.CreateCommand();

            if (table == Table.LAPTOP)
                cmd.CommandText = "select * from Laptop;";
            else if (table == Table.DESKTOP)
                cmd.CommandText = "select * from Desktop;";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int pn = reader.GetInt32(0);
                string model = reader.GetString(1);
                string manufacturer = reader.GetString(2);
                string os = reader.GetString(3);

                if (table == Table.LAPTOP)
                {
                    int size = reader.GetInt32(4);
                    Console.WriteLine($"PartNumber {pn}");
                    Console.WriteLine($"Model {model}");
                    Console.WriteLine($"Manufacturer {manufacturer}");
                    Console.WriteLine($"OS {os}");
                    Console.WriteLine($"Size (inches) {size}");
                    Console.WriteLine();
                }
                else if (table == Table.DESKTOP)
                {
                    string peripherals = reader.GetString(4);
                    Console.WriteLine($"PartNumber {pn}");
                    Console.WriteLine($"Model {model}");
                    Console.WriteLine($"Manufacturer {manufacturer}");
                    Console.WriteLine($"OS {os}");
                    Console.WriteLine($"Peripherals [{peripherals}]");
                    Console.WriteLine();
                }
            }
        }

        // drop tables and then re-add them as empty
        public void ResetDatabase()
        {
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "drop table if exists Laptop;";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "drop table if exists Desktop;";
            cmd.ExecuteNonQuery();

            Init();
        }

        public void AddLaptop(Laptop l)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"insert into Laptop(PartNumber, Model, Manufacturer, OS, Size)
                  values($pn, $model, $manufacturer, $os, $size);";
            cmd.Parameters.AddWithValue("$pn", l.GetPartNumber());
            cmd.Parameters.AddWithValue("$model", l.GetModel());
            cmd.Parameters.AddWithValue("$manufacturer", l.GetManufacturer());
            cmd.Parameters.AddWithValue("$os", l.GetOS());
            cmd.Parameters.AddWithValue("$size", l.GetSize());
            int ret = cmd.ExecuteNonQuery();
            Console.WriteLine($"DEBUG; ret: {ret}");
        }

        public void AddDesktop(Desktop d)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"insert into Desktop(PartNumber, Model, Manufacturer, OS,
                  Peripherals)
                  values($pn, $model, $manufacturer, $os, $peripherals);";
            cmd.Parameters.AddWithValue("$pn", d.GetPartNumber());
            cmd.Parameters.AddWithValue("$model", d.GetModel());
            cmd.Parameters.AddWithValue("$manufacturer", d.GetManufacturer());
            cmd.Parameters.AddWithValue("$os", d.GetOS());
            cmd.Parameters.AddWithValue("$peripherals",
                string.Join(", ", d.GetPeripherals()));
            int ret = cmd.ExecuteNonQuery();
            Console.WriteLine($"DEBUG; ret: {ret}");
        }

        public void DeleteLaptop(Laptop l)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Laptop where PartNumber = $pn;";
            cmd.Parameters.AddWithValue("$pn", l.GetPartNumber());
            int ret = cmd.ExecuteNonQuery();
            Console.WriteLine($"DEBUG; DeleteLaptop ret: {ret}");
        }

        public void DeleteDesktop(Desktop d)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Desktop where PartNumber = $pn;";
            cmd.Parameters.AddWithValue("$pn", d.GetPartNumber());
            int ret = cmd.ExecuteNonQuery();
            Console.WriteLine($"DEBUG; DeleteDesktop ret: {ret}");
        }

        public Computer GetComputer(Table table, int pn)
        {
            using var cmd = conn.CreateCommand();

            if (table == Table.LAPTOP)
            {
                cmd.CommandText =
                    "select from Laptop where ProductNumber = $pn";
                // TODO:
                // error handling when there is no db entry for pn
                using var reader = cmd.ExecuteReader();
                reader.Read();
                string model = reader.GetString(1);
                string manufacturer = reader.GetString(2);
                string os = reader.GetString(3);
                int size = reader.GetInt32(4);

                return new Laptop(pn, model, manufacturer, os, size);
            }
            else if (table == Table.DESKTOP)
            {
                cmd.CommandText =
                    "select from Desktop where ProductNumber = $pn";
                // TODO:
                // error handling when there is no db entry for pn
                using var reader = cmd.ExecuteReader();
                reader.Read();
                string model = reader.GetString(1);
                string manufacturer = reader.GetString(2);
                string os = reader.GetString(3);
                string[] peripherals = reader.GetString(4).Split(", ");

                return new Desktop(pn, model, manufacturer, os, peripherals);
            }
            else return null;
        }
    }
}
