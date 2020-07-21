using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeGenerator
{
    internal class Generator
    {
        // share children instance or not?
        public static object Clone(object src)
        {
            return src;
        }

        public static IEnumerable<Tree> MapKeyValue(string[] keys, object[] values)
        {
            int N = (int)Math.Pow(values.Length, keys.Length);
            for (int i = 0; i < N; i++)
            {
                var tree = new Tree();
                var ii = i;
                for (int j = 0; j < keys.Length; j++)
                {
                    tree[keys[j]] = Clone(values[ii % values.Length]);
                    ii /= values.Length;
                }

                yield return tree;
            }
        }

        private static IEnumerable<string> Subset(string[] keys, int bits)
        {
            for (var i = 0; i < keys.Length; i++)
                if ((bits & (1 << i)) != 0)
                    yield return keys[i];
        }

        public static IEnumerable<string[]> GenKeys(params string[] keys)
        {
            var N = 1 << keys.Length;
            for (var bits = 0; bits < N; bits++) yield return Subset(keys, bits).ToArray();
        }

        public static IEnumerable<object> Gen(string[] keys, object[] values, int depth)
        {
            if (depth == 0)
            {
                foreach (var value in values)
                {
                    yield return value;
                }
                yield break;
            }

            var childValues = Gen(keys, values, depth - 1).ToArray();

            foreach (var child in childValues)
            {
                yield return child;
            }

            foreach (var childKeys in GenKeys(keys))
            {
                foreach (var child in MapKeyValue(childKeys, childValues))
                {
                    yield return child;
                }
            }
        }

    }
}