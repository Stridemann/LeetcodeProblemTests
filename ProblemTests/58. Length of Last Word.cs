using Shouldly;

public class Length_of_Last_Word
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    [InlineData("a ", 1)]
    [InlineData("a", 1)]
    [InlineData("day", 3)]
    public void Test(string a, int expected)
    {
        var s = new Solution();
        s.LengthOfLastWord(a).ShouldBe(expected);
    }
}

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        if (s.Length == 1)
            return 1;
        var lastNonSpace = -1;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            var ch = s[i];

            if (lastNonSpace == -1)
            {
                if (ch != ' ')
                {
                    lastNonSpace = i;
                }
            }
            else if (ch == ' ')
            {
                var len = lastNonSpace - i;

                return len;
            }
        }

        return lastNonSpace + 1;
    }
}
