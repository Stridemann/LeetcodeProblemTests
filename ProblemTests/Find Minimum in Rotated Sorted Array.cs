public class Find_Minimum_in_Rotated_Sorted_Array
{
    [Theory]
    [InlineData(new[] { 3, 4, 5, 1, 2 }, 1)]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
    [InlineData(new[] { 11, 13, 15, 17 }, 11)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.FindMin(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int FindMin(int[] nums)
    {
        var res = nums[0];
        var r = nums.Length - 1;
        var l = 0;

        while (l <= r)
        {
            if (nums[l] < nums[r])
                return Math.Min(res, nums[l]);

            var m = (l + r) / 2;
            res = Math.Min(res, nums[m]);

            if (nums[m] >= nums[l])
                l = m + 1;
            else
                r = m - 1;
        }

        return res;
    }
}
