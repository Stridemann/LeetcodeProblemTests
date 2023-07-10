public class Happy_Number
{
    [Theory]
    [InlineData(19, true)]
    public void Test(int input, bool expected)
    {
        var s = new Solution();
        var result = s.IsHappy(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsHappy(int n)
    {
        var inLoop = new HashSet<int>();

        while (inLoop.Add(n))
        {
            var squareSum = 0;

            while (n > 0)
            {
                var remain = n % 10;
                squareSum += remain * remain;
                n /= 10;
            }

            if (squareSum == 1)
                return true;
            else
                n = squareSum;
        }

        return false;
    }
}

public class Solution
{
public int Search(int[] nums, int target)
{
    int left = 0;
    int right = nums.Length - 1;

    while (left <= right)
    {
        int middle = (left + right) / 2;
        var num = nums[middle];

        if (num < target)
        {
            left = middle + 1;
        }
        else if (num > target)
        {
            right = middle - 1;
        }
        else
        {
            return middle;
        }
    }

    return -1;
}
}
