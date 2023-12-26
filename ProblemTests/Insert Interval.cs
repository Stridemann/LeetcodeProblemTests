public class Insert_Interval
{
	[Theory]
	[InlineData("[[1,3],[6,9]]", new int[] { 2, 5 }, "[[1,5],[6,9]]")]
	[InlineData("[[1,2],[3,5],[6,7],[8,10],[12,16]]", new int[] { 4, 8 }, "[[1,2],[3,10],[12,16]]")]
	[InlineData("[]", new int[] { 5, 7 }, "[[5,7]]")]
	public void Test(string a1, int[] newInterval, string result)
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
			return new []{ newInterval };

		var insertStart = newInterval[0];
		var insertEnd = newInterval[1];
		var result = new List<int[]>();
		for (var i = 0; i < intervals.Length; i++)
		{
			var cur = intervals[i];
			var curStart = cur[0];
			var curEnd = cur[1];

			//Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
			// Output: [[1,5],[6,9]]
			if (curEnd < insertStart)
			{
				result.Add(cur);
			}
			else //touch cur interval (curEnd >= insertStart)
			{
				var start = Math.Min(curStart, insertStart);
				if (insertEnd <= curEnd)
				{
					result.Add(new[] { start, curEnd });
					break;
				}

				var end = insertEnd;
				for (++i; i < intervals.Length; i++)
					cur = intervals[i];
				{
					curStart = cur[0];
					curEnd = cur[1];

					if (curStart > insertEnd)
					{
						--i;
						break;
					}

					if (insertEnd <= curEnd)
					{
						end = curEnd;
						break;
					}
				}

				result.Add(new[] { start, end });

				for (++i; i < intervals.Length; i++)
				{
					result.Add(intervals[i]);
				}
			}
		}

		return result.ToArray();
	}
}