public class Kth_Smallest_Element_in_a_Sorted_Matrix
{
    [Theory]
    [InlineData("[[1,5,9],[10,11,13],[12,13,15]]", 8, 13)]
    [InlineData("[[1,3,5],[6,7,12],[11,14,14]]", 6, 11)]
    [InlineData("[[1,3,5],[6,7,12],[11,14,14]]", 1, 1)]
    [InlineData("[[1,3,5],[6,7,12],[11,14,14]]", 2, 3)]
    [InlineData("[[1,3,5],[6,7,12],[11,14,14]]", 3, 5)]
    [InlineData("[[1,3,5],[6,7,12],[11,14,14]]", 4, 6)]
    public void Test(string arrStr, int k, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.KthSmallest(arr, k).ShouldBe(expected);
    }
}

public class Solution
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var height = matrix.Length;
        var width = matrix[0].Length;

        var queue = new PriorityQueue<ValueTuple<int, int>, int>();
        queue.Enqueue((0, 0), matrix[0][0]);
        var visited = new HashSet<(int, int)>();

        while (queue.TryDequeue(out var cellIndex, out var value))
        {
            if (!visited.Add(cellIndex))
                continue;
            k--;

            if (k == 0)
            {
                return value;
            }

            var x = cellIndex.Item1;
            var y = cellIndex.Item2;

            if (x < width - 1)
            {
                var rtCell = x + 1;
                queue.Enqueue((rtCell, y), matrix[y][rtCell]);
            }

            if (y < height - 1)
            {
                var dnCell = y + 1;
                queue.Enqueue((x, dnCell), matrix[dnCell][x]);
            }
        }

        return 0;
    }
}
