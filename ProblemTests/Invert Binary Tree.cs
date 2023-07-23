public class Invert_Binary_Tree
{
    [Theory]
    [InlineData("[4,2,7,1,3,6,9]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.InvertTree(root);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;
        (root.right, root.left) = (root.left, root.right);
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}
