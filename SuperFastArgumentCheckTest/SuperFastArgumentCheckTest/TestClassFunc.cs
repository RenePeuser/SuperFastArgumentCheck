using SuperFastArgumentCheck;

namespace SuperFastArgumentCheckTest
{
    public class TestClassFunc
    {
        public string Arg0 { get; }
        public string Arg1 { get; }
        public string Arg2 { get; }
        public string Arg3 { get; }

        public TestClassFunc(string arg0, string arg1, string arg2, string arg3)
        {
            Expect.NotNull(() => arg0);
            Expect.NotNull(() => arg1);
            Expect.NotNull(() => arg2);
            Expect.NotNull(() => arg3);

            Arg0 = arg0;
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
        }
    }
}