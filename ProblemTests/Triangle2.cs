public class Triangle2
{
    [Theory]
    [InlineData(new int[] { 0 }, 2)]
    public void Test(int[] input, int expected)
    {
        var s = new Solution();
        var result = s.MinimumTotal(input);
        result.ShouldBe(expected);
    }
}

