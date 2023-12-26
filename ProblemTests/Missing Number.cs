public class Missing_Number
{
    [Theory]
    [InlineData(new[] { 3, 0, 1 }, 2)]
    [InlineData(new[] { 0, 1 }, 2)]
    [InlineData(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
    [InlineData(new[] { 2, 0 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.MissingNumber(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        var summ = nums.Length * (nums.Length + 1) / 2;
        return summ - nums.Sum();

        var zeroIndex = -1;
        var hitZero = false;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num < 0)
            {
                num *= -1;
            }
            else if (num == 0)
            {
                zeroIndex = i;
            }

            if (num >= nums.Length)
            {
                continue;
            }

            ref var n = ref nums[num];
            n *= -1;

            if (n == 0)
            {
                hitZero = true;
            }
        }

        if (hitZero && zeroIndex != -1)
        {
            nums[zeroIndex] = -1;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
            {
                return i;
            }
        }

        return nums.Length;
    }
}
