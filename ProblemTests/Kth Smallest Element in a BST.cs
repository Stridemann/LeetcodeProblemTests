public class Kth_Smallest_Element_in_a_BST
{
    [Theory]
    [InlineData("[3,1,4,null,2]", 1, 1)]
    [InlineData("[5,3,6,2,4,null,null,1]", 3, 3)]
    [InlineData("[1]", 1, 1)]
    [InlineData("[1,null,2]", 2, 2)]
    public void Test(string cfg, int k, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.KthSmallest(root, k);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        GetElement(root, ref k, out var value);

        return value;
    }

    private bool GetElement(TreeNode node, ref int counter, out int value)
    {
        if (node.left != null)
        {
            if (GetElement(node.left, ref counter, out value))
            {
                return true;
            }
        }

        if (--counter == 0)
        {
            value = node.val;

            return true;
        }

        if (node.right != null)
        {
            if (GetElement(node.right, ref counter, out value))
            {
                return true;
            }
        }

        value = 0;

        return false;
    }
}
