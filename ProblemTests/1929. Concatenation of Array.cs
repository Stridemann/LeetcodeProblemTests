using Shouldly;

public class Concatenation_of_Array
{
    [Theory]
    [InlineData(new[] { 1, 2, 1 }, new[] { 1, 2, 1, 1, 2, 1 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.GetConcatenation(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        var newArr = new int[nums.Length * 2];

        Buffer.BlockCopy(
            nums,
            0,
            newArr,
            0,
            nums.Length * 4);

        Buffer.BlockCopy(
            nums,
            0,
            newArr,
            nums.Length * 4,
            nums.Length * 4);

        return newArr;
    }
}
