using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassOnlyOneArgument
    {
        public string Name { get; }

        public TestClassOnlyOneArgument(string name)
        {
            Name = name.NotNullOneParam();
        }
    }
}