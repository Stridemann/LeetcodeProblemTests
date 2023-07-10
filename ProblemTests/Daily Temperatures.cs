using Shouldly;

public class Daily_Temperatures
{
    [Theory]
    [InlineData(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.DailyTemperatures(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var tempOrdered = temperatures.Select((t, i) => new { t, i }).OrderBy(x => x.i).ToList();
        var result = new int[temperatures.Length];

        foreach (var temp in tempOrdered)
        {

        }
    }
}
