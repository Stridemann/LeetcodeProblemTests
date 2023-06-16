using Shouldly;

public class Valid_Palindrome
{
    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData("ab", false)]
    [InlineData("0P", false)]
    public void Test(string a, bool expected)
    {
        var s = new Solution();
        s.IsPalindrome(a).ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsPalindrome(string s)
    {
        if (s.Length <= 1)
            return true;

        var left = 0;
        var right = s.Length - 1;

        while (true)
        {
            if (left > right)
                return true;

            var ls = s[left];
            var rs = s[right];

            if (!char.IsLetterOrDigit(ls))
            {
                left++;

                continue;
            }

            if (!char.IsLetterOrDigit(rs))
            {
                right--;

                continue;
            }

            if (char.ToLower(ls) != char.ToLower(rs))
                return false;
            left++;
            right--;
        }
    }
}
