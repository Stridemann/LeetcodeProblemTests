using Shouldly;

public class Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    [Theory]
    [InlineData(new[] { 5, 7, 7, 8, 8, 10 }, 8, new[] { 3, 4 })]
    [InlineData(new[] { 1, 2, 2, 2, 3, 4, 5, 6, 7, 8 }, 2, new[] { 1, 3 })]
    [InlineData(new[] { 2, 2 }, 2, new[] { 0, 1 })]
    public void Test(int[] nums, int target, int[] expected)
    {
        var s = new Solution();
        var result = s.SearchRange(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0)
            return new[] { -1, -1 };

        var left = 0;
        var right = nums.Length - 1;
        int startIndex = -1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            var num = nums[mid];

            if (num > target)
            {
                right = mid - 1;
            }
            else if (num < target)
            {
                left = mid + 1;
            }
            else
            {
                startIndex = mid;
                right = mid - 1;
            }
        }

        int endIndex = -1;
        left = 0;
        right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (right - left) / 2 + left;
            var num = nums[mid];

            if (num > target)
            {
                right = mid - 1;
            }
            else if (num == target)
            {
                endIndex = mid;
                left = mid + 1;
            }
            else
                left = mid + 1;
        }

        return new[] { startIndex, endIndex };
    }
}
