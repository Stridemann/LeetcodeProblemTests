using Shouldly;

public class Substring_with_Concatenation_of_All_Words
{
    [Theory]
    [InlineData("barfoothefoobarman", 2)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int RemoveNthFromEnd(string input, int n)
    {
    }
}

