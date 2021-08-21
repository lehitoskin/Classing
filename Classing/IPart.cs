// Part.cs

namespace Classing
{
    public interface IPart
    {
        // part number/serial number
        public int GetPartNumber();
        public void SetPartNumber(int pn);

        // monitor, keyboard, etc
        public string GetModel();
        public void SetModel(string m);

        // company name/supplier
        public string GetManufacturer();
        public void SetManufacturer(string m);

        // display all information about a part object
        public void Display();
    }
}
