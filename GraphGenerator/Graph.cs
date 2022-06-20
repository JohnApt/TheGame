using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGenerator
{
	public class Graph
	{
		/// <summary>
		/// ith index in the list has a hashset of the vertcies that it shares an edge with.
		/// </summary>
		private readonly List<HashSet<uint>> adjList = new();

		public void AddEdge(uint a, uint b)
		{
			while(adjList.Count <= a)
				adjList.Add(new());

			adjList[(int)a].Add(b);
		}

		public void AddBidirectionalEdge(uint a, uint b)
		{
			AddEdge(a, b);
			AddEdge(b, a);
		}

		public string Printout()
		{
			var sb = new StringBuilder();
			for(int i = 0; i < adjList.Count; i++)
				foreach (var other in adjList[i])
					sb.Append($"{i} {other}");
			return sb.ToString();
		}
		//John is cool.
		public bool HasPointOfNoReturn()
		{
			throw new NotImplementedException();
		}
	}
}
