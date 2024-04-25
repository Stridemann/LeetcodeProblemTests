public class Excel_Sheet_Column_Number
{
    [Theory]
    [InlineData("A", 1)]
    [InlineData("AB", 28)]
    [InlineData("ZY", 701)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.TitleToNumber(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int TitleToNumber(string columnTitle)
    {
        var total = 0;

        foreach (var c in columnTitle)
        {
            total *= 26;
            var cur = c - 'A' + 1;
            total += cur;
        }

        return total;
    }
}
