public class Cheapest_Flights_Within_K_Stops
{
    [Theory]
    [InlineData(
        4,
        "[[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]]",
        0,
        3,
        1,
        700)]
    [InlineData(
        3,
        "[[0,1,100],[1,2,100],[0,2,500]]",
        0,
        2,
        1,
        200)]
    [InlineData(
        4,
        "[[0,1,1],[0,2,5],[1,2,1],[2,3,1]]",
        0,
        3,
        1,
        6)]

    [InlineData(
        15,
        "[[10,14,43],[1,12,62],[4,2,62],[14,10,49],[9,5,29],[13,7,53],[4,12,90],[14,9,38],[11,2,64],[2,13,92],[11,5,42],[10,1,89],[14,0,32],[9,4,81],[3,6,97],[7,13,35],[11,9,63],[5,7,82],[13,6,57],[4,5,100],[2,9,34],[11,13,1],[14,8,1],[12,10,42],[2,4,41],[0,6,55],[5,12,1],[13,3,67],[3,13,36],[3,12,73],[7,5,72],[5,6,100],[7,6,52],[4,7,43],[6,3,67],[3,1,66],[8,12,30],[8,3,42],[9,3,57],[12,6,31],[2,7,10],[14,4,91],[2,3,29],[8,9,29],[2,11,65],[3,8,49],[6,14,22],[4,6,38],[13,0,78],[1,10,97],[8,14,40],[7,9,3],[14,6,4],[4,8,75],[1,6,56]]",
        1,
        4,
        10,
        169)]
    public void Test(
        int n,
        string arrStr,
        int src,
        int dst,
        int k,
        int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var s = new Solution();

        s.FindCheapestPrice(
             n,
             arr,
             src,
             dst,
             k)
         .ShouldBe(expected);
    }
}

public class Solution
{
    public int FindCheapestPrice(
        int n,
        int[][] flights,
        int src,
        int dst,
        int k)
    {
        var dict = new Dictionary<int, List<(int to, int price)>>();

        foreach (var flight in flights)
        {
            var from = flight[0];
            var to = flight[1];
            var price = flight[2];

            if (!dict.TryGetValue(from, out var connections))
            {
                connections = new List<(int, int)>();
                dict.Add(from, connections);
            }

            connections.Add((to, price));
        }

        var priorityQueue = new Queue<(int nodeIndex, int pathSize, int totalPrice)>();

        priorityQueue.Enqueue((src, 0, 0));

        var min = int.MaxValue;
        var prices = new int[n];
        Array.Fill(prices, int.MaxValue);

        while (priorityQueue.TryDequeue(out var node))
        {
            if (node.pathSize - 1 > k)
                continue;
            var totalPrice = node.totalPrice;

            if (prices[node.nodeIndex] > totalPrice)
                prices[node.nodeIndex] = totalPrice;
            else
                continue;

            if (node.nodeIndex == dst)
            {
                if (min > totalPrice)
                    min = totalPrice;

                continue;
            }

            if (!dict.TryGetValue(node.nodeIndex, out var connections))
                continue;

            foreach (var connection in connections)
            {
                priorityQueue.Enqueue((connection.to, node.pathSize + 1, totalPrice + connection.price));
            }
        }

        if (min == int.MaxValue)
            return -1;

        return min;
    }
}
