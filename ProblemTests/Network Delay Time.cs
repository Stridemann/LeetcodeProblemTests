public class Network_Delay_Time
{
    [Theory]
    [InlineData("[[2,1,1],[2,3,1],[3,4,1]]", 4, 2, 2)]
    [InlineData("[[1,2,1]]", 2, 1, 1)]
    [InlineData("[[1,2,1]]", 2, 2, -1)]
    [InlineData("[[1,2,1],[2,3,7],[1,3,4],[2,1,2]]", 4, 1, -1)]
    [InlineData("[[1,2,1],[2,3,7],[1,3,4],[2,1,2]]", 3, 1, 4)]
    public void Test(
        string arrStr,
        int n,
        int k,
        int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();
        s.NetworkDelayTime(arr, n, k).ShouldBe(expected);
    }
}

public class Solution
{
    private class MyTuple
    {
        public int Dist = int.MaxValue;
        public readonly List<ValueTuple<int, int>> Connections = new List<(int, int)>();
    }

    private readonly Dictionary<int, MyTuple> _connections = new Dictionary<int, MyTuple>();
    private int _visited;

    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        foreach (var time in times)
        {
            var src = time[0];
            var dst = time[1];
            var t = time[2];

            if (!_connections.TryGetValue(src, out var srcNode))
            {
                srcNode = new MyTuple();
                _connections[src] = srcNode;
            }

            srcNode.Connections.Add(new ValueTuple<int, int>(dst, t));

            if (!_connections.TryGetValue(dst, out var dstNode))
            {
                dstNode = new MyTuple();
                _connections[dst] = dstNode;
            }
        }

        var queue = new PriorityQueue<int, int>();

        queue.Enqueue(k, 0);
        int res = 0;

        while (queue.TryDequeue(out var nodeId, out var total))
        {
            var conn = _connections[nodeId];

            if (conn.Dist != int.MaxValue)
                continue;
            conn.Dist = total;
            _visited++;

            res = Math.Max(res, total);

            foreach (var connection in conn.Connections)
            {
                queue.Enqueue(connection.Item1, total + connection.Item2);
            }
        }

        if (_visited < n)
            return -1;

        return res;
    }
}
