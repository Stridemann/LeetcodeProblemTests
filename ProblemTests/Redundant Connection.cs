using System.Linq;
using System.Xml.Linq;

public class Redundant_Connection
{
	[Theory]
	[InlineData("[[1,2],[1,3],[2,3]]", new int[] { 2, 3 })]
	[InlineData("[[1,2],[2,3],[3,4],[1,4],[1,5]]", new int[] { 1, 4 })]
	public void Test(string nums, int[] expected)
	{
		var s = new Solution();
		var arr = ArrayUtils.ArrayFromStr(nums);
		var result = s.FindRedundantConnection(arr);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int[] FindRedundantConnection(int[][] edges)
	{
		var adjList = new Dictionary<int, List<int>>();
		var cycle = new HashSet<int>();

		foreach (var edge in edges)
		{
			if (!adjList.TryGetValue(edge[0], out var list))
			{
				list = new List<int>();
				adjList.Add(edge[0], list);
			}

			list.Add(edge[1]);

			if (!adjList.TryGetValue(edge[1], out list))
			{
				list = new List<int>();
				adjList.Add(edge[1], list);
			}

			list.Add(edge[0]);
		}

		bool Dfs(int node, int parent)
		{
			if (cycle.Contains(node))
			{
				foreach (var k in cycle.ToList())
				{
					if (k == node)
						return true;
					cycle.Remove(k);
				}
			}

			cycle.Add(node);

			foreach (var child in adjList[node])
			{
				if (child != parent && Dfs(child, node))
					return true;
			}

			cycle.Remove(node);
			return false;
		}

		Dfs(edges[0][0], -1);
		for (var i = edges.Length - 1; i >= 0; i--)
		{
			var edge = edges[i];
			if (cycle.Contains(edge[0]) && cycle.Contains(edge[1]))
			{
				return edge;
			}
		}

		return null;
	}
}

/*
 * public class Solution
   {
   private readonly Dictionary<int, List<ValueTuple<int, int, bool>>> _dict = new();
   private readonly HashSet<int> _visited = new HashSet<int>();
   private readonly List<ValueTuple<int, int, int, bool>> _visitedOrder = new();

   public int[] FindRedundantConnection(int[][] edges)
   {
   for (var i = 0; i < edges.Length; i++)
   {
   var edge = edges[i];
   var key = edge[0];
   if (!_dict.TryGetValue(key, out var list))
   {
   list = new List<(int, int, bool)>();
   _dict.Add(key, list);
   }

   list.Add(new(edge[1], i, true));

   var key2 = edge[1];
   if (!_dict.TryGetValue(key2, out var list2))
   {
   list2 = new List<(int, int, bool)>();
   _dict.Add(key2, list2);
   }

   list2.Add(new(edge[0], i, false));
   }

   for (var i = 0; i < edges.Length; i++)
   {
   var edge = edges[i];
   var res = Dfs(
   edge[1],
   edge[0],
   i,
   true);
   if (res != null)
   return res;
   }

   return null;
   }

   private int[]? Dfs(
   int nodeVal,
   int from,
   int order,
   bool direct)
   {
   if (_visited.Contains(nodeVal))
   {
   for (var i = _visitedOrder.Count - 1; i >= 0; i--)
   {
   var edge = _visitedOrder[i];
   if (edge.Item1 == nodeVal)
   {
   var min = edge;

   for (int j = i; j < _visitedOrder.Count; j++)
   {
   if (_visitedOrder[j].Item3 > min.Item3)
   {
   min = _visitedOrder[j];
   }
   }

   if (min.Item4)
   return new[] { min.Item1, min.Item2 };
   else
   return new[] { min.Item2, min.Item1 };
   }
   }

   return new int[] { from, nodeVal };
   }

   if (!_dict.TryGetValue(nodeVal, out var node))
   return null;

   if (node.Count == 0)
   {
   return null;
   }

   _visited.Add(nodeVal);
   _visitedOrder.Add(
   new(
   from,
   nodeVal,
   order,
   direct));
   foreach (var child in node)
   {
   if (child.Item1 == from)
   continue;

   var res = Dfs(
   child.Item1,
   nodeVal,
   child.Item2,
   child.Item3);
   if (res != null)
   return res;
   }

   node.Clear();
   _visited.Remove(nodeVal);
   _visitedOrder.RemoveAt(_visitedOrder.Count - 1);

   return null;
   }
   }
 * */