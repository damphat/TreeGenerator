using System;
using System.Linq;

namespace TreeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var keys = new[] {"x", "y"};
            var values = new object[] {1, 2};
            var depth = 2;
            
            Console.WriteLine("Generating samples:");
            var all = Generator.Gen(keys, values, depth).ToList();
            foreach (var o in all) Console.WriteLine(o.ToJson(2));
            Console.ReadLine();
        }
    }
}