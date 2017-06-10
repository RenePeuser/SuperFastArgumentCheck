using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassExpected
    {
        public string Name { get; }

        public TestClassExpected(string name)
        {
            Expect.NotNull(name);

            Name = name;
        }
    }
}