using System.Text;
using Shouldly;

public class ultiply_Strings

{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("4", "3", "12")]
    [InlineData("10", "10", "100")]
    [InlineData("123", "456", "56088")]
    [InlineData("756", "32", "24192")]
    public void Test(string a, string b, string expected)
    {
        var s = new Solution();
        var result = s.Multiply(a, b);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string Multiply(string a, string b)
    {
        if (a.Length == 1 && a[0] == '0')
            return "0";

        if (b.Length == 1 && b[0] == '0')
            return "0";
        var sb = new StringBuilder(a.Length * b.Length);

        ReadOnlySpan<char> maxStr;
        ReadOnlySpan<char> minStr;

        if (a.Length > b.Length)
        {
            maxStr = a.AsSpan();
            minStr = b.AsSpan();
        }
        else
        {
            minStr = a.AsSpan();
            maxStr = b.AsSpan();
        }

        void AddVal(int indexFromEnd, int val)
        {
            while (indexFromEnd >= sb.Length)
            {
                sb.Insert(0, '0');
            }

            var finalIndex = sb.Length - indexFromEnd - 1;
            var curVal = sb[finalIndex];
            val += curVal - '0';

            sb[finalIndex] = (char)('0' + val % 10);
            var reminder = val / 10;

            if (reminder > 0)
            {
                AddVal(indexFromEnd + 1, reminder);
            }
        }

        for (int s2 = minStr.Length - 1; s2 >= 0; s2--)
        {
            var n1 = minStr[s2] - '0';
            var indexFromEnd = minStr.Length - 1 - s2;

            for (int s1 = maxStr.Length - 1; s1 >= 0; s1--)
            {
                var n2 = maxStr[s1] - '0';
                AddVal(indexFromEnd, n2 * n1);
                indexFromEnd++;
            }
        }

        return sb.ToString();
    }
}
