public class Find_Peak_Element
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, 2)]
    [InlineData(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
    public void Test(int[] input, int expected)
    {
        var s = new Solution();
        var result = s.FindPeakElement(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            var rightVal = mid + 1 >= nums.Length ? int.MinValue : nums[mid + 1];

            if (nums[mid] > rightVal)
            {
                var leftVal = mid - 1 >= 0 ? nums[mid - 1] : nums[mid];

                if (nums[mid] > leftVal)
                {
                    return mid;
                }

                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return 0;
    }
}
