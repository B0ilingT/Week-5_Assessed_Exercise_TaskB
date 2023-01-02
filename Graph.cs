using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Task_B
{
    public class Graph<T> where T : IComparable
    {
        private LinkedList<GraphNode<T>> nodes; // list of all nodes in the graph

        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        public bool IsEmptyGraph()
        {
            return nodes.Count == 0;
        }

        public void AddNode(T id)
        {
            nodes.AddLast(new GraphNode<T>(id)); // first make a new graphNode and then add this to the nodes list
        }
        public void RemoveNode(T id)
        {
            GraphNode<T> node = GetNodeByID(id);
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ADJList.Contains(node.ID))
                    n.ADJList.Remove(node.ID);
            }
            node.ADJList = null;
            nodes.Remove(node);
        }
        public bool ContainsGraph(T data)
        {
            GraphNode<T> node = GetNodeByID(data);
            if (node != null)
            {
                foreach (GraphNode<T> n in nodes) // check if the id of n(a certain node in nodes linked list) is the same id as the node(node) we are checking for 
                {
                    if (n.ID.CompareTo(node.ID) == 0)
                        return true;
                }
                return false;
            }
            return false;
        }

        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0) return n;
            }
            return null;
        }

        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);

            if (n1 != null & n2 != null)
            {
                n1.AddEdge(n2);
            }
            else
                Console.WriteLine("Node/s not found in the graph. Cannot add the edge");

        }

        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(from.ID) == 0)
                {
                    if (from.ADJList.Contains(to.ID))
                        return true;
                }
            }
            return false;
        }

        public int NumNodesGraph()
        {
            return nodes.Count;
        }
        public void BreadthFirstTraverse(T startID, ref List<T> visited)
        {
            Queue<T> toVisit = new Queue<T>();
            GraphNode<T> current = new GraphNode<T>(startID);
            toVisit.Enqueue(startID);

            while (toVisit.Count != 0)
            {
                current.ID = toVisit.Peek();
                visited.Add(toVisit.Dequeue());// get ID of current node from toVisit (use “dequeue”) // store ID current node as “visited” 
                foreach (T n in GetNodeByID(current.ID).GetAdjList()) // get adjacency list of the current node (method from GraphNode)
                {
                    if (toVisit.Contains(n) == false)
                    {
                        if (visited.Contains(n) == false) // (only if n is not in “visited” and not in “toVisit”)
                        {
                            toVisit.Enqueue(n);                            
                        }   
                    }
                }
            }
        }

        public void DepthFirstTraverse(T startID, ref List<T> visited)
        {
            Stack<T> toVisit = new Stack<T>();
            GraphNode<T> current = new GraphNode<T>(startID);
            toVisit.Push(startID);

            while (toVisit.Count != 0)
            {
                visited.Add(toVisit.Pop());// get ID of current node from toVisit (use “dequeue”) // store ID current node as “visited” 

                foreach (T n in GetNodeByID(current.ID).ADJList) // get adjacency list of the current node (method from GraphNode)
                {
                    if (toVisit.Contains(n) == false)
                    {
                        if (visited.Contains(n) == false) // (only if n is not in “visited” and not in “toVisit”)
                            toVisit.Push(n);
                    }
                }
            }
        }

    }
}
