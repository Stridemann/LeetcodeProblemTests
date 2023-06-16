using Shouldly;

public class Plus_One
{
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
    [InlineData(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [InlineData(new[] { 9 }, new[] { 1, 0 })]
    [InlineData(new[] { 9, 9 }, new[] { 1, 0, 0 })]
    [InlineData(new[] { 8, 9, 9, 9 }, new[] { 9, 0, 0, 0 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        s.PlusOne(nums).ShouldBe(expected);
    }
}

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            var num = ++digits[i];

            if (num == 10)
            {
                digits[i] = 0;
            }
            else
            {
                return digits;
            }
        }

        var newDigits = new int[digits.Length + 1];
        newDigits[0] = 1;

        Array.Copy(
            digits,
            0,
            newDigits,
            1,
            digits.Length);

        return newDigits;
    }
}
