using System;
using System.Collections;
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
		private uint nextVertex = 0;

		private void addEdge(uint start, uint end)
		{
			while (adjList.Count <= start)
				adjList.Add(new());

			adjList[(int)start].Add(end);
		}

		private void updateBiggestVertex(uint vert)
		{
			nextVertex = Math.Max(vert + 1, nextVertex);
		}

		private uint reserveNewVertex()
		{
			return nextVertex++;
		}

		/// <summary>
		/// Adds a one directional edge from vertex <paramref name="start"/> to vertex <paramref name="end"/>.
		/// </summary>
		/// <param name="start">start vertex</param>
		/// <param name="end">end vertex</param>
		public void AddEdge(uint start, uint end)
		{
			addEdge(start, end);
			updateBiggestVertex(start);
			updateBiggestVertex(end);
		}

		/// <summary>
		/// Adds an edge going from an existing vertex to a new vertex.
		/// </summary>
		/// <param name="vert">The existing vertex.</param>
		/// <returns>the new vertex.</returns>
		public uint AddEdgeToNewVertex(uint vert)
		{
			updateBiggestVertex(vert);
			uint newVertex = reserveNewVertex();
			addEdge(vert, newVertex);
			return newVertex;
		}

		/// <summary>
		/// Adds an edge going from a new vertex to an existing vertex.
		/// </summary>
		/// <param name="a">The existing vertex.</param>
		/// <returns>The new vertex.</returns>
		public uint AddEdgeFromNewVertex(uint a)
		{
			updateBiggestVertex(a);
			uint newVertex = reserveNewVertex();
			addEdge(newVertex, a);
			return newVertex;
		}

		/// <summary>
		/// Adds an bidirectional edge between vertex <paramref name="a"/> and <paramref name="b"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		public void AddBidirectionalEdge(uint a, uint b)
		{
			updateBiggestVertex(start);
			updateBiggestVertex(end);
			AddEdge(a, b);
			AddEdge(b, a);
		}

		/// <summary>
		/// Adds a bidirectional edge between an existing vertex and a new one.
		/// </summary>
		/// <param name="vert">The existing vertex.</param>
		/// <returns>the new vertex.</returns>
		public uint AddBidirectionalEdgeToNewVertex(uint vert)
		{
			uint newVertex = (uint)adjList.Count;
			AddBidirectionalEdge(vert, newVertex);
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

		/// <summary>
		/// Gets all verticies adjacent to a given vertex
		/// </summary>
		/// <param name="vert">The starting point.</param>
		/// <returns>Set of adjacent verticies.</returns>
		public IReadOnlySet<uint> Adjacencies(uint vert)
		{
			if (vert < adjList.Count)
				return adjList[(int)vert];
			return
				EmptySet.Instance;
		}

		//John is cool. //<- Comment must never be removed
		/// <summary>
		/// Checks that all verticies can be reached from all verticies.
		/// </summary>
		/// <returns>If the graph is strongly connected.</returns>
		public bool IsStronglyConnected()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Describes the empty set.
		/// </summary>
		private class EmptySet : IReadOnlySet<uint>
		{
			public static EmptySet Instance => new();
			private EmptySet() { }

			private class Enumerator : IEnumerator<uint>
			{
				public static Enumerator Instance => new();
				private Enumerator() { }

				public uint Current => 0;
				object IEnumerator.Current => Current;
				public void Dispose() { }
				public bool MoveNext() => false;
				public void Reset() { }
			}

			public int Count => 0;
			public bool Contains(uint item) => false;
			public IEnumerator<uint> GetEnumerator() => Enumerator.Instance;
			public bool IsProperSubsetOf(IEnumerable<uint> other) => other.Any();
			public bool IsProperSupersetOf(IEnumerable<uint> other) => false;
			public bool IsSubsetOf(IEnumerable<uint> other) => true;
			public bool IsSupersetOf(IEnumerable<uint> other) => !other.Any();
			public bool Overlaps(IEnumerable<uint> other) => false;
			public bool SetEquals(IEnumerable<uint> other) => !other.Any();
			IEnumerator IEnumerable.GetEnumerator() => Enumerator.Instance;
		}
	}
}
