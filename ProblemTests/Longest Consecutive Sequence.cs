public class Longest_Consecutive_Sequence
{
    [Theory]
    [InlineData(new[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    [InlineData(new[] { 1, 2, 0, 1 }, 3)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.LongestConsecutive(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var set = nums.ToHashSet();
        var max = 0;

        foreach (var num in nums)
        {
            var curr = 0;

            if (!set.Remove(num))
            {
                continue;
            }

            curr++;
            var more = num + 1;

            while (set.Remove(more))
            {
                more++;
                curr++;
            }

            var less = num - 1;

            while (set.Remove(less))
            {
                less--;
                curr++;
            }

            max = Math.Max(max, curr);
        }

        return max;
    }
}
