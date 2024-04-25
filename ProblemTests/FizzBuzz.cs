public class FizzBuzz
{
    [Theory]
    [InlineData(15)]
    public void Test(int input)
    {
        var s = new Solution();
        s.fizzBuzz(input);
    }
}

public class Solution
{
    public void fizzBuzz(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
