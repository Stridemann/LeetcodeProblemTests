using System.Collections;
using Shouldly;

public class Sum
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(int[] nums, int[][] unique)
    {
        var r = new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } };
        var s = new Solution();
        var result = s.ThreeSum(nums);
        result.ShouldBe(unique);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new[] { -1, 0, 1, 2, -1, -4 }, new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } } };
        yield return new object[] { new[] { 0, 0, 0 }, new[] { new[] { 0, 0, 0 } } };
        yield return new object[] { new[] { -2, 0, 0, 2, 2 }, new[] { new[] { -2, 0, 2 } } };
        yield return new object[] { new[] { 1,-1,-1,0 }, new[] { new[] { -1, 0, 1 } } };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var target = nums[i]; //6

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

                if (sum == -target)
                {
                    result.Add(new List<int> { target, l, r });
                    moveRight = true;
                    moveLeft = true;
                }
                else if (sum > -target)
                {
                    moveRight = true;
                }
                else if (sum < -target)
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

        return result;
    }
}
