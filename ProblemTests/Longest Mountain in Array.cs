public class Longest_Mountain_in_Array
{
    [Theory]
    [InlineData(new[] { 2, 1, 4, 7, 3, 2, 5 }, 5)]
    [InlineData(new[] { 2, 2, 2 }, 0)]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0 }, 11)]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0)]
    [InlineData(new[] { 0, 2, 2 }, 0)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.LongestMountain(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LongestMountain(int[] A)
    {
        var len = A.Length;
        var ans = 0;
        var bse = 0;

        while (bse < len)
        {
            var end = bse;

            if (end + 1 < len && A[end] < A[end + 1])
            {
                while (end + 1 < len && A[end] < A[end + 1])
                {
                    end++;
                }

                if (end + 1 < len && A[end] > A[end + 1])
                {
                    while (end + 1 < len && A[end] > A[end + 1])
                    {
                        end++;
                    }

                    ans = Math.Max(ans, end - bse + 1);
                }
            }

            bse = Math.Max(end, bse + 1);
        }

        return ans;
    }
}
