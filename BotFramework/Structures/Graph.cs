using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Structures
{
    class Graph<T>
    {
        public class Node
        {
            private string _id;
            private T _data;
            private IList<string> _edges;

            public Node(string id, T data, IList<string> edges)
            {
                this._id = id;
                this._data = data;
                this._edges = edges;
            }

            public Node(string id, T data) : this(id, data, new List<string>()) { }

            public void AddEdge(string id)
            {
                if (!this._edges.Contains(id))
                {
                    this._edges.Add(id);
                }
            }

            public string GetId()
            {
                return this._id;
            }

            public T GetData()
            {
                return this._data;
            }

            public IList<string> GetEdges()
            {
                return this._edges;
            }

            public override bool Equals(object obj)
            {
                return obj is Node && this.GetId() == ((Node)obj).GetId();
            }

            public override int GetHashCode()
            {
                return this.GetId().GetHashCode();
            }
        }

        private IDictionary<string, Node> _vertices;
        private string _root;

        public Graph()
        {
            this._vertices = new Dictionary<string, Node>();
        }

        public bool AddNode(Node node)
        {
            if (this._vertices.ContainsKey(node.GetId()))
            {
                return false;
            }

            foreach (string id in node.GetEdges())
            {
                if (this._vertices.ContainsKey(id))
                {
                    this._vertices[id].AddEdge(node.GetId());
                }
            }

            this._vertices.Add(node.GetId(), node);

            if (this._vertices.Count == 1)
            {
                this._root = node.GetId();
            }

            return true;
        }

        public bool AddNode(string _id, T data, IList<string> edges)
        {
            Node node = new Node(_id, data, edges);
            return this.AddNode(node);
        }

        public bool AddNode(string _id, T data)
        {
            Node node = new Node(_id, data);
            return this.AddNode(node);
        }

        public bool AddEdge(string id, string id2)
        {
            bool added = false;

            if (this._vertices.ContainsKey(id))
            {
                added = true;
                this._vertices[id].AddEdge(id2);
            }

            bool added2 = false;

            if (this._vertices.ContainsKey(id2))
            {
                added2 = true;
                this._vertices[id2].AddEdge(id);
            }

            return added && added2;
        }

        public int GetSize()
        {
            return this._vertices.Count;
        }

        public Node GetRoot()
        {
            return this._vertices[this._root];
        }

        public Node GetNode(string id)
        {
            return this._vertices[id];
        }

        public ICollection<Node> GetAllNodes()
        {
            return this._vertices.Values;
        }

        public ICollection<string> GetAllNodesIds()
        {
            return this._vertices.Keys;
        }
    }
}
