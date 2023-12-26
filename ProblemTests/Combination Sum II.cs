public class Combination_Sum_II
{
    [Theory]
    [InlineData(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.CombinationSum2(nums, expected);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[] _nums;
    private readonly List<IList<int>> _result = new List<IList<int>>();
    private readonly List<int> _subset = new List<int>();
    private int _target;

    public IList<IList<int>> CombinationSum2(int[] nums, int target)
    {
        _target = target;
        _nums = nums;

        Array.Sort(_nums);

        Backtrack(0, 0);

        return _result;
    }

    private void Backtrack(int i, int curSum)
    {
        if (i == _nums.Length)
        {
            if (curSum == _target)
                _result.Add(_subset.ToList());

            return;
        }

        var curNum = _nums[i];
        var newSum = curSum + curNum;

        if (newSum <= _target)
        {
            _subset.Add(curNum);
            Backtrack(i + 1, newSum);
            _subset.RemoveAt(_subset.Count - 1);
        }

        while (i + 1 < _nums.Length && _nums[i] == _nums[i + 1])
        {
            i++;
        }

        Backtrack(i + 1, curSum);
    }
}
