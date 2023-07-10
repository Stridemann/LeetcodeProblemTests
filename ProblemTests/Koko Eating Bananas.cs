public class Koko_Eating_Bananas
{
    [Theory]
    [InlineData(new[] { 3, 6, 7, 11 }, 8)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        Array.Sort(piles);
        var left = h - piles.Length;



    }
}
