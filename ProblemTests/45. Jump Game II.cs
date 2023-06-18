using Shouldly;

public class Jump_Game_II
{
    [Theory]
    [InlineData(new[] { 2, 3, 1, 1, 4 }, 2)]
    [InlineData(new[] { 2, 3, 0, 1, 4 }, 2)]
    [InlineData(new[] { 2, 1 }, 1)]
    [InlineData(new[] { 5,6,4,4,6,9,4,4,7,4,4,8,2,6,8,1,5,9,6,5,2,7,9,7,9,6,9,4,1,6,8,8,4,4,2,0,3,8,5 }, 10)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.Jump(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[] _nums;
    private int _target;

    public int Jump(int[] nums)
    {
        if (nums.Length <= 1)
            return 0;
        _nums = nums;
        _target = nums.Length - 1;

        return JumpNext(0, 0);
    }

    private int JumpNext(int index, int steps)
    {
        if (index == _target)
        {
            return steps;
        }

        if (steps > _target || index >= _target)
            return int.MaxValue;
        var num = _nums[index];

        if (index + num <= _target)
            return steps + 1;

        var min = int.MaxValue;

        for (int i = num; i >= 1; i--)
        {
            var result = JumpNext(index + i, steps + 1);

            if (min > result)
                min = result;
        }

        return min;
    }
}
