using System;

namespace SuperFastArgumentCheckTest
{
    public class TestClassStandard
    {
        public string Name { get; }

        public TestClassStandard(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }
    }
}