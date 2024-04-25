public class FastFloydAlgoTest
{
    [Theory]
    [InlineData(new int[] { 1 }, false)]
    [InlineData(new int[] { 1, 1 }, false)]
    [InlineData(new int[] { 1, 3, 4 }, false)]
    [InlineData(new int[] { 1, 3, 4, 4 }, true)]
    [InlineData(new int[] { 1, 6, 8, 3, 9, 8, 9, 2, 3, 8 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 }, true)]
    public void Test(int[] input, bool expected)
    {
        var s = new Solution();
        var result = s.Floyd(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool Floyd(int[] input)
    {
        var iterator = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (iterator >= input.Length)
                return true;
        }

        return false;
    }
}
