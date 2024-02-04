namespace DefaultNamespace;

public class Course_Schedule
{
	[Theory]
	[InlineData(2, "[[1,0]]", true)]
	[InlineData(2, "[[1,0],[0,1]]", false)]
	[InlineData(2, "[[0,1]]", true)]
	public void Test(
		int c,
		string a1,
		bool result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.CanFinish(c, arr1);
		resultA.ShouldBe(result);
	}
}

public class Solution
{
	private readonly List<int> _newList = new();

	public bool CanFinish(int numCourses, int[][] prerequisites)
	{
		IDictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
		var visited = new HashSet<int>();
		for (var i = 0; i < numCourses; i++) preMap.Add(i, new List<int>());

		foreach (var course in prerequisites)
		{
			var courseToTake = course[0];
			var courseDependOn = course[1];
			preMap[courseToTake].Add(courseDependOn);
		}

		for (int i = 0; i < numCourses; i++)
		{
			if (!DfsGraph(preMap, visited, i))
				return false;
		}
	
		return true;
	}

	public bool DfsGraph(
		IDictionary<int, List<int>> preMap,
		HashSet<int> visited,
		int crs)
	{
		if (visited.Contains(crs)) return false;

		if (preMap[crs] == _newList) return true;

		visited.Add(crs);
		foreach (var pre in preMap[crs])
		{
			if (!DfsGraph(preMap, visited, pre)) return false;
		}

		visited.Remove(crs);
		preMap[crs] = _newList;
		return true;
	}
}