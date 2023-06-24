using Shouldly;

public class String_Compression
{
    [Theory]
    [InlineData(new[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }, 6, new[] { 'a', '2', 'b', '2', 'c', '3' })]
    [InlineData(new[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }, 4, new[] { 'a', 'b', '1', '2' })]
    public void Test(char[] chars, int expected, char[] expChars)
    {
        var s = new Solution();
        var result = s.Compress(chars);
        result.ShouldBe(expected);

        for (int i = 0; i < expected; i++)
        {
            chars[i].ShouldBe(expChars[i]);
        }
    }
}

public class Solution
{
    public int Compress(char[] chars)
    {
        if (chars.Length == 0)
            return 0;
        var writePos = 0;
        var lastChar = chars[0];
        var streak = 0;

        void add(char ch, int cnt)
        {
            chars[writePos++] = ch;

            if (cnt > 1)
            {
                var cntStr = cnt.ToString();

                for (int i = 0; i < cntStr.Length; i++)
                {
                    chars[writePos++] = cntStr[i];
                }
            }
        }

        for (var i = 0; i < chars.Length; i++)
        {
            var c = chars[i];

            if (c != lastChar)
            {
                add(lastChar, streak);

                streak = 1;
                lastChar = c;

                if (i == chars.Length - 1)
                {
                    add(c, 1);
                }
            }
            else
            {
                streak++;

                if (i == chars.Length - 1)
                {
                    add(lastChar, streak);
                }
            }
        }

        return writePos;
    }
}
