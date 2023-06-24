using Shouldly;
using System.Collections.Generic;
using System.Diagnostics;

public class String_Compression_II
{
    [Theory]
    [InlineData("aaabcccd", 2, 4)]
    [InlineData("aabbaa", 2, 4)]
    [InlineData("aaaaaaaaaaa", 0, 3)]
    [InlineData("aabaabbcbbbaccc", 6, 4)]
    [InlineData("llllllllllttttttttt", 1, 4)]
    [InlineData("bababbaba", 1, 7)]
    public void Test(string input, int k, int expected)
    {
        var s = new Solution();
        var result = s.GetLengthOfOptimalCompression(input, k);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    [DebuggerDisplay("{Char}[{Count}](rem {RemoveCount})")]
    private class CharSeq
    {
        public CharSeq(char c, int count)
        {
            Char = c;
            Count = count;
        }

        public char Char;
        public int Count;
        public int RemoveCount;
    }

    public int GetLengthOfOptimalCompression(string s, int k)
    {
        if (s.Length == 1)
        {
            if (k > 0)
                return 0;

            return 1;
        }

        var list = new List<CharSeq>();
        var lastChar = s[0];
        var streak = 0;
        var singleCnt = 0;
        var length = 0;

        void add(char ch, int cnt)
        {
            list.Add(new CharSeq(ch, cnt));

            if (cnt == 1)
            {
                singleCnt++;
                length++;
            }
            else
            {
                length += (int)Math.Floor(Math.Log10(cnt)) + 2;
            }
        }

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];

            if (c != lastChar)
            {
                add(lastChar, streak);
                streak = 1;
                lastChar = c;

                if (i == s.Length - 1)
                {
                    add(c, 1);
                }
            }
            else
            {
                streak++;

                if (i == s.Length - 1)
                {
                    add(lastChar, streak);
                }
            }
        }

        if (k <= singleCnt)
        {
            return length - k;
        }

        while (k > 0)
        {
            foreach (var tuple in list.OrderBy(RemoveCntOrder))
            {
                var removeCnt = tuple.RemoveCount;

                if (k < removeCnt)
                {
                    tuple.Count -= k;

                    break;
                }

                k -= removeCnt;
                tuple.Count -= removeCnt;

                if (k <= 0)
                {
                    break;
                }
            }
        }

        var newLen = 0;

        foreach (var keyValuePair in list)
        {
            if (keyValuePair.Count == 1)
                newLen++;
            else
                newLen += (int)Math.Floor(Math.Log10(keyValuePair.Count)) + 2;
        }

        return newLen;
    }

    private int RemoveCntOrder(CharSeq seq)
    {
        var cnt = seq.Count;

        if (cnt == 1 || cnt == 10)
        {
            seq.RemoveCount = 1;

            return 1;
        }

        if (cnt <= 9)
        {
            seq.RemoveCount = cnt - 1;

            return cnt - 1;
        }

        if (cnt <= 99)
        {
            seq.RemoveCount = cnt - 9;

            return cnt - 9;
        }

        //100
        seq.RemoveCount = 1;

        return 1;
    }
}
