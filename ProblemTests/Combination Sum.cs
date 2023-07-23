public class Combination_Sum
{
    [Theory]
    [InlineData(new[] { 2, 3, 6, 7 }, 7)]
    [InlineData(new[] { 2, 3, 5 }, 8)]
    [InlineData(new[] { 2 }, 1)]
    public void Test(int[] nums, int target)
    {
        var s = new Solution();
        var result = s.CombinationSum(nums, target);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly List<int> _temp = new List<int>();
    private List<IList<int>> _result;
    private int[] _candidates;

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        _candidates = candidates;
        Array.Sort(candidates);
        _result = new List<IList<int>>();

        GatherResults(target, 0);

        return _result;
    }

    private void GatherResults(int target, int index)
    {
        if (target == 0)
        {
            _result.Add(new List<int>(_temp));

            return;
        }

        for (; index < _candidates.Length; index++)
        {
            var candidate = _candidates[index];

            if (target - candidate < 0)
                return;

            _temp.Add(_candidates[index]);
            GatherResults(target - candidate, index);
            _temp.RemoveAt(_temp.Count - 1);
        }
    }
}
