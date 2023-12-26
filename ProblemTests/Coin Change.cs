using System.Runtime.CompilerServices;

public class Coin_Change
{
    [Theory]
    [InlineData(new[] { 1, 2, 5 }, 11, 3)]
    [InlineData(new[] { 1, 2, 5 }, 100, 20)]
    [InlineData(new[] { 186, 419, 83, 408 }, 6249, 20)]
    [InlineData(new[] { 156, 265, 40, 280 }, 9109, 35)]
    [InlineData(new[] { 243, 291, 335, 209, 177, 345, 114, 91, 313, 331 }, 7367, 23)]
    public void Test(int[] nums, int target, int expected)
    {
        var s = new Solution();
        var result = s.CoinChange(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[] _coins;
    private int _minUsed = int.MaxValue;
    private Dictionary<long, int> _cache = new Dictionary<long, int>();

    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
            return 0;
        Array.Sort(coins);
        _coins = coins;
        Iter(amount, 0, coins.Length - 1);

        return _minUsed == int.MaxValue ? -1 : _minUsed;
    }

    private int Iter(long left, int used, int i)
    {
        if (_cache.TryGetValue(left, out var amount))
        {
            return amount;
        }

        var min = -1;

        for (; i >= 0; i--)
        {
            var coin = _coins[i];
            var newLeft = left - coin;

            if (newLeft < 0)
                continue;
            var newUsed = used + 1;

            if (newLeft == 0)
            {
                if (_minUsed > newUsed)
                {
                    _minUsed = newUsed;
                }

                if (min > newUsed || min == -1)
                {
                    min = 1;

                    break;
                }
            }
            else
            {
                var curIter = Iter(newLeft, newUsed, i);

                if (curIter != -1)
                {
                    if (min > curIter || min == -1)
                        min = curIter + 1;
                }
            }
        }

        if (min != -1 && used + min < _minUsed)
            _minUsed = used + min;

        _cache[left] = min;

        return min;
    }
}
