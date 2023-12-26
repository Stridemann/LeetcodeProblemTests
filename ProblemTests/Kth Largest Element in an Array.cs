public class Kth_Largest_Element_in_an_Array
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.FindKthLargest(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly PriorityQueue<int, int> data = new(new MaxHeapComparer());

    public int FindKthLargest(int[] nums, int k)
    {
        foreach (var num in nums)
        {
            data.Enqueue(num, num);
        }

        while (k-- > 0)
        {
            data.Dequeue();
        }

        return data.Dequeue();
    }

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
