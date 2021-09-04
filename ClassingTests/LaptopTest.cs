// LaptopTest.cs
// to use outside namespaces, right-click on test project
// and choose Add -> Reference -> Check project name
// and then you can do 'using Classing;'
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classing;

namespace ClassingTests
{
    [TestClass]
    public class LaptopTest
    {
        [TestMethod]
        public void Setters()
        {
            int old_pn = 0;
            int new_pn = 1;

            string old_model = "MBP";
            string new_model = "Xtreme";

            string old_man = "Apple";
            string new_man = "Acer";

            string old_os = "macOS";
            string new_os = "Windows 10";

            int old_size = 16;
            int new_size = 17;

            Laptop laptop = new(old_pn, old_model, old_man, old_os, old_size);

            Assert.AreEqual(old_pn, laptop.GetPartNumber());
            Assert.AreEqual(old_model, laptop.GetModel());
            Assert.AreEqual(old_man, laptop.GetManufacturer());
            Assert.AreEqual(old_os, laptop.GetOS());
            Assert.AreEqual(old_size, laptop.GetSize());

            laptop.SetPartNumber(new_pn);
            laptop.SetModel(new_model);
            laptop.SetManufacturer(new_man);
            laptop.SetOS(new_os);
            laptop.SetSize(new_size);

            Assert.AreEqual(new_pn, laptop.GetPartNumber());
            Assert.AreEqual(new_model, laptop.GetModel());
            Assert.AreEqual(new_man, laptop.GetManufacturer());
            Assert.AreEqual(new_os, laptop.GetOS());
            Assert.AreEqual(new_size, laptop.GetSize());
        }
    }
}
