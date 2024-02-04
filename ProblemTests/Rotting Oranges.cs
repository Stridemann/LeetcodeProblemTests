using static System.Net.Mime.MediaTypeNames;

namespace DefaultNamespace;

public class Rotting_Oranges
{
	[Theory]
	[InlineData("[[2,1,1],[1,1,0],[0,1,1]]", 4)]
	public void Test(string a1, int result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.OrangesRotting(arr1);
		resultA.ShouldBe(result);
	}
}

public class Solution
{
	public int OrangesRotting(int[][] grid)
	{
		var height = grid.Length;
		var width = grid[0].Length;
		var queue = new Queue<(int x, int y)>();
		var fresh = 0;

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				ref var value = ref grid[y][x];
				if (value == 2)
				{
					value = -1;
					queue.Enqueue(new(x, y));
				}
				else if (value == 1)
				{
					fresh++;
				}
			}
		}

		if (queue.Count == 0)
		{
			if (fresh > 0)
				return -1;
			return 0;
		}

		var cnt = 0;
		while (true)
		{
			var newQueue = new Queue<(int x, int y)>();
			while (queue.TryDequeue(out var next))
			{
				var row = grid[next.y];

				if (next.x > 0 && row[next.x - 1] > 0)
				{
					row[next.x - 1] = -1;
					fresh--;
					newQueue.Enqueue((next.x - 1, next.y));
				}

				if (next.x < row.Length - 1 && row[next.x + 1] > 0)
				{
					row[next.x + 1] = -1;
					fresh--;
					newQueue.Enqueue((next.x + 1, next.y));
				}

				if (next.y > 0 && grid[next.y - 1][next.x] > 0)
				{
					grid[next.y - 1][next.x] = -1;
					fresh--;
					newQueue.Enqueue((next.x, next.y - 1));
				}

				if (next.y < height - 1 && grid[next.y + 1][next.x] > 0)
				{
					grid[next.y + 1][next.x] = -1;
					fresh--;
					newQueue.Enqueue((next.x, next.y + 1));
				}
			}

			if (newQueue.Count == 0)
				break;
			cnt++;
			queue = newQueue;
		}

		if (fresh > 0)
			return -1;

		return cnt;
	}
}