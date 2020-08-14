# TreeGenerator

[![Coverage Status](https://coveralls.io/repos/github/damphat/TreeGenerator/badge.svg)](https://coveralls.io/github/damphat/TreeGenerator)

## Algorithm wanted:

* I need an algorithm to generate all possible json-tree.
* Of cause with the limitation of keys, values and depth.

Examples:

```javascript
let values = [1, 2]
let keys = ["x", "y"]
let depth = 2

// We can create some json-tree like:
// depth = 1
{ "x": 1 }
{ "x": 1, "y":2}

// depth = 2
{
    "x": 1,
    "y": {
        "x": 2,
        "y": 1
    }
}

// and many many more

```

## Why do I need that algorithm?

That will be used to generate test data for Sigobase project.