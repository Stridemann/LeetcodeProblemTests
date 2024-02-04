namespace DefaultNamespace;

public class Merge_Intervals
{
	[Theory]
	[InlineData("[[1,3],[2,6],[8,10],[15,18]]", "[[1,6],[8,10],[15,18]]")]
	[InlineData("[[1,4],[4,5]]", "[[1,5]]")]
	public void Test(string a1, string result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.Merge(arr1);
		var arrayToStr = ArrayUtils.ArrayToStr(resultA);
		arrayToStr.ShouldBe(result);
	}
}

public class Solution
{
	public int[][] Merge(int[][] intervals)
	{
		if (intervals.Length == 0)
			return Array.Empty<int[]>();

		Array.Sort(intervals, (a, b) => a[0] - b[0]);

		var result = new List<int[]>();
		var current = intervals[0];
		for (int i = 1; i < intervals.Length; i++)
		{
			if (current[1] < intervals[i][0])
			{
				result.Add(current);
				current = intervals[i];
			}
			else if (current[1] >= intervals[i][0])
			{
				current[0] = Math.Min(current[0], intervals[i][0]);
				current[1] = Math.Max(current[1], intervals[i][1]);
			}
		}

		result.Add(current);

		return result.ToArray();
	}
}