public class Find_the_Duplicate_Number
{
    [Theory]
    [InlineData(new[] { 1, 3, 4, 2, 2 }, 2)]
    [InlineData(new[] { 3, 1, 3, 4, 2 }, 3)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.FindDuplicate(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        var slow = 0;
        var fast = 0;

        while (true)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];

            if (slow == fast) 
                break;
        }

        var slow2 = 0;

        while (true)
        {
            slow = nums[slow];
            slow2 = nums[slow2];
            if (slow == slow2) 
                return slow;
        }

        return 0;
    }
}
