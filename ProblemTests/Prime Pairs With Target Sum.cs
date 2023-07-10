using Shouldly;

public class Prime_Pairs_With_Target_Sum
{
    [Theory]
    [InlineData(10, 2)]
    public void Test(int input, int expected)
    {
        var s = new Solution();
        var result = s.FindPrimePairs(input);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<IList<int>> FindPrimePairs(int n)
    {
        var primes = new bool[n + 1];
        Array.Fill(primes, true);

        // Finding prime numbers using Sieve of Eratosthenes algorithm
        for (int p = 2; p * p <= n; p++)
        {
            if (primes[p])
            {
                // Marking multiples of p as non-prime
                for (int i = p * p; i <= n; i += p)
                    primes[i] = false;
            }
        }

        var result = new List<IList<int>>();

        for (int i = 2; i <= (n - 1); i++)
        {
            int j = n - i; // Finding the complement of i to make the sum n

            if (primes[i] && primes[j] && i <= j)
            {
                result.Add(new List<int> { i, j });
            }
        }

        return result;
    }
}
