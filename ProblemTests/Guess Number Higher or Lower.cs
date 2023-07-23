using System.Diagnostics;

public class Guess_Number_Higher_or_Lower
{
    [Theory]
    [InlineData(10, 6)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    public void Test(int input, int expected)
    {
        var s = new Solution(expected);
        var result = s.GuessNumber(input);
        result.ShouldBe(expected);
    }
}

public class GuessGame
{
    private readonly int _target;

    public GuessGame(int target)
    {
        _target = target;
    }

    [DebuggerStepThrough]
    protected int guess(int middle)
    {
        return _target.CompareTo(middle);
    }
}

public class Solution : GuessGame
{
    public Solution(int target) : base(target)
    {
    }

    public int GuessNumber(int n)
    {
        var lo = 1;
        var hi = n;
        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;
            var guessNum = guess(mid);
            if (guessNum == 0)
                return mid;
            if (guessNum == -1)
                hi = mid - 1;
            else
                lo = mid + 1;
        }
        return -1;
    }
}
