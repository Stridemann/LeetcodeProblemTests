public class Wiggle_Sort_II
{
    [Theory]
    [InlineData(new int[] { 1, 5, 1, 1, 6, 4 }, new int[] { 1, 6, 1, 5, 1, 4 })]
    [InlineData(new int[] { 1,3,2,2,3,1 }, new int[] { 2,3,1,3,1,2 })]
    public void Test(int[] input, int[] expected)
    {
        var s = new Solution();
        s.WiggleSort(input);
        input.ShouldBe(expected);
    }
}

public class Solution
{
    public void WiggleSort(int[] nums)
    {
        var countArray = new int[5001];

        foreach (var num in nums)
        {
            countArray[num]++;
        }

        var cntptr = countArray.Length - 1;

        for (int i = 1; i < nums.Length; i += 2)
        {
            while (countArray[cntptr] <= 0)
            {
                cntptr--;
            }

            nums[i] = cntptr;
            countArray[cntptr]--;
        }

        cntptr = countArray.Length - 1;

        for (int i = 0; i < nums.Length; i += 2)
        {
            while (countArray[cntptr] <= 0)
            {
                cntptr--;
            }

            nums[i] = cntptr;
            countArray[cntptr]--;
        }
    }
}
