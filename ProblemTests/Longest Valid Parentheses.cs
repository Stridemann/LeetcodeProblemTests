public class Longest_Valid_Parentheses
{
    [Theory]
    [InlineData("(()", 2)]
    [InlineData("(()())", 6)]
    [InlineData(")()())", 4)]
    [InlineData("()(()", 2)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.LongestValidParentheses(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        var longest = 0;
        var brackets = new Stack<char>();
        var current = 0;

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    brackets.Push(')');

                    continue;
                default:

                    if (brackets.Count > 0 && brackets.Pop() == c)
                    {
                        current += 2;
                    }
                    else
                    {
                        longest = Math.Max(longest, current);
                        current = 0;
                    }

                    if (brackets.Count == 0)
                    {
                        longest = Math.Max(longest, current);
                        current = 0;
                    }

                    continue;
            }
        }

        return Math.Max(longest, current);
    }
}
