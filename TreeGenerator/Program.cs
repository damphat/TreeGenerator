using System;
using System.Collections.Generic;

namespace TreeGenerator
{
    internal class Program
    {
        /// <summary>
        /// Not Implemented
        /// </summary>
        static IEnumerable<object> GenerateAllPossibleTree(string[] keys, object[] values, int depth)
        {
            yield return 1;
            yield return 2;
            yield return new Tree {{"x", 1}, {"y", 2}};

        }

        private static void Main(string[] args)
        {
            var keys = new string[] {"x", "y"};
            var values = new object[] {1, 2};
            var depth = 2;

            foreach (var tree in GenerateAllPossibleTree(keys, values, depth))
            {
                Console.WriteLine(tree.ToJson());
            }

            Console.ReadLine();
        }
    }
}