public class Count_Submatrices_With_All_Ones
{
	[Theory]
	[InlineData("[[0,1,1,0],[0,1,1,1],[1,1,1,0]]", 24)]
	[InlineData("[[1,0,1],[1,1,0],[1,1,0]]", 13)]
	public void Test(string a, int expected)
	{
		var arr = ArrayUtils.ArrayFromStr(a);
		var s = new Solution();
		s.NumSubmat(arr).ShouldBe(expected);
	}
}

public class Solution
{
	public int NumSubmat(int[][] mat)
	{
		var width = mat[0].Length;
		for (int y = 1; y < mat.Length; y++)
		{
			var row = mat[y];
			for (int x = 0; x < width; x++)
			{
				if (row[x] > 0)
					row[x] = mat[y - 1][x] + 1;
			}
		}

		var total = 0;
		for (int y = 0; y < mat.Length; y++)
		{
			var row = mat[y];

			for (int x = 0; x < width; x++)
			{
				var xVal = row[x];
				if (xVal == 0)
					continue;
			
				var max = xVal;
				for (int i = x; i < width; i++)
				{
					var iVal = row[i];
					if (iVal == 0)
						break;

					if (iVal < max)
					{
						max = iVal;
					}

					total += max;
				}
			}
		}

		return total;
	}
}