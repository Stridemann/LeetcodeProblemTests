using System.Text;
using Shouldly;

public class Integer_to_Roman
{
    [Theory]
    [InlineData(3, "III")]
    [InlineData(58, "LVIII")]
    [InlineData(20, "XX")]
    [InlineData(1994, "MCMXCIV")] //1000+(100+1000)(10+100)(1+5)
    public void Test(int a, string expected)
    {
        var s = new Solution();
        s.IntToRoman(a).ShouldBe(expected);
    }
}

public class Solution
{
    private static readonly KeyValuePair<int, string>[] _numerals = new[]
    {
        new KeyValuePair<int, string>(1000, "M"),
        new KeyValuePair<int, string>(900, "CM"),
        new KeyValuePair<int, string>(500, "D"),
        new KeyValuePair<int, string>(400, "CD"),
        new KeyValuePair<int, string>(100, "C"),
        new KeyValuePair<int, string>(90, "XC"),
        new KeyValuePair<int, string>(50, "L"),
        new KeyValuePair<int, string>(40, "XL"),
        new KeyValuePair<int, string>(10, "X"),
        new KeyValuePair<int, string>(9, "IX"),
        new KeyValuePair<int, string>(5, "V"),
        new KeyValuePair<int, string>(4, "IV"),
        new KeyValuePair<int, string>(3, "III"),
        new KeyValuePair<int, string>(2, "II"),
        new KeyValuePair<int, string>(1, "I"),
    };

    public string IntToRoman(int num)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < _numerals.Length; i++)
        {
            var numeral = _numerals[i];
            var nNum = num / numeral.Key;
            num -= numeral.Key * nNum;

            for (int j = 0; j < nNum; j++)
            {
                sb.Append(numeral.Value);
            }
        }

        return sb.ToString();
    }
}
