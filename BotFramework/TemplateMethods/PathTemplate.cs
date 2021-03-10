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
    /// <para>Utilizes Dijkstra's algorithm running in O(v^2) because I'm too lazy to implement it with a min-priority queue. Please help.</para>
    /// <para>Requires the override of <see cref="PathTemplate.GetSize">PathTemplate.GetSize</see>, <see cref="PathTemplate.GetAllNodeID">PathTemplate.GetAllNodeID</see>, and <see cref="PathTemplate.GetEdges(string)">PathTemplate.GetEdges</see>.</para>
    /// </remarks>
    abstract class PathTemplate
    {
        /// <summary>
        /// Distance to each node.
        /// </summary>
        private IDictionary<string, int> _dist;

        /// <summary>
        /// Parent of each node
        /// </summary>
        private IDictionary<string, string> _prev;

        /// <summary>
        /// Whether each node has been visited
        /// </summary>
        private IDictionary<string, bool> _visited;

        /// <summary>
        /// Starting node
        /// </summary>
        private string _start;

        /// <summary>
        /// Instantiations a new PathTemplate.
        /// </summary>
        public PathTemplate() { }

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
        /// Finds best possible path to each node from the starting node.
        /// </summary>
        public void Compute()
        {
            this.Inicialize();

            this._dist[this._start] = 0;

            while (this.QueueCount() > 0)
            {
                string next = this.GetLowestKey();

                this._visited[next] = true;

                IList<string> edges = this.GetEdges(next);

                foreach (string edge in edges)
                {
                    if (this._dist.ContainsKey(edge))
                    {
                        if (this._dist[edge] > this._dist[next] + 1)
                        {
                            this._dist[edge] = this._dist[next] + 1;
                            this._prev[edge] = next;
                        }
                    }
                }
            }
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

            while (found)
            {
                if (this._prev.ContainsKey(last))
                {
                    last = this._prev[last];
                    order.Insert(0, last);
                }
                else
                {
                    found = false;
                }
            }

            return order;
        }

        /// <summary>
        /// Retrieves the number of unvisited nodes.
        /// </summary>
        /// 
        /// <returns>Number of unvisited nodes</returns>
        protected int QueueCount()
        {
            int count = 0;

            foreach (string key in this._dist.Keys)
            {
                if (!this._visited[key])
                {
                    count += 1;
                }
            }

            return count;
        }

        /// <summary>
        /// Retreives the size of the graph.
        /// </summary>
        /// 
        /// <returns>Number of nodes in graph</returns>
        protected abstract int GetSize();

        /// <summary>
        /// Retrieves a list of every node Id.
        /// </summary>
        /// 
        /// <returns>List of node Ids</returns>
        protected abstract ICollection<string> GetAllNodeID();

        /// <summary>
        /// Retrieves a given node's edges.
        /// </summary>
        /// 
        /// <param name="id">Node's Id</param>
        /// <returns>List of edges</returns>
        protected abstract IList<string> GetEdges(string id);

        /// <summary>
        /// Retreives the lowest distance unvisited node.
        /// </summary>
        /// 
        /// <returns>A node</returns>
        private string GetLowestKey()
        {
            string first = null;
            int lowest = int.MaxValue;
            string lowestId = null;

            foreach (string key in this.GetAllNodeID())
            {
                if (!this._visited[key])
                {
                    if (first == null)
                    {
                        first = key;
                    }
                    if (this._dist[key] < lowest)
                    {
                        lowestId = key;
                    }
                }
            }

            if (lowestId == null)
            {
                return first;
            }
            return lowestId;
        }

        /// <summary>
        /// Sets up required elements.
        /// </summary>
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
    }
}

