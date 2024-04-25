public class Move_Zeroes
{
    [Theory]
    [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
    [InlineData(new int[] { 0, 0}, new int[] { 0, 0 })]
    public void Test(int[] input, int[] expected)
    {
        var s = new Solution();
        s.MoveZeroes(input);
        input.ShouldBe(expected);
    }
}

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var lt = 0;
        var rt = 1;

        while (rt < nums.Length)
        {
            if (nums[lt] == 0)
            {
                while (nums[rt] == 0)
                {
                    rt++;

                    if (rt == nums.Length)
                        return;

                }

                nums[lt] = nums[rt];
                nums[rt] = 0;
            }

            lt++;
            rt++;
        }
    }

    public bool IsPowerOfThree(int n)
    {
        if(n == 0) 
            return false;

        var pwr = (int)Math.Round(Math.Log(n, 3));

        return (int)Math.Pow(3, pwr) == n;
    }
}
