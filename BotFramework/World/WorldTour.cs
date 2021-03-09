using BotFramework.Locations;
using BotFramework.Structures;
using BotFramework.TemplateMethods;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotFramework.World
{
    /// <summary>
    /// Find shortest tour through locations.
    /// </summary>
    /// <remarks>
    /// Implements template method <see cref="TourTemplate{LocationParser}">TemplateMethods.TourTemplate</see>.
    /// </remarks>
    class WorldTour : TourTemplate<ILocationParser>
    {
        private Graph<ILocationParser> _graph;

        protected override int[,] GenerateCostMatrix()
        {
            this._graph = new Graph<ILocationParser>();

            // All found managed manually
            bool allFound = false;

            // Initialize matrix
            int[,] costMatrix = new int[this._items.Count, this._items.Count];

            for (int i = 0; i < this._items.Count; i++)
            {
                for (int j = 0; j < this._items.Count; j++)
                {
                    if (i == j)
                    {
                        costMatrix[i, j] = -1;
                    } else
                    {
                        costMatrix[i, j] = int.MaxValue;
                    }
                }
            }

            // Queue for breadth-first search
            // To, From, Cost
            Queue<Tuple<ILocationParser, ILocationParser, int>> queue = new Queue<Tuple<ILocationParser, ILocationParser, int>>();
            IList<string> visited = new List<string>();

            // Add current location
            queue.Enqueue(new Tuple<ILocationParser, ILocationParser, int>(this._items[0], null, 0));

            // Find all locations needed
            while (!allFound && queue.Count > 0)
            {
                // Pop an item
                Tuple<ILocationParser, ILocationParser, int> current = queue.Dequeue();

                ILocationParser to = current.Item1;
                ILocationParser from = current.Item2;
                int cost = current.Item3;

                // If visited continue
                if (visited.Contains(to.GetName()))
                {
                    continue;
                } else
                {
                    visited.Add(to.GetName());
                }

                int index = this._items.IndexOf(to);
                int fromIndex = this._items.IndexOf(from);

                // Populate Graph
                this._graph.AddNode(to.GetName(), to);
                if (from != null)
                {
                    this._graph.AddEdge(from.GetName(), to.GetName());
                }

                if (index == -1)
                {
                    // Not on our list, add connections
                    IList<Warp> connections = to.GetWarps();

                    foreach (Warp connection in connections)
                    {
                        ILocationParser locationParser = new LocationParser(connection.TargetName);
                        queue.Enqueue(new Tuple<ILocationParser, ILocationParser, int>(locationParser, from, cost + 1));
                    }
                } else
                {
                    if (fromIndex != -1)
                    {
                        // Add all values from parent + 1
                        for (int i = 0; i < this._items.Count(); i++)
                        {
                            if (i != index)
                            {
                                if (i == fromIndex)
                                {
                                    costMatrix[i, index] = cost;
                                    costMatrix[index, i] = cost;
                                }
                                else if (costMatrix[i, fromIndex] != int.MaxValue)
                                {
                                    costMatrix[i, index] = costMatrix[i, fromIndex] + cost;
                                    costMatrix[index, i] = costMatrix[i, fromIndex] + cost;
                                }
                            }
                        }
                    }

                    // Enqueue all connections
                    IList<Warp> connections = to.GetWarps();

                    foreach (Warp connection in connections)
                    {
                        ILocationParser locationParser = new LocationParser(connection.TargetName);
                        queue.Enqueue(new Tuple<ILocationParser, ILocationParser, int>(locationParser, to, 1));
                    }

                    allFound = true;
                    foreach (int distance in costMatrix)
                    {
                        if (distance == int.MaxValue)
                        {
                            allFound = false;
                            break;
                        }
                    }
                }
            }

            return costMatrix;
        }

        public Graph<ILocationParser> GetGraph()
        {
            return this._graph;
        }
    }
}
