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
    class WorldPath : PathTemplate
    {
        private Graph<ILocationParser> _graph;

        public WorldPath(Graph<ILocationParser> graph) : base()
        {
            this._graph = graph;
        }

        protected override ICollection<string> GetAllNodeID()
        {
            return this._graph.GetAllNodesIds();
        }

        protected override IList<string> GetEdges(string id)
        {
            Node node = this._graph.GetNode(id);
            return node.GetEdges();
        }

        protected override int GetSize()
        {
            return this._graph.GetAllNodesIds().Count;
        }
    }
}
