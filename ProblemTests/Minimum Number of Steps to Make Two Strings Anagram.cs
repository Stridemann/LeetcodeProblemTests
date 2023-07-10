using Shouldly;

public class Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram
{
    [Theory]
    [InlineData("bab", "aba", 1)]
    [InlineData("leetcode", "practice", 5)]
    [InlineData("anagram", "mangaar", 0)]
    public void Test(string s, string t, int expected)
    {
        var sol = new Solution();
        var result = sol.MinSteps(s, t);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MinSteps(string s, string t)
    {
        var freq = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
            freq[t[i] - 'a']--;
        }

        int steps = 0;

        foreach (int count in freq)
        {
            if (count > 0)
            {
                steps += count;
            }
        }

        return steps;
    }
}
