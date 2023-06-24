using Shouldly;

public class Merge_Sorted_Array
{
    [Theory]
    [InlineData(
        new[] { 1, 2, 3, 0, 0, 0 },
        3,
        new[] { 2, 5, 6 },
        2,
        new int[] { 1, 2, 2, 3, 5, 6 })]

    [InlineData(
        new[] { 2,0},
        1,
        new[] { 1 },
        1,
        new int[] { 1, 2})]
    public void Test(
        int[] nums1,
        int m,
        int[] nums2,
        int n,
        int[] expected)
    {
        var s = new Solution();
        s.Merge(nums1, m, nums2, n);
        nums1.ShouldBe(expected);
    }
}

public class Solution
{
    public void Merge(
        int[] nums1,
        int m,
        int[] nums2,
        int n)
    {
        if (m == 0 && n == 1)
        {
            nums1[0] = nums2[0];
            return;
        }
        var num1Ptr = m - 1;
        var num2Ptr = nums2.Length - 1;
        var writePtr = nums1.Length - 1;

        while (num2Ptr >= 0 && num1Ptr >= 0)
        {
            var num1 = nums1[num1Ptr];
            var num2 = nums2[num2Ptr];

            if (num2 > num1)
            {
                nums1[writePtr--] = num2;
                num2Ptr--;
            }
            else
            {
                nums1[writePtr--] = num1;
                num1Ptr--;
            }
        }

        while (num2Ptr >= 0)
        {
            nums1[writePtr--] = nums2[num2Ptr];
            num2Ptr--;
        }
    }
}
