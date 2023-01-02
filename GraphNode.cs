using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Task_B
{
    public class GraphNode<T>
    {
        private T id;
        private LinkedList<T> adjList; // adjList stores all of a Nodes adjacent nodes (nodes they have a connection with)

        public GraphNode(T id) //constructor
        {
            this.id = id;
            adjList = new LinkedList<T>();
        }

        public T ID
        {
            set { id = value; }
            get { return id; }
        }

        public LinkedList<T> ADJList
        {
            set { adjList = value; }
            get { return adjList; }
        }

        public void AddEdge(GraphNode<T> to)
        {
            adjList.AddLast(to.ID);
        }

        public LinkedList<T> GetAdjList()
        {
            return adjList;
        }


    }
}
