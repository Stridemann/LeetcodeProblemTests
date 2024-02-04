public class Min_Cost_to_Connect_All_Points
{
	[Theory]
	[InlineData("[[0,0],[2,2],[3,10],[5,2],[7,0]]", 20)]
	[InlineData("[[3,12],[-2,5],[-4,1]]", 18)]
	public void Test(string a, int expected)
	{
		var arr = ArrayUtils.ArrayFromStr(a);
		var s = new Solution();
		s.MinCostConnectPoints(arr).ShouldBe(expected);
	}
}

public class Solution
{
	public int MinCostConnectPoints(int[][] points)
	{
		var allEdges = new List<ValueTuple<int[], int>>();

		for (int i = 0; i < points.Length; i++)
		{
			var p1 = points[i];
			for (int j = i + 1; j < points.Length; j++)
			{
				var p2 = points[j];
				var dist = Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);
				allEdges.Add(new ValueTuple<int[], int>(new[] { i, j }, dist));
			}
		}

		var parents = new int[points.Length];
		var ranks = new int[points.Length];
		Array.Fill(ranks, 1);

		for (int i = 0; i < parents.Length; i++)
		{
			parents[i] = i;
		}

		int GetParent(int n)
		{
			if (parents[n] == n)
				return n;

			return parents[n] = GetParent(parents[n]);
		}

		var sum = 0;
		foreach (var valueTuple in allEdges.OrderBy(x => x.Item2))
		{
			var p1 = valueTuple.Item1[0];
			var p2 = valueTuple.Item1[1];

			var p1p = GetParent(p1);
			var p2p = GetParent(p2);

			if (p1p == p2p)
				continue;

			if (ranks[p1p] > ranks[p2p])
			{
				parents[p2p] = p1p;
				ranks[p1p] += ranks[p2p];
			}
			else
			{
				parents[p1p] = p2p;
				ranks[p2p] += ranks[p1p];
			}

			sum += valueTuple.Item2;
		}

		return sum;
	}
}