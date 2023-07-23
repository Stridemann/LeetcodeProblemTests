using Shouldly;

public class Daily_Temperatures
{
    [Theory]
    [InlineData(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    [InlineData(new[] { 89, 62, 70, 58, 47, 47, 46, 76, 100, 70 }, new[] { 8, 1, 5, 4, 3, 2, 1, 1, 0, 0 })]
    public void Test(int[] nums, int[] expected)
    {
        var s = new Solution();
        var result = s.DailyTemperatures(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<ValueTuple<int, int>>();

        for (var i = temperatures.Length - 1; i >= 0; i--)
        {
            var temperature = temperatures[i];

            while (stack.Count > 0 && stack.Peek().Item1 <= temperature)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                temperatures[i] = stack.Peek().Item2 - i;
            }
            else
            {
                temperatures[i] = 0;
            }

            stack.Push((temperature, i));
        }

        return temperatures;
    }
}
