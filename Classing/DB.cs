// DB.cs
// ref https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli
using System;
using Microsoft.Data.Sqlite;

namespace Classing
{
    public class DB
    {
        private readonly SqliteConnection conn;
        public enum Table { LAPTOP, DESKTOP, TABLET }

        public DB()
        {
            // placed in Classing/bin/Debug/net5.0/ by Visual Studio
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
                  string);

                  create table if not exists Tablet(PartNumber int primary key,
                  Model string, Manufacturer string, OS string, Size int,
                  Stylus boolean);";

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; Init() ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; Init() SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; Init() System.InvalidOperationException");
            }
        }

        // save DB to disk and close connection
        ~DB() { conn.Close(); }

        public void DisplayTable(Table table)
        {
            using var cmd = conn.CreateCommand();

            if (table == Table.LAPTOP)
                cmd.CommandText = "select * from Laptop;";
            else if (table == Table.DESKTOP)
                cmd.CommandText = "select * from Desktop;";
            else if (table == Table.TABLET)
                cmd.CommandText = "select * from Tablet;";

            // TODO: prettier printing
            try
            {
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
                    else if (table == Table.TABLET)
                    {
                        int size = reader.GetInt32(4);
                        Boolean stylus = reader.GetBoolean(5);
                        Console.WriteLine($"PartNumber {pn}");
                        Console.WriteLine($"Model {model}");
                        Console.WriteLine($"Manufacturer {manufacturer}");
                        Console.WriteLine($"OS {os}");
                        Console.WriteLine($"Size (inches) {size}");
                        Console.WriteLine($"Has stylus? {stylus}");
                        Console.WriteLine();
                    }
                }
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; DisplayTable() SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; DisplayTable() System.InvalidOperationException");
            }
        }

        // drop tables and then re-add them as empty
        public void ResetDatabase()
        {
            using var cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = "drop table if exists Laptop;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "drop table if exists Desktop;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "drop table if exists Tablet;";
                cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; ResetDatabase() SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; ResetDatabase() System.InvalidOperationException");
            }

            Init();
        }

        public void AddPart(Laptop l)
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

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; AddPart(Laptop) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Laptop) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Laptop) System.InvalidOperationException");
            }
        }

        public void AddPart(Desktop d)
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

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; AddPart(Desktop) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Desktop) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Desktop) System.InvalidOperationException");
            }
        }

        public void AddPart(Tablet t)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"insert into Tablet(PartNumber, Model, Manufacturer, OS, Size,
                  Stylus)
                  values($pn, $model, $manufacturer, $os, $size, $stylus);";
            cmd.Parameters.AddWithValue("$pn", t.GetPartNumber());
            cmd.Parameters.AddWithValue("$model", t.GetModel());
            cmd.Parameters.AddWithValue("$manufacturer", t.GetManufacturer());
            cmd.Parameters.AddWithValue("$os", t.GetOS());
            cmd.Parameters.AddWithValue("$size", t.GetSize());
            cmd.Parameters.AddWithValue("$stylus", t.GetStylus());

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; AddPart(Tablet) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Tablet) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; AddPart(Tablet) System.InvalidOperationException");
            }
        }

        public void DeletePart(Laptop l)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Laptop where PartNumber = $pn;";
            cmd.Parameters.AddWithValue("$pn", l.GetPartNumber());

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; DeletePart(Laptop) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Laptop) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Laptop) System.InvalidOperationException");
            }
        }

        public void DeletePart(Desktop d)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Desktop where PartNumber = $pn;";
            cmd.Parameters.AddWithValue("$pn", d.GetPartNumber());

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; DeletePart(Desktop) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Desktop) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Desktop) System.InvalidOperationException");
            }
        }

        public void DeletePart(Tablet t)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Tablet where PartNumber = $pn;";
            cmd.Parameters.AddWithValue("$pn", t.GetPartNumber());

            try
            {
                int ret = cmd.ExecuteNonQuery();
                Console.WriteLine($"DEBUG; DeletePart(Tablet) ret: {ret}");
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Tablet) SQLiteException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; DeletePart(Tablet) System.InvalidOperationException");
            }
        }

        public IPart GetPart(Table table, int pn)
        {
            using var cmd = conn.CreateCommand();

            try
            {
                if (table == Table.LAPTOP)
                {
                    cmd.CommandText =
                    "select * from Laptop where PartNumber = $pn";
                    cmd.Parameters.AddWithValue("$pn", pn);

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
                    "select * from Desktop where PartNumber = $pn";
                    cmd.Parameters.AddWithValue("$pn", pn);

                    using var reader = cmd.ExecuteReader();
                    reader.Read();
                    string model = reader.GetString(1);
                    string manufacturer = reader.GetString(2);
                    string os = reader.GetString(3);
                    string[] peripherals = reader.GetString(4).Split(", ");

                    return new
                        Desktop(pn, model, manufacturer, os, peripherals);
                }
                else if (table == Table.TABLET)
                {
                    cmd.CommandText = "select * from Tablet where PartNumber = $pn";
                    cmd.Parameters.AddWithValue("$pn", pn);

                    using var reader = cmd.ExecuteReader();
                    reader.Read();
                    string model = reader.GetString(1);
                    string manufacturer = reader.GetString(2);
                    string os = reader.GetString(3);
                    int size = reader.GetInt32(4);
                    Boolean stylus = reader.GetBoolean(5);

                    return new
                        Tablet(pn, model, manufacturer, os, size, stylus);
                }
            }
            catch (SqliteException)
            {
                Console.WriteLine
                    ("ERROR; GetPart() SQLiteException encountered!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine
                    ("ERROR; GetPart() System.InvalidOperationException");
            }
            return null;
        }
    }
}
