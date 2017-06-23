namespace SuperFastArgumentCheck
{
    public class ArgumentTestClass
    {
        public object Cloneable { get; }
        public string Name { get; }
        public int Age { get; }

        public ArgumentTestClass(object cloneable, string name, string something, int age)
        {
            Expect.NotNull(() => cloneable);

            Expect.NotNull(() => name);
            Expect.IsEmpty(() => name);
            Expect.IsWhitespace(() => name);

            Expect.NotNull(() => something);
            Expect.IsEmpty(() => something);
            Expect.IsWhitespace(() => something);

            Expect.IsOutOfRange(() => age, 5, 10);

            Cloneable = cloneable;
            Name = name;
            Age = age;
        }
    }
}
