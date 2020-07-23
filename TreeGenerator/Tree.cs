using System;
using System.Collections.Generic;

namespace TreeGenerator
{
    public class Tree : Dictionary<string, object>, IEquatable<Tree>
    {
        public override string ToString()
        {
            return this.ToJson();
        }

        public bool Equals(Tree tree)
        {
            if (tree == null) return false;
            if (this.Count != tree.Count) return false;
            foreach (var (k, v) in this)
            {
                if (!Equals(tree[k], v)) return false;
            }

            return true;
        }

        // Do not compare child-order
        public override bool Equals(object obj)
        {
            return obj is Tree tree && Equals(tree);
        }

        // Do not compare child-order
        // note: do not mutate the tree after GetHashCode()
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 113;
                foreach (var (k, v) in this)
                {
                    hash += (k.GetHashCode()*17 ^ v.GetHashCode());
                }

                return hash;
            }
        }
    }
}