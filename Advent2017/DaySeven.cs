using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DaySeven
    {
        public static string SolvePartOne(string[] input)
        {
            List<node> nodes = new List<node>();

            foreach(string s in input)
            {
                node n = new node();
                n.nodes = nodes;
                n.name = s.Substring(0, s.IndexOf(' '));
                var w = s.Substring(s.IndexOf('(') + 1, s.IndexOf(')') - 1 - s.IndexOf('('));
                n.weight = int.Parse(w);
                if (s.Contains("->"))
                {
                    foreach (string c in s.Substring(s.IndexOf('>') + 1).Split(','))
                    {
                        n.children.Add(c.Trim());
                    }
                }
                nodes.Add(n);
            }

            return nodes.First(n => n.parent == null).name;
        }

        public static string SolvePartTwo(string[] input)
        {
            Dictionary<string, node> nodes = new Dictionary<string, node>();

            foreach(string s in input)
            {
                var name = s.Substring(0, s.IndexOf(' '));
                var weight = int.Parse(s.Substring(s.IndexOf('(') + 1, s.IndexOf(')') - 1 - s.IndexOf('(')));

                node n;
                if(nodes.ContainsKey(name))
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
                        n.children.Add(c.Trim());
                    }
                }

                n.parent = nodes.FirstOrDefault(p => p.Value.children.Contains(n));
            }


            var root = nodes.First(n => n.parent == null);
            
        }

        private int calculateWeight(node n)
        {
            return n.weight + n.nodes.Where(c => c.parent == n).Sum(c => calculateWeight(c));
        }

        private bool isBalanced(node n)
        {
            return n.nodes.Where(c => c.parent == n).GroupBy(c => calculateWeight(c)).Count() == 1;
        }


        public class node
        {
            public List<node> nodes;
            public string name;
            public int weight;
            public node parent
            {
                get
                {
                    return nodes.FirstOrDefault(n => n.children.Contains(name));
                }
            }
            public List<string> children = new List<string>();
        }

    }
}
