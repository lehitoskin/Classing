// Tablet.cs
using System;
namespace Classing
{
    public class Tablet : Computer
    {
        private int size;
        private Boolean stylus;

        public Tablet(int pn, string model, string man, string os, int s,
            Boolean stylus) : base(pn, model, man, os)
        {
            size = s;
            this.stylus = stylus;
        }

        public int GetSize() { return size; }
        public void SetSize(int s) { size = s; }

        public Boolean GetStylus() { return stylus; }
        public void SetStylus(Boolean s) { stylus = s; }

        public override void Display()
        {
            Console.WriteLine("Tablet:");
            base.Display();
            Console.WriteLine("Size (inches) {0}", size);
            Console.WriteLine("Has a stylus? {0}", stylus);
        }
    }
}
