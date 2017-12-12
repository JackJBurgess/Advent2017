using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;

namespace Advent2017
{
    public class DayTwelve
    {
        public static List<string> connectedNodes = new List<string>();

        public static int SolvePartOne(string[] input)
        {
            Dictionary<string, List<string>> nodes = new Dictionary<string, List<string>>();
            foreach (string line in input)
            {
                var first = line.Split(' ')[0].Trim();
                var children = line.Substring(line.IndexOf('>') + 1).Split(',').Select(s => s.Trim()).ToList();
                if (!nodes.ContainsKey(first))
                {
                    nodes.Add(first, children);
                }
                else
                {
                    nodes[first].AddRange(children.Where(c => !nodes[first].Contains(c)));
                }

                foreach (string child in children)
                {
                    if (!nodes.ContainsKey(child))
                    {
                        nodes.Add(child, new List<string>(){first});
                    }
                }
            }


            fillConnectedNodes(nodes, "0");
            return connectedNodes.Count();
        }

        public static void fillConnectedNodes(Dictionary<string,List<string>> nodes, string start)
        {
            if (!connectedNodes.Contains(start))
            {
                connectedNodes.Add(start);
                foreach (string s in nodes[start])
                {
                    fillConnectedNodes(nodes, s);
                }
            }
        }

        public static int SolvePartTwo(string[] input)
        {
            Dictionary<string, List<string>> nodes = new Dictionary<string, List<string>>();
            foreach (string line in input)
            {
                var first = line.Split(' ')[0].Trim();
                var children = line.Substring(line.IndexOf('>') + 1).Split(',').Select(s => s.Trim()).ToList();
                if (!nodes.ContainsKey(first))
                {
                    nodes.Add(first, children);
                }
                else
                {
                    nodes[first].AddRange(children.Where(c => !nodes[first].Contains(c)));
                }

                foreach (string child in children)
                {
                    if (!nodes.ContainsKey(child))
                    {
                        nodes.Add(child, new List<string>() { first });
                    }
                }
            }

            var groups = 0;
            var nodeList = new List<string>();
            var start = "0";
            while (nodeList.Count() < nodes.Count)
            {
                fillConnectedNodes(nodes, start);
                groups++;
                nodeList.AddRange(connectedNodes);
                connectedNodes.Clear();
                start = nodes.Keys.FirstOrDefault(k => !nodeList.Contains(k));
            }

            return groups;
        }

        private class Node
        {
            public string name;
            public List<string> edges;
        }
    }
}
