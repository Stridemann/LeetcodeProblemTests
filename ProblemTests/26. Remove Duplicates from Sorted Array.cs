using Shouldly;

public class Remove_Duplicates_from_Sorted_Array
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 3, 4, 5 }, 5)]
    [InlineData(new[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 5)]
    public void Test(int[] nums, int unique)
    {
        var s = new Solution();
        var result = s.RemoveDuplicates(nums);
        result.ShouldBe(unique);

        for (int i = 0; i < result; i++)
        {
            nums[i].ShouldBe(i + 1);
        }
    }
}

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
            return 0;
        var uniq = 1;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            var next = nums[i + 1];
            var cur = nums[i];

            if (cur != next)
            {
                nums[uniq] = next;
                uniq++;
            }
        }

        return uniq;
    }
}
