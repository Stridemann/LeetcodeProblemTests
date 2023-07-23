using System.Diagnostics;

public class Longest_Repeating_Character_Replacement
{
    [Theory]
    [InlineData("ABAB", 2, 4)]
    [InlineData("AABABBA", 1, 4)]
    [InlineData("AAAB", 0, 3)]
    [InlineData("ABAA", 0, 2)]
    public void Test(string input, int k, int expected)
    {
        var s = new Solution();
        var result = s.CharacterReplacement(input, k);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        var chars = new int[26];
        var max = 0;
        var left = 0;
        var right = 0;

        var freqChar = ' ';
        var freqCharCnt = 0;
        var length = 0;
        
        bool satisfies()
        {
            if (k == 0)
            {
                return length <= freqCharCnt;
            }

            return length - freqCharCnt <= k;
        }

        while (right < s.Length && left < s.Length && left <= right)
        {
            if (satisfies())
            {
                var newChar = s[right++];
                var newCharIndex = newChar - 'A';
                var newCount = ++chars[newCharIndex];
                length++;

                if (freqCharCnt < newCount)
                {
                    freqCharCnt = newCount;
                    freqChar = newChar;
                }

                if (satisfies() && max < length)
                {
                    max = length;
                }
            }
            else
            {
                length--;
                var decrChar = s[left++];
                var decrCharIndex = decrChar - 'A';
                --chars[decrCharIndex];
                
                if (freqChar == decrChar)
                {
                    freqCharCnt--;

                    for (var i = 0; i < chars.Length; i++)
                    {
                        var cacheCharCnt = chars[i];

                        if (freqCharCnt < cacheCharCnt)
                        {
                            freqCharCnt = cacheCharCnt;
                            freqChar = (char)('A' + i);
                        }
                    }
                }
            }
        }

        return max;
    }
}
