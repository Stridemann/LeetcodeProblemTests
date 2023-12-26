using System.Collections.Generic;

public class Last_Stone_Weight
{
    [Theory]
    [InlineData(new[] { 2, 7, 4, 1, 8, 1 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.LastStoneWeight(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private PriorityQueue<int, int> _priorityQueue = new PriorityQueue<int, int>(new Comparer());

    public int LastStoneWeight(int[] stones)
    {
        foreach (var stone in stones)
        {
            _priorityQueue.Enqueue(stone, stone);
        }

        while (_priorityQueue.Count > 1)
        {
            var elem1 = _priorityQueue.Dequeue();
            var elem2 = _priorityQueue.Dequeue();

            if (elem1 != elem2)
            {
                var diff = Math.Abs(elem1 - elem2);
                _priorityQueue.Enqueue(diff, diff);
            }
        }

        return _priorityQueue.Count == 0 ? 0 : _priorityQueue.Dequeue();
    }

    private class Comparer : IComparer<int>
    {
        #region Implementation of IComparer<in int>

        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }

        #endregion
    }
}
