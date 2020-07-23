using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TreeGenerator.Tests
{
    public class TreeTests
    {
        [Fact]
        public void EqualTest()
        {
            var eq = new Tree[]
            {
                new Tree {{"x", 1}, {"y", 2}},
                new Tree {{"x", 1}, {"y", 2}},
                new Tree {{"y", 2}, {"x", 1}}
            };

            foreach (var a in eq)
            {
                foreach (var b in eq)
                {
                    Assert.Equal(a, b);
                }
            }
        }

        [Fact]
        public void DiffTest()
        {
            var diff = new Tree[]
            {
                new Tree {{"x", 1}, {"y", 2}},
                new Tree {{"x", 1}, {"y", '_'}},
                new Tree {{"x", '_'}, {"y", 2}},
                new Tree {{"_", 1}, {"y", 2}},
                new Tree {{"x", 1}, {"_", 2}},
                new Tree {{"x", 1}},
                new Tree {{"y", 2}},
                new Tree {},
            };

            foreach (var a in diff)
            {
                foreach (var b in diff)
                {
                    if (!ReferenceEquals(a, b))
                    {
                        Assert.NotEqual(a, b);
                    }
                }
            }
        }
    }
}
