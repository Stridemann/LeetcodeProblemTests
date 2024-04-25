using System.Text;

public class Largest_Number
{
    [Theory]
    [InlineData(new int[] { 10, 2 }, "210")]
    [InlineData(new int[] { 3, 30, 34, 5, 9 }, "9534330")]
    public void Test(int[] input, string expected)
    {
        var s = new Solution();
        var result = s.LargestNumber(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private class NumComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {

            return 0;
        }
    }

    public string LargestNumber(int[] nums)
    {
        var pq = new PriorityQueue<int, int>(new NumComparer());

        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
        }

        var sb = new StringBuilder();

        while (pq.TryDequeue(out var num, out _))
        {
            sb.Append(num.ToString());
        }

        return sb.ToString();
    }
}
