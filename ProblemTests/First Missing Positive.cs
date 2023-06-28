public class First_Missing_Positive
{
    [Theory]
    [InlineData(new[] { 1, 2, 0 }, 3)]
    [InlineData(new[] { 3, 4, -1, 1 }, 2)]
    [InlineData(new[] { 7, 8, 9, 11, 12 }, 1)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.FirstMissingPositive(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        var cache = new bool[10_001];

        foreach (var num in nums)
        {
            if (num < 1 || num > cache.Length - 1)
                continue;
            cache[num] = true;
        }

        for (int i = 1; i < cache.Length; i++)
        {
            if (!cache[i])
                return i;
        }

        return 0;
    }
}