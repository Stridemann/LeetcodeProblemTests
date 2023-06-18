using Shouldly;

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
    private List<IList<int>> _result;

    public IList<IList<int>> Subsets(int[] nums)
    {
        _result = new List<IList<int>> { Array.Empty<int>() };

        if (nums.Length == 0)
            return _result;
        _result.Add(nums);

        if (nums.Length == 1)
            return _result;

        foreach (var num in nums)
        {
            _result.Add(new List<int> { num });
        }

        for (int i = 0; i < nums.Length; i++)
        {
            GetSubset(nums, i);
        }

        return _result;
    }

    private void GetSubset(int[] nums, int exceptIndex)
    {
        if (nums.Length <= 2)
            return;

        var newArr = new int[nums.Length - 1];

        if (exceptIndex > 0)
            Array.Copy(nums, newArr, exceptIndex);

        if (exceptIndex != nums.Length - 1)
        {
            Array.Copy(
                nums,
                exceptIndex + 1,
                newArr,
                exceptIndex,
                nums.Length - exceptIndex - 1);
        }

        _result.Add(newArr);

        for (int i = 0; i < newArr.Length; i++)
        {
            GetSubset(newArr, i);
        }
    }
}
