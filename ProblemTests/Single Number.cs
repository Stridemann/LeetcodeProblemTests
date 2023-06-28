using Shouldly;

public class Single_Number
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        var hash = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!hash.Add(num))
            {
                hash.Remove(num);
            }
        }

        return hash.First();
    }

public int SingleNumber(int[] nums)
{
    var result = nums[0];

    for (var i = 1; i < nums.Length; ++i)
    {
        result ^= nums[i];
    }

    return result;
}
}
