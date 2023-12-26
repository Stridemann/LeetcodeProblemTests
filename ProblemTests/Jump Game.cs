public class Jump_Game
{
    [Theory]
    [InlineData(new[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new[] { 3, 2, 1, 0, 4 }, false)]
    public void Test(int[] nums, bool expected)
    {
        var s = new Solution();
        var result = s.CanJump(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool CanJump(int[] nums)
    {
        var max = 0;
        var i = 0;

        do
        {
            max = Math.Max(max, i + nums[i]);
            i++;
        } while (i <= max && i < nums.Length);

        return max >= nums.Length - 1;
    }
}
