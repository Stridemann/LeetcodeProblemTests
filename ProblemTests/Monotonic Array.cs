public class Monotonic_Array
{
    [Theory]
    [InlineData(new[] { 1, 2, 2, 3 }, true)]
    [InlineData(new[] { 6, 5, 4, 4 }, true)]
    [InlineData(new[] { 1, 3, 2 }, false)]
    public void Test(int[] nums, bool expected)
    {
        var s = new Solution();
        var result = s.IsMonotonic(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsMonotonic(int[] nums)
    {
        if (nums.Length <= 2)
            return true;

        bool? isIncr = null;

        if (nums[0] < nums[^1])
        {
            isIncr = true;
        }
        else if (nums[0] > nums[^1])
        {
            isIncr = false;
        }

        var prev = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];

            if (prev == num)
                continue;
            var less = prev < num;

            if (!isIncr.HasValue)
            {
                if (less)
                    isIncr = true;
                else
                {
                    isIncr = false;
                }
            }
            else
            {
                if (less && !isIncr.Value)
                    return false;

                if (!less && isIncr.Value)
                    return false;
            }

            prev = nums[i];
        }

        return true;
    }
}
