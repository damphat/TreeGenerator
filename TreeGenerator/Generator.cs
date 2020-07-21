using System.Collections.Generic;
using System.Linq;

namespace TreeGenerator
{
    internal class Generator
    {
        public static IEnumerable<object> GenTree0(object[] values)
        {
            foreach (var value in values)
            {
                yield return value;
            }
        }

        private static IEnumerable<string> Subset(string[] keys, int bits)
        {
            for (var i = 0; i < keys.Length; i++)
                if ((bits & (1 << i)) != 0)
                    yield return keys[i];
        }

        public static IEnumerable<IEnumerable<string>> GenKeys(params string[] keys)
        {
            var N = 1 << keys.Length;
            for (var bits = 0; bits < N; bits++) yield return Subset(keys, bits).ToList();
        }

    }
}