public class Subsets_II
{
    [Theory]
    [InlineData(new[] { 1, 2, 2 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.SubsetsWithDup(nums);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[] _nums;
    private List<IList<int>> _result;
    private List<int> _subset;

    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        _nums = nums;
        _result = new List<IList<int>>();
        _subset = new List<int>();
        Backtrack(0);

        return _result;
    }

private void Backtrack(int i)
{
    if (i == _nums.Length)
    {
        _result.Add(_subset.ToList());

        return;
    }
    _subset.Add(_nums[i]);
    Backtrack(i + 1);
    _subset.RemoveAt(_subset.Count - 1);
    while (i + 1 < _nums.Length && _nums[i] == _nums[i + 1])
    {
        i++;
    }
    Backtrack(i + 1);
}
}
