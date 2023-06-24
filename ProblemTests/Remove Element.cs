using Shouldly;

public class Remove_Element
{
    [Theory]
    [InlineData(new[] { 3, 2, 2, 3 }, 3, 2)]
    [InlineData(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void Test(int[] nums, int val, int output)
    {
        var s = new Solution();
        var result = s.RemoveElement(nums, val);
        result.ShouldBe(output);
    }
}

public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;

        var copyPtr = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num != val)
            {
                nums[++copyPtr] = num;
            }
        }

        return copyPtr + 1;
    }
}
