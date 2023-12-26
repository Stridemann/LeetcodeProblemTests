using System.Text;

public class Palindrome_Partitioning
{
    [Theory]
    [InlineData("aab", 2)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.Partition(input);
        result.Count.ShouldBe(expected);
    }
}

public class Solution
{
    private string _s;
    private List<IList<string>> _result;
    private readonly List<string> _subset = new List<string>();

    public IList<IList<string>> Partition(string s)
    {
        _s = s;
        _result = new List<IList<string>>();

        GetSubset(0);

        return _result;
    }

    private void GetSubset(int i)
    {
        if (i >= _s.Length)
        {
            _result.Add(new List<string>(_subset.ToList()));

            return;
        }

        for (int j = i; j < _s.Length; j++)
        {
            if (IsPalindrome(i, j))
            {
                _subset.Add(_s.Substring(i, j - i + 1));
                GetSubset(j + 1);
                _subset.RemoveAt(_subset.Count - 1);
            }
        }
    }

    private bool IsPalindrome(int left, int right)
    {
        while (left <= right)
        {
            if (_s[left++] != _s[right--])
                return false;
        }

        return true;
    }
}
