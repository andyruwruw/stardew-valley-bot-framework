using BotFramework.Helpers;
using System.Collections.Generic;

namespace BotFramework.TemplateMethods
{
    /// <summary>
    /// Template method for finding best tour through a graph.
    /// </summary>
    /// <remarks>
    /// <para>Current TSP Greedy implementation runs in O(n^2 * log n).</para>
    /// <para>Requires the override of <see cref="TourTemplate{T}.GenerateCostMatrix">TourTemplate.GenerateCostMatrix</see>.</para>
    /// </remarks>
    /// 
    /// <typeparam name="T">Type of nodes</typeparam>
    abstract class TourTemplate<T>
    {
        /// <summary>
        /// Starting node.
        /// </summary>
        /// <remarks>
        /// Usually player current location.
        /// </remarks>
        protected T _start;

        /// <summary>
        /// List of nodes to find shortest possible tour through.
        /// </summary>
        protected IList<T> _items;

        /// <summary>
        /// List of nodes ordered by shortest possible tour.
        /// </summary>
        /// <remarks>
        /// Result of TSP Greedy after running <see cref="TourTemplate{T}.Compute">TourTemplate.Compute</see>.
        /// </remarks>
        protected IList<T> _ordered;

        /// <summary>
        /// Instantiations a new TourTemplate.
        /// </summary>
        public TourTemplate()
        {
            this._items = new List<T>();
        }

        /// <summary>
        /// Sets the starting node of tour.
        /// </summary>
        /// 
        /// <param name="start">Starting node</param>
        public void SetStart(T start)
        {
            this._start = start;
        }

        /// <summary>
        /// Sets the list of nodes to find shortest possible tour through.
        /// </summary>
        /// 
        /// <param name="items">List of nodes of any type</param>
        public void SetItems(IList<T> items)
        {
            this._items = items;
        }

        /// <summary>
        /// Retrieve the results of the TourTemplate.
        /// </summary>
        /// <remarks>
        /// <see cref="TourTemplate{T}.GenerateCostMatrix">TourTemplate.GenerateCostMatrix</see> must overriden and <see cref="TourTemplate{T}.Compute">TourTemplate.Compute</see> run prior to use.
        /// </remarks>
        /// 
        /// <returns>List of nodes ordered by shortest possible tour.</returns>
        public IList<T> GetTour()
        {
            return this._ordered;
        }

        /// <summary>
        /// Finds best possible tour through a set of points, traveling through all points.
        /// </summary>
        public void Compute()
        {
            this._ordered = new List<T>();

            if (this._items.Contains(this._start))
            {
                if (this._items.IndexOf(this._start) != 0)
                {
                    this._items.Remove(this._start);
                    this._items.Insert(0, this._start);
                }
            } else
            {
                this._items.Insert(0, this._start);
            }

            if (this._items.Count == 1)
            {
                this._ordered.Add(this._items[0]);
                return;
            }

            int[,] costMatrix = this.GenerateCostMatrix();
            int nodes = costMatrix.GetLength(0);

            for (int row = 0; row < nodes; row++)
            {
                string rowString = "";
                for (int col = 0; col < nodes; col++)
                {
                    rowString += costMatrix[row, col].ToString();
                    rowString += " ";
                }
                LogProxy.Info(rowString);
            }

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
                LogProxy.Info($"Visted ROute List: {index}");
            }

            foreach (int index in visitedRouteList)
            {
                this._ordered.Add(this._items[index]);
            }
        }

        /// <summary>
        /// Generates a matrix depicting the cost of traveling from each node to every other node.
        /// </summary>
        /// 
        /// <returns>Cost matrix</returns>
        protected abstract int[,] GenerateCostMatrix();
    }
}
