using Shouldly;

public class Jump_Game_II
{
    [Theory]
    [InlineData(new[] { 2, 3, 1, 1, 4 }, 2)]
    [InlineData(new[] { 2, 3, 0, 1, 4 }, 2)]
    [InlineData(new[] { 2, 1 }, 1)]
    [InlineData(new[] { 5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5 }, 5)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Jump(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int Jump(int[] nums)
    {
        if (nums.Length <= 1)
            return 0;

        var length = nums.Length;
        var preLast = nums.Length - 1;

        var maxJump = 0;
        var jumps = 0;
        var cur = 0;

        for (int i = 0; i < length; i++)
        {
            maxJump = Math.Max(maxJump, i + nums[i]);

            if (maxJump >= preLast)
            {
                return jumps + 1;
            }

            if (i == cur)
            {
                cur = maxJump;
                jumps++;
            }
        }

        return -1;
    }
}
