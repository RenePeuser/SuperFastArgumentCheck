using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassAnonym
    {
        public string Name { get; }

        public TestClassAnonym(string name)
        {
            Expect.NotNullAnonym(new { name });

            Name = name;
        }
    }
}