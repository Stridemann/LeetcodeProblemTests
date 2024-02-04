namespace DefaultNamespace;

public class Course_Schedule_II
{
	[Theory]
	[InlineData(2, "[[1,0]]", new int[] { 0, 1 })]
	[InlineData(4, "[[1,0],[2,0],[3,1],[3,2]]", new int[] { 0, 2, 1, 3 })]
	public void Test(
		int c,
		string a1,
		int[] result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.FindOrder(c, arr1);
		resultA.ShouldBe(result);
	}
}

public class Solution
{
	private readonly List<int> _newList = new();

	public int[] FindOrder(int numCourses, int[][] prerequisites)
	{
		IDictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
		var visited = new HashSet<int>();
		var result = new List<int>(numCourses);

		for (var i = 0; i < numCourses; i++)
			preMap.Add(i, new List<int>());

		foreach (var course in prerequisites)
		{
			var courseToTake = course[0];
			var courseDependOn = course[1];
			preMap[courseToTake].Add(courseDependOn);
		}

		for (int i = 0; i < numCourses; i++)
		{
			if (!DfsGraph(
				    preMap,
				    visited,
				    result,
				    i))
				return Array.Empty<int>();
		}

		return result.ToArray();
	}

	public bool DfsGraph(
		IDictionary<int, List<int>> preMap,
		HashSet<int> visited,
		List<int> result,
		int crs)
	{
		if (visited.Contains(crs)) return false;

		if (preMap[crs] == _newList)
		{
			return true;
		}

		visited.Add(crs);
		foreach (var pre in preMap[crs])
		{
			if (!DfsGraph(
				    preMap,
				    visited,
				    result,
				    pre)) return false;
		}

		visited.Remove(crs);
		preMap[crs] = _newList;
		result.Add(crs);
		return true;
	}
}