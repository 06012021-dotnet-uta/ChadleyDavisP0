using System;

namespace my_first_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How old are you (in years)?");
            string age = Console.ReadLine();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"{name} is {age} years old.");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
