using Shouldly;

public class Longest_Palindromic_Substring
{
    [Theory]
    [InlineData("babad", "bab")]
    public void Test(string input, string expected)
    {
        var s = new Solution();
        var result = s.LongestPalindrome(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string LongestPalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            
        }
    }
}
