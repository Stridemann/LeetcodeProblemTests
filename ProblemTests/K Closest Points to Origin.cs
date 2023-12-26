public class K_Closest_Points_to_Origin
{
    [Theory]
    [InlineData("[[1,3],[-2,2]]", 2)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.KClosest(arr, 1);
    }
}

public class Solution
{
    PriorityQueue<int[], double> _priorityQueue = new PriorityQueue<int[], double>();

    public int[][] KClosest(int[][] points, int k)
    {
        foreach (var point in points)
        {
            var dist = Math.Sqrt(Math.Pow(point[0], 2) + Math.Pow(point[1], 2));
            _priorityQueue.Enqueue(point, dist);
        }

        var result = new List<int[]>();

        while (k-- > 0)
        {
            result.Add(_priorityQueue.Dequeue());
        }

        return result.ToArray();
    }
}
