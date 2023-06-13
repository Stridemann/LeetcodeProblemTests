using Shouldly;

public class Find_the_Index_of_the_First_Occurrence_in_a_String
{
    [Theory]
    [InlineData("sadbutsad", "sad", 0)]
    [InlineData("leetcode", "leeto", -1)]
    [InlineData("leeto", "leeto", 0)]
    [InlineData("abc", "c", 2)]
    public void Test(string haystack, string needle, int expected)
    {
        var s = new Solution();
        var result = s.StrStr(haystack, needle);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle, StringComparison.InvariantCulture);
    }
}
