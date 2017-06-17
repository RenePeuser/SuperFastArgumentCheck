using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassExpectedOnlyOneArgument
    {
        public string Name { get; }

        public TestClassExpectedOnlyOneArgument(string name)
        {
            Expect.NotNullOneParam(name);

            Name = name;
        }
    }
}