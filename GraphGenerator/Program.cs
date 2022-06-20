using GraphGenerator;

Random random = new Random();


Graph MakeMainLineWithLoops(uint length, double branchChance)
{
	const uint OFFSHOOT_DIRECTIONS = 2;

	var graph = new Graph();

	// Make main line.
	for (uint i = 1; i < length; i++)
		graph.AddBidirectionalEdge(i - 1, i);

	// Offshoots
	for (uint d = 0; d < OFFSHOOT_DIRECTIONS; d++)
	{
		bool isBranched = false;
		uint offVertex = default;

		for (uint i = 0; i < length - 1; i++)
			if (random.NextDouble() < branchChance)
			{
				// branch back onto main line.
				if (isBranched)
					graph.AddBidirectionalEdge(offVertex, i);

				// branch off to a side.
				else
					offVertex = graph.AddBidirectionalEdgeToNewVertex(i);

				isBranched = !isBranched;
			}

		if (isBranched)
			graph.AddBidirectionalEdge(offVertex, length - 1);
	}

	return graph;
}


Console.WriteLine(MakeMainLineWithLoops(10, .5).Printout());