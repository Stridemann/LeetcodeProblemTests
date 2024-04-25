using Shouldly;

public class Reverse_String
{
    [Theory]
    [InlineData(new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' })]
    [InlineData(new char[] { 'h', 'e', 'l', 'l', 'o', 'h' }, new char[] { 'h', 'o', 'l', 'l', 'e', 'h' })]
    public void Test(char[] input, char[] expected)
    {
        var s = new Solution();
        s.ReverseString(input);
        input.ShouldBe(expected);
    }
}

public class Solution
{
    public void ReverseString(char[] s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            (s[i], s[s.Length - i - 1]) = (s[s.Length - i - 1], s[i]);
        }
    }
}
