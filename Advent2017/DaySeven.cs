using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent2017
{
    class DaySeven
    {
        public static string SolvePartOne(string[] input)
        {
            Dictionary<string, node> nodes = getNodeList(input);

            return nodes.First(n => n.Value.parent == null).Value.name;
        }

        private static Dictionary<string, node> getNodeList(string[] input)
        {
            Dictionary<string, node> nodes = new Dictionary<string, node>();

            foreach (string s in input)
            {
                var name = s.Substring(0, s.IndexOf(' '));
                var weight = int.Parse(s.Substring(s.IndexOf('(') + 1, s.IndexOf(')') - 1 - s.IndexOf('(')));

                node n;
                if (nodes.ContainsKey(name))
                {
                    nodes[name].weight = weight;
                    n = nodes[name];
                }
                else
                {
                    n = new node() { name = name, weight = weight };
                    nodes.Add(n.name, n);
                }

                if (s.Contains("->"))
                {
                    foreach (string c in s.Substring(s.IndexOf('>') + 1).Split(','))
                    {
                        n.childStrings.Add(c.Trim());
                        if (nodes.ContainsKey(c.Trim()))
                        {
                            n.children.Add(nodes[c.Trim()]);
                            nodes[c.Trim()].parent = n;
                        }
                    }
                }

                n.parent = nodes.FirstOrDefault(p => p.Value.childStrings.Contains(n.name)).Value;

                foreach (node pn in nodes.Values)
                {
                    if (pn.childStrings.Contains(n.name) && !pn.children.Contains(n))
                    {
                        pn.children.Add(n);
                    }
                }
            }

            return nodes;
        }

        public static int SolvePartTwo(string[] input)
        {
            Dictionary<string, node> nodes = getNodeList(input);

            //find the unbalanced node
            node unbalancedNode = new node();
            foreach(node n in nodes.Values)
            {
                if(!n.isBalanced && n.children.Count(c => c.isBalanced) == n.children.Count && n.children.Count > 0)
                {
                    // the parent isn't balanced, but all of the children are, so this node must have the incorrect weight.
                    unbalancedNode = n;
                }
            }

            var groups = unbalancedNode.children.GroupBy(c => c.totalWeight);

            var badWeight = groups.First(g => g.Count() == 1).First().weight;
            var offset = groups.First(g => g.Count() == 1).First().totalWeight - groups.First(g => g.Count() != 1).First().totalWeight;
            return badWeight - offset;
        }

        public class node
        {
            public string name;
            public int weight;
            public node parent;
            public List<node> children = new List<node>();
            public List<string> childStrings = new List<string>();

            public bool isBalanced
            {
                get
                {
                    return children.GroupBy(c => c.totalWeight).Count() == 1;
                }
            }

            public int totalWeight
            {
                get
                {
                    return weight + children.Sum(c => c.totalWeight);
                }
            }
        }

    }
}
