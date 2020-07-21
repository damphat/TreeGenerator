using System.Collections.Generic;

namespace TreeGenerator
{
    public partial class Tree : Dictionary<string, object>
    {
        public override string ToString()
        {
            return this.ToJson();
        }
    }
}