public class Swim_in_Rising_Water
{
    [Theory]
    [InlineData("[[0,2],[1,3]]", 3)]
    [InlineData("[[3,2],[0,1]]", 3)]
    [InlineData("[[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]", 16)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.SwimInWater(arr).ShouldBe(expected);
    }
}

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;
        var visited = new HashSet<(int x, int y)>();
        var priorityQueue = new PriorityQueue<(int y, int x), int>();

        priorityQueue.Enqueue((0, 0), grid[0][0]);

        void ProcessNearest((int y, int x) pos, int priority)
        {
            if (pos.x < 0 || pos.y < 0 || pos.x >= width || pos.y >= height)
                return;

            var newPriority = Math.Max(grid[pos.y][pos.x], priority);

            priorityQueue.Enqueue(pos, newPriority);
        }

        while (priorityQueue.TryDequeue(out var pos, out var priority))
        {
            if (!visited.Add(pos))
                continue;

            if (pos.x == width - 1 && pos.y == height - 1)
                return priority;

            ProcessNearest((pos.y, pos.x + 1), priority);
            ProcessNearest((pos.y, pos.x - 1), priority);
            ProcessNearest((pos.y + 1, pos.x), priority);
            ProcessNearest((pos.y - 1, pos.x), priority);
        }

        return -1;
    }
}
