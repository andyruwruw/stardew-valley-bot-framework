using BotFramework.Actions;
using BotFramework.Locations;
using BotFramework.TemplateMethods;
using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace BotFramework.World
{
    class WorldTour : TourTemplate<ILocationParser>
    {
        protected override int[,] GenerateCostMatrix()
        {
            // All found managed manually
            bool allFound = false;

            // Initialize matrix and distance array
            int[] distanceFrom = new int[this._items.Count];
            int[,] costMatrix = new int[this._items.Count, this._items.Count];

            for (int i = 0; i < this._items.Count; i++)
            {
                distanceFrom[i] = int.MaxValue;
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
            Queue<ILocationParser> queue = new Queue<ILocationParser>();
            queue.Enqueue(this._items[0]);

            // Find all locations needed
            while (!allFound)
            {
                // Pop an item
                ILocationParser current = queue.Dequeue();

                int index = this._items.IndexOf(current);

                if (index == -1 || distanceFrom[index] != int.MaxValue)
                {
                    // Visit
                    for (int i = 0; i < distanceFrom.Count(); i++)
                    {
                        if (distanceFrom[i] != int.MaxValue)
                        {
                            distanceFrom[i] = distanceFrom[i] + 1;
                        }
                    }

                    if (distanceFrom[index] != int.MaxValue)
                    {
                        distanceFrom[index] = 0;

                        for (int i = 0; i < this._items.Count; i++)
                        {
                            if (i != index && distanceFrom[i] != int.MaxValue)
                            {
                                costMatrix[i, index] = distanceFrom[i];
                                costMatrix[index, i] = distanceFrom[i];
                            }
                        }
                    }

                    IList<Warp> connections = current.GetWarps();

                    foreach (Warp connection in connections)
                    {
                        ILocationParser locationParser = new LocationParser(connection.TargetName);
                        queue.Enqueue(locationParser);
                    }

                    allFound = true;
                    foreach (int distance in distanceFrom)
                    {
                        if (distance == int.MaxValue)
                        {
                            allFound = false;
                        }
                    }
                }
            }

            return costMatrix;
        }
    }
}
