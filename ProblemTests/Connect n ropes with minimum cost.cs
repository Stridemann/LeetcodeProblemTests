using Shouldly;

public class Connect_n_ropes_with_minimum_cost
{
    [Theory]
    [InlineData(new[] { 4, 3, 2, 6 }, 29)]
    [InlineData(new[] { 4, 2, 7, 6, 9 }, 62)]
    [InlineData(new[] { 1, 2, 3 }, 9)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Connect(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int Connect(int[] nums)
    {
        var zero = 0;
        var sum = 0;

        for (int i = zero; i < nums.Length - 1; i++)
        {
            Array.Sort(nums);
            sum += nums[i + 1] += nums[i];
            nums[i] = 0;
            zero++;
        }

        return sum;
    }
}
