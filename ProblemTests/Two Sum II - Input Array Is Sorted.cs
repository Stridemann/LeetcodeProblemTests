using Shouldly;

public class Two_Sum_II___Input_Array_Is_Sorted
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
    public void Test(int[] nums, int target, int[] expected)
    {
        var s = new Solution();
        var result = s.TwoSum(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            var sum = numbers[left] + numbers[right];

            if (sum == target)
            {
                return new[] { left + 1, right + 1 };
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return null;
    }
}
