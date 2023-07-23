public class Subtree_of_Another_Tree
{
    [Theory]
    [InlineData("[1,2]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.DiameterOfBinaryTree(root);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsSubtree(TreeNode node, TreeNode subRoot)
    {
        if (node == null)
            return false;

        if (CheckSubtree(node, subRoot))
        {
            return true;
        }

        return IsSubtree(node.left, subRoot) || IsSubtree(node.right, subRoot);
    }

    private bool CheckSubtree(TreeNode? node, TreeNode? subRoot)
    {
        if (node == null && subRoot == null)
        {
            return true;
        }

        if (node == null || subRoot == null)
        {
            return false;
        }

        if (node.val != subRoot.val)
        {
            return false;
        }

        return CheckSubtree(node.left, subRoot.left) && CheckSubtree(node.right, subRoot.right);
    }
}
