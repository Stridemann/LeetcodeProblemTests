using System.Collections;
using System.Collections.Specialized;
using Shouldly;

public class Top_K_Frequent_Elements
{
    [Theory]
    [InlineData(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    [InlineData(new[] { 1 }, 1, new[] { 1 })]
    [InlineData(new[] { 3, 0, 1, 0 }, 1, new[] { 0 })]
    public void Test(int[] nums, int k, int[] expected)
    {
        var s = new Solution();
        var result = s.TopKFrequent(nums, k);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>(nums.Length / 10);

        foreach (var num in nums)
        {
            if (!dict.TryGetValue(num, out var cnt))
            {
                dict[num] = 1;
            }
            else
            {
                dict[num] = cnt + 1;
            }
        }

        return dict.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();
    }
}
