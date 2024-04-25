public class Fraction_to_Recurring_Decimal
{
    [Theory]
    [InlineData(1, 2, "0.5")]
    public void Test(int numerator, int denominator, string expected)
    {
        var s = new Solution();
        var result = s.FractionToDecimal(numerator, denominator);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
    }
}
