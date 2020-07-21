using System.Collections.Generic;

namespace TreeGenerator
{
    internal class Generator
    {
        private static string[] keys = new[] {"x", "y"};

        private static object GenTree(int level)
        {
            if (level == 0) return "1";
            var t = new Tree();
            foreach (var k in keys) t[k] = GenTree(level - 1);
            return t;
        }

        private static IEnumerable<string> Subset(string[] keys, int bits)
        {
            for (var i = 0; i < keys.Length; i++)
                if ((bits & (1 << i)) != 0)
                    yield return keys[i];
        }

        // return all subset of keys
        private static IEnumerable<IEnumerable<string>> GenKeys(params string[] keys)
        {
            var N = 1 << keys.Length;
            for (var bits = 0; bits < N; bits++) yield return Subset(keys, bits);
        }

        private static IEnumerable<object> Gen(int i)
        {
            if (i == 0)
            {
                yield return "a";
                yield return "b";
            }

            if (i == 1)
            {
                foreach (var t in Gen(0)) yield return t;

                foreach (var keys in GenKeys())
                {
                    var tree = new Tree();
                    foreach (var key in keys) tree[key] = 1;
                    yield return tree;
                }
            }
        }
    }
}