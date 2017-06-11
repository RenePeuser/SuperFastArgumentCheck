using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassExtended
    {
        public string Name { get; }

        public TestClassExtended(string name)
        {
            Name = name.NotNull();
        }
    }
}