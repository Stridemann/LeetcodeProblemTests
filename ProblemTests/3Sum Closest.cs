using System.Collections;
using Shouldly;

public class Sum_Closest
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 1, 2)]
    [InlineData(new[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2, -2)]
    [InlineData(new[] { 0, 0, 0 }, 1, 0)]
    public void Test(int[] nums, int target, int expected)
    {
        var r = new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } };
        var s = new Solution();
        var result = s.ThreeSumClosest(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target2)
    {
        Array.Sort(nums);

        var resultMax = int.MaxValue;
        var bestSum = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var firstTarget = nums[i];

            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var l = nums[left];
                var r = nums[right];
                var sum = r + l;
                var moveRight = false;
                var moveLeft = false;

                var curSum = firstTarget + sum;
                var resultDiff = Math.Abs(target2 - curSum);

                if (resultMax > resultDiff)
                {
                    bestSum = curSum;
                    resultMax = resultDiff;
                }

                var compareTarget = firstTarget - target2;

                if (sum > -compareTarget)
                {
                    moveRight = true;
                }
                else if (sum < -compareTarget)
                {
                    moveLeft = true;
                }
                else
                {
                    moveRight = true;
                    moveLeft = true;
                }

                if (moveRight)
                {
                    do
                    {
                        right--;
                    } while (left < right && r == nums[right]);
                }

                if (moveLeft)
                {
                    do
                    {
                        left++;
                    } while (left < right && l == nums[left]);
                }
            }
        }

        return bestSum;
    }
}
