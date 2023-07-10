using Shouldly;
using System.Linq;

public class Valid_Anagram
{
    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData(
        "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
        "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbba",
        false)]
    public void Test(string input, string t, bool expected)
    {
        var s = new Solution();
        var result = s.IsAnagram(input, t);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        var arr = new int['z' - 'a' + 1];

        foreach (var ch in s)
        {
            arr[ch - 'a']++;
        }

        foreach (var ch in t)
        {
            arr[ch - 'a']--;
        }

        foreach (var i in arr)
        {
            if (i != 0)
                return false;
        }

        return true;
    }
}
