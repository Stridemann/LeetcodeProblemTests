public class Insert_Interval
{
	[Theory]
	[InlineData("[[1,3],[6,9]]", new int[] { 2, 5 }, "[[1,5],[6,9]]")]
	[InlineData("[[1,2],[3,5],[6,7],[8,10],[12,16]]", new int[] { 4, 8 }, "[[1,2],[3,10],[12,16]]")]
	[InlineData("[]", new int[] { 5, 7 }, "[[5,7]]")]
	public void Test(
		string a1,
		int[] newInterval,
		string result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.Insert(arr1, newInterval);
		var arrayToStr = ArrayUtils.ArrayToStr(resultA);
		arrayToStr.ShouldBe(result);
	}
}

public class Solution
{
	public int[][] Insert(int[][] intervals, int[] newInterval)
	{
		if (intervals.Length == 0)
			return new[] { newInterval };

		var result = new List<int[]>();

		for (int i = 0; i < intervals.Length; i++)
		{
			var interval = intervals[i];

			if (newInterval[1] < interval[0])
			{
				result.Add(newInterval);
				result.AddRange(intervals.Skip(i));
				return result.ToArray();
			}

			if (newInterval[0] > interval[1])
			{
				result.Add(interval);
			}
			else
			{
				newInterval[0] = Math.Min(newInterval[0], interval[0]);
				newInterval[1] = Math.Max(newInterval[1], interval[1]);
			}
		}

		result.Add(newInterval);
		return result.ToArray();
	}
}