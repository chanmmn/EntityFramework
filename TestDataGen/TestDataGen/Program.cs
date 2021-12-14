using System;

namespace TestDataGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string name = Faker.Name.FullName();
        }
    }
}
