public class Subsets
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Subsets(nums);
    }
}

public class Solution
{
    private readonly Stack<int> _queue = new Stack<int>();
    private List<IList<int>> _result;
    private int[] _nums;

    public IList<IList<int>> Subsets(int[] nums)
    {
        _nums = nums;
        _result = new List<IList<int>>();

        GetSubset(0);

        return _result;
    }

    private void GetSubset(int curNum)
    {
        if (curNum >= _nums.Length)
        {
            _result.Add(new List<int>(_queue.Reverse()));

            return;
        }

        var item = _nums[curNum];
        _queue.Push(item);
        GetSubset(curNum + 1);
        _queue.Pop();
        GetSubset(curNum + 1);
    }
}
