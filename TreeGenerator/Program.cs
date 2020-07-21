using System;
using System.Collections.Generic;

namespace TreeGenerator
{
    internal class Program
    {
        private static IEnumerable<object> GenerateAllPossibleTree(string[] keys, object[] values, int depth)
        {
            throw new NotImplementedException("We need more brains");
        }

        private static void Main(string[] args)
        {
            var listOfSubsetOfKeys = Generator.GenKeys("x", "y");
            Console.Write(listOfSubsetOfKeys.ToJson());
            Console.ReadLine();
        }
    }
}