using Shouldly;

public class Convert_Sorted_Array_to_Binary_Search_Tree
{
    [Theory]
    [InlineData(new[] { -10, -3, 0, 5, 9 })]
    public void Test(int[] nums)
    {
        var s = new Solution();
        var result = s.SortedArrayToBST(nums);
    }
}

public class Solution
{
    private int[] _nums;

    public TreeNode SortedArrayToBST(int[] nums)
    {
        _nums = nums;
        Array.Sort(nums);
        var root = Convert(0, nums.Length - 1, null);

        return root;
    }

    private TreeNode Convert(int left, int right, TreeNode parent)
    {
        if (left > right)
            return null;

        var mid = (left + right) / 2;
        var midVal = _nums[mid];
        var root = new TreeNode(midVal);

        root.left = Convert(left, mid - 1, root);
        root.right = Convert(mid + 1, right, root);

        return root;
    }
}
