public class Search_in_Rotated_Sorted_Array
{
    [Theory]
    [InlineData(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    public void Test(int[] nums, int target, int expected)
    {
        var s = new Solution();
        var result = s.Search(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
public int Search(int[] nums, int target)
{
    int left = 0;
    int right = nums.Length - 1;

    while (left <= right)
    {
        int middle = (left + right) / 2;
        var num = nums[middle];

        if (num >= nums[0] && target < nums[0])
            left = middle + 1;
        else if (num < nums[0] && target >= nums[0])
            right = middle - 1;
        else if (num < target)
            left = middle + 1;
        else if (num > target)
            right = middle - 1;
        else
            return middle;
    }

    return -1;
}
}
