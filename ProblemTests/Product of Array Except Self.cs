using Shouldly;

public class Product_of_Array_Except_Self
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.ProductExceptSelf(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var lt = new int[nums.Length];
        var rt = new int[nums.Length];
        lt[0] = 1;
        rt[^1] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            lt[i] = lt[i - 1] * nums[i - 1];
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            rt[i] = rt[i + 1] * nums[i + 1];
        }

        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = lt[i] * rt[i];
        }

        return result;
    }
}
