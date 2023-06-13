using System.Text;
using Shouldly;

public class Letter_Combinations_of_a_Phone_Number
{
    [Theory]
    [InlineData("2", new[] { "a", "b", "c" })]
    [InlineData("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [InlineData("", new string[] { })]
    public void Test1(string digits, string[] expectedRes)
    {
        var s = new Solution();
        var result = s.LetterCombinations(digits);
        result.Count.ShouldBe(expectedRes.Length);

        for (int i = 0; i < expectedRes.Length; i++)
        {
            result.Contains(expectedRes[i]).ShouldBeTrue();
        }
    }
}

public class Solution
{
    private static string[] Chars = new[]
    {
        "abc",
        "def",
        "ghi",
        "jkl",
        "mno",
        "pqrs",
        "tuv",
        "wxyz"
    };

    private List<string> _result;

    public IList<string> LetterCombinations(string digits)
    {
        _result = new List<string>();

        if (digits.Length > 0)
        {
            Generate(digits, 0, string.Empty);
        }

        return _result;
    }

    private void Generate(string digits, int curDepth, string currentComb)
    {
        var digit = digits[curDepth] - 50;
        var digitChars = Chars[digit];

        for (int i = 0; i < digitChars.Length; i++)
        {
            var comb = currentComb + digitChars[i];
            var newDepth = curDepth + 1;

            if (digits.Length > newDepth)
            {
                Generate(digits, newDepth, comb);
            }
            else
            {
                _result.Add(comb);
            }
        }
    }
}
