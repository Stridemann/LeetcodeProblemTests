public class Count_Primes
{
    [Theory]
    [InlineData(10, 4)]
    [InlineData(4, 2)]
    [InlineData(5, 2)]
    [InlineData(3, 1)]
    [InlineData(2, 0)]
    [InlineData(7, 3)]
    public void Test(int input, int expected)
    {
        var s = new Solution();
        var result = s.CountPrimes(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int CountPrimes(int n)
    {
        switch (n)
        {
            case 0:
            case 1:
                return 0;
            case 2: return 0;
            case 3: return 1;
            case 4:
            case 5: return 2;
        }

        var primes = new bool[n];
        Array.Fill(primes, true);
        var primesCnt = n - 2;

        for (int p = 2; p * p < n; p++)
        {
            if (primes[p])
            {
                for (int i = p * p; i < n; i += p)
                {
                    if (primes[i])
                    {
                        primes[i] = false;
                        primesCnt--;
                    }
                }
            }
        }

        return primesCnt;
    }
}
