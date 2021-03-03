using BotFramework.Framework.Location;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Framework.Pathfinding
{
    /// <summary>
    /// Template method for finding best tour through a graph, focuses on TSP solutions.
    /// </summary>
    /// 
    /// <typeparam name="T">Type of nodes</typeparam>
    abstract class TourGenerator<T>
    {
        private T _start;
        private List<T> _items;
        private List<T> _ordered;

        public TourGenerator()
        {
            this._items = new List<T>();
        }

        public void SetStart(T start)
        {
            this._start = start;
        }

        public void SetItems(List<T> items)
        {
            this._items = items;
        }

        public List<T> GetTour()
        {
            return this._ordered;
        }

        /// <summary>
        /// Returns close to best found tour, traveling through all points.
        /// </summary>
        /// 
        /// <param name="items"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public void Compute()
        {
            this._ordered = new List<T>();

            int[,] costMatrix = this.GenerateCostMatrix();
            int nodes = costMatrix.GetLength(0);

            // Utilizing TSP greedy

            int counter = 0;
            int j = 0;
            int i = 0;
            int min = int.MaxValue;

            List<int> visitedRouteList = new List<int>();

            visitedRouteList.Add(0);
            int[] route = new int[costMatrix.Length];

            while (i < costMatrix.GetLength(0) && j < costMatrix.GetLength(1))
            {
                if (counter >= costMatrix.GetLength(0) - 1)
                {
                    break;
                }

                if (j != i && !(visitedRouteList.Contains(j)))
                {
                    if (costMatrix[i, j] < min)
                    {
                        min = costMatrix[i, j];
                        route[counter] = j + 1;
                    }
                }
                j++;

                if (j == costMatrix.GetLength(0))
                {
                    min = int.MaxValue;
                    visitedRouteList.Add(route[counter] - 1);

                    j = 0;
                    i = route[counter] - 1;
                    counter++;
                }
            }

            foreach (int index in visitedRouteList)
            {
                this._ordered.Add(this._items[index - 1]);
            }
        }

        /// <summary>
        /// Generates a matrix depicting the cost of traveling from each node to every other node.
        /// </summary>
        /// 
        /// <returns>Cost matrix</returns>
        protected abstract int[,] GenerateCostMatrix();

        
        //protected static int[,] GenerateCostMatrix(List<T> nodes)
        //{
        //    int[,] costMatrix = new int[nodes.Count, nodes.Count];
        //}

        //private void SanitizeData()
        //{
        //    foreach (dynamic item in this._items)
        //    {
        //        if (item is ActionableGroup)
        //        {
        //            Point centroid = ((ActionableGroup)item).GetCentroid();
        //            Tile containedCenter = ((ActionableGroup)item).GetClosestTile(centroid);

        //            this._nodes.Add(containedCenter.GetPoint());
        //        }
        //        else if (item is Tile)
        //        {
        //            this._nodes.Add(((Tile)item).GetPoint());
        //        }
        //        else if (item is Point)
        //        {
        //            this._nodes.Add(item);
        //        }
        //        else
        //        {
        //            throw new Exception($"PathGenerator can only handle types Point, Tile and TileGroup, not {typeof(T)}");
        //        }
        //    }
        //}
    }
}
