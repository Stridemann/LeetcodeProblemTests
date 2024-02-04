public class Longest_Increasing_Path_in_a_Matrix
{
	[Theory]
	[InlineData("[[9,9,4],[6,6,8],[2,1,1]]", 4)]
	[InlineData("[[3,4,5],[3,2,6],[2,2,1]]", 4)]
	public void Test(string expr, int expected)
	{
		var s = new Solution();
		var arr = ArrayUtils.ArrayFromStr(expr);
		var result = s.LongestIncreasingPath(arr);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	private int _height;
	private int _width;
	private int[][] _matrix;
	private int[,] _matrixPath;

	public int LongestIncreasingPath(int[][] matrix)
	{
		_matrix = matrix;
		_height = matrix.Length;
		_width = matrix[0].Length;
		_matrixPath = new int[_height, _width];

		var result = 0;
		for (int y = 0; y < _height; y++)
		{
			for (int x = 0; x < _width; x++)
			{
				var val = Dfs(x, y, -10);
				if (result < val)
					result = val;
			}
		}

		return result;
	}

	private int Dfs(
		int x,
		int y,
		int fromCell)
	{
		if (x < 0 || x >= _width || y < 0 || y >= _height)
		{
			return 0;
		}

		ref int val = ref _matrix[y][x];
		if (val <= fromCell)
			return 0;
		ref int pathVal = ref _matrixPath[y, x];

		if (pathVal >= 10000)
		{
			return pathVal - 10000;
		}

		var rt = Dfs(x + 1, y, val);
		var lt = Dfs(x - 1, y, val);
		var dn = Dfs(x, y + 1, val);
		var up = Dfs(x, y - 1, val);
		var newVal = Math.Max(rt, Math.Max(lt, Math.Max(dn, up))) + 1;

		pathVal = newVal + 10000;

		return newVal;
	}
}