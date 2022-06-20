using GraphGenerator;

Graph MakeMainLineWithLoops(uint length)
{
	var graph = new Graph();

	// Make main line.
	for (uint i = 1; i < length; i++)
	{
		graph.AddBidirectionalEdge(i, i + 1);
	}

	return graph;
}


Console.WriteLine(MakeMainLineWithLoops(10).Printout());