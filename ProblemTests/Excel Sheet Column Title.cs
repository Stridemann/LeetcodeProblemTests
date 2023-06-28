using System.Text;
using Shouldly;

public class Excel_Sheet_Column_Title
{
    [Theory]
    [InlineData(1, "A")]
    [InlineData(26, "Z")]
    [InlineData(27, "AA")]
    [InlineData(28, "AB")]
    [InlineData(701, "ZY")]
    public void Test(int input, string expected)
    {
        var s = new Solution();
        var result = s.ConvertToTitle(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string ConvertToTitle(int num)
    {
        var sb = new StringBuilder();

        do
        {
            var mod = (num - 1) % 26;
            sb.Insert(0, (char)('A' + mod));
            num = (num - mod) / 26;
        } while (num > 0);

        return sb.ToString();
    }
}