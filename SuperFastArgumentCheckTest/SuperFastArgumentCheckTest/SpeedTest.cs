using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperFastArgumentCheckTest
{
    [TestClass]
    public class SpeedTest
    {
        private const int counter = 100000;

        [TestMethod]
        public void InterateStandard()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassStandard(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExpect()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassStandard(i.ToString());
            }
        }

        [TestMethod]
        public void InterateExtended()
        {
            for (int i = 0; i < counter; i++)
            {
                var result = new TestClassExtended(i.ToString());
            }
        }
    }
}