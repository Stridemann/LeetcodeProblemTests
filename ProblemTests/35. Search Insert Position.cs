using Shouldly;

public class Search_Insert_Position
{
    [Theory]
    [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
    public void Test(int[] nums, int target, int expected)
    {
        var s = new Solution();
        var result = s.SearchInsert(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;
            var curVal = nums[middle];

            if (curVal == target)
            {
                return middle;
            }
            else if (target > curVal)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return left;
    }
}
