using BotFramework.Locations;
using BotFramework.Structures;
using BotFramework.TemplateMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BotFramework.Structures.Graph<BotFramework.Locations.ILocationParser>;

namespace BotFramework.World
{
    /// <summary>
    /// Find shortest path to next <see cref="ILocationParser">Location</see>.
    /// </summary>
    /// <remarks>
    /// Implements template method <see cref="PathTemplate">TemplateMethods.PathTemplate</see>.
    /// </remarks>
    class WorldPath : PathTemplate
    {
        /// <summary>
        /// <see cref="Structures.Graph{T}">Graph</see> of <see cref="ILocationParser">Locations</see>
        /// </summary>
        private Graph<ILocationParser> _graph;

        /// <summary>
        /// Instantiates a new WorldPath generator.
        /// </summary>
        /// 
        /// <param name="graph"><see cref="Structures.Graph{T}">Graph</see> of <see cref="ILocationParser">Locations</see></param>
        public WorldPath(Graph<ILocationParser> graph) : base()
        {
            this._graph = graph;
        }

        /// <summary>
        /// Retrieves all <see cref="Graph{T}.Node">Node</see> Ids from <see cref="Graph{T}">Graph</see>
        /// </summary>
        /// 
        /// <returns>List of <see cref="Graph{T}.Node">Node</see> Ids</returns>
        protected override ICollection<string> GetAllNodeID()
        {
            return this._graph.GetAllNodesIds();
        }

        /// <summary>
        /// Retrieves edges for a given <see cref="Graph{T}.Node">Node</see>.
        /// </summary>
        /// 
        /// <param name="id">Id of <see cref="Graph{T}.Node">Node</see></param>
        /// <returns>List of edges</returns>
        protected override IList<string> GetEdges(string id)
        {
            Node node = this._graph.GetNode(id);
            return node.GetEdges();
        }

        /// <summary>
        /// Retrieves the size of the <see cref="Graph{T}">Graph</see>.
        /// </summary>
        /// 
        /// <returns>Size of <see cref="Graph{T}">Graph</see></returns>
        protected override int GetSize()
        {
            return this._graph.GetAllNodesIds().Count;
        }
    }
}
