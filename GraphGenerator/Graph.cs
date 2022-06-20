using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGenerator
{
	/// <summary>
	/// Represents a graph.
	/// </summary>
	public class Graph
	{
		/// <summary>
		/// ith index in the list has a hashset of the vertcies that it shares an edge with.
		/// </summary>
		private readonly List<HashSet<uint>> adjList = new();

		/// <summary>
		/// Adds a one directional edge from vertex <paramref name="a"/> to vertex <paramref name="b"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		public void AddEdge(uint a, uint b)
		{
			while (adjList.Count <= a)
				adjList.Add(new());

			adjList[(int)a].Add(b);
		}

		public uint AddEdgeToNewVertex(uint a)
		{
			uint newVertex = (uint)adjList.Count; 
			AddEdge(a, newVertex);
			return newVertex;
		}

		/// <summary>
		/// Adds an bidirectional edge between vertex <paramref name="a"/> and <paramref name="b"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		public void AddBidirectionalEdge(uint a, uint b)
		{
			AddEdge(a, b);
			AddEdge(b, a);
		}

		public uint AddBidirectionalEdgeToNewVertex(uint a)
		{
			uint newVertex = (uint)adjList.Count;
			AddBidirectionalEdge(a, newVertex);
			return newVertex;
		}

		/// <summary>
		/// Creates printout for https://csacademy.com/app/graph_editor/ so we can visualize.
		/// </summary>
		/// <returns>The printout as a string.</returns>
		public string Printout()
		{
			var sb = new StringBuilder();
			for (int i = 0; i < adjList.Count; i++)
				foreach (var other in adjList[i])
					sb.Append($"{i} {other}\n");
			return sb.ToString();
		}

		//John is cool. //<- Comment must never be removed
		/// <summary>
		/// Checks that all verticies can be reached from all verticies.
		/// </summary>
		/// <returns>If the graph is strongly connected</returns>
		public bool IsStronglyConnected()
		{
			throw new NotImplementedException();
		}
	}
}
