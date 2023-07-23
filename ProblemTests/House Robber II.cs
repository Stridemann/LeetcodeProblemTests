public class House_Robber_II
{
    [Theory]
    [InlineData(new[] { 2, 3, 2 }, 3)]
    [InlineData(new[] { 1, 2, 3, 1 }, 4)]
    [InlineData(new[] { 1, 2, 3 }, 3)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Rob(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        if (nums.Length == 1)
            return nums[0];
        var first1 = 0;
        var first2 = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            var tmp = first1;
            first1 = Math.Max(first2 + num, first1);
            first2 = tmp;
        }

        var second1 = 0;
        var second2 = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            var num = nums[i];
            var tmp = second1;
            second1 = Math.Max(second2 + num, second1);
            second2 = tmp;
        }

        return Math.Max(first1, second1);
    }
}
