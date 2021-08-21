// Part.cs

namespace Classing
{
    public interface IPart
    {
        // part number/serial number
        public int getPartNumber();
        public void setPartNumber(int pn);

        // monitor, keyboard, etc
        public string getModel();
        public void setModel(string m);

        // company name/supplier
        public string getManufacturer();
        public void setManufacturer(string m);

        // display all information about a part object
        public void display();
    }
}
