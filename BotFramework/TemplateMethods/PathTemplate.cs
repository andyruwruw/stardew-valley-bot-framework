using BotFramework.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.TemplateMethods
{
    /// <summary>
    /// Template method for finding best path through a graph.
    /// </summary>
    /// <remarks>
    /// <para>Utilizes Dijkstra's .</para>
    /// <para>Requires the override of <see cref="TourTemplate{T}.GenerateCostMatrix">TourTemplate.GenerateCostMatrix</see>.</para>
    /// </remarks>
    abstract class PathTemplate
    {
        private IDictionary<string, int> _dist;

        private IDictionary<string, string> _prev;

        private IDictionary<string, bool> _visited;

        private string _start;

        /// <summary>
        /// Instantiations a new PathTemplate.
        /// </summary>
        public PathTemplate() { }

        private void Inicialize()
        {
            this._dist = new Dictionary<string, int>();
            this._prev = new Dictionary<string, string>();
            this._visited = new Dictionary<string, bool>();

            foreach (string item in this.GetAllNodeID())
            {
                this._dist[item] = int.MaxValue;
                this._visited[item] = false;
            }
        }

        /// <summary>
        /// Sets the starting node of path.
        /// </summary>
        /// 
        /// <param name="start">Starting node</param>
        public void SetStart(string start)
        {
            this._start = start;
        }

        /// <summary>
        /// Retrieve the results of the PathTemplate.
        /// </summary>
        /// 
        /// <returns>List of nodes ordered by shortest possible path.</returns>
        public IList<string> GetTour(string end)
        {
            IList<string> order = new List<string>();

            order.Add(end);

            if (end == this._start)
            {
                return order;
            }

            bool found = true;

            string last = end;

            while (found) {
                if (this._prev.ContainsKey(last))
                {
                    last = this._prev[last];
                    order.Insert(0, last);
                } else
                {
                    found = false;
                }
            }

            return order;
        }

        /// <summary>
        /// Finds best possible tour through a set of points, traveling through all points.
        /// </summary>
        public void Compute()
        {
            this.Inicialize();

            this._dist[this._start] = 0;

            while (this.QueueCount() > 0)
            {
                string next = this._dist.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

                IList<string> edges = this.GetEdges(next);

                foreach (string edge in edges)
                {
                    if (this._dist[edge] > this._dist[next] + 1)
                    {
                        this._dist[edge] = this._dist[next] + 1;
                        this._prev[edge] = next;
                    }
                }
            }
        }

        protected int QueueCount()
        {
            int count = 0;

            foreach (int distance in this._dist.Values)
            {
                if (distance == int.MaxValue)
                {
                    count += 1;
                }
            }

            return count;
        }

        protected abstract int GetSize();

        protected abstract ICollection<string> GetAllNodeID();

        protected abstract IList<string> GetEdges(string id);
    }
}

