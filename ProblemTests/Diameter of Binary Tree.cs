public class Diameter_of_Binary_Tree
{
    [Theory]
    [InlineData("[1,2,3,4,5]", 3)]
    [InlineData("[1,2]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.DiameterOfBinaryTree(root);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int _maxDepth;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        CheckDepth(root);

        return _maxDepth;
    }

    private int CheckDepth(TreeNode node)
    {
        if (node == null)
            return 0;

        var lt = CheckDepth(node.left);
        var rt = CheckDepth(node.right);

        if (node.left != null)
            lt++;

        if (node.right != null)
            rt++;

        var max = lt + rt;

        if (_maxDepth < max)
            _maxDepth = max;

        var max2 = Math.Max(lt, rt);

        if (_maxDepth < max)
            _maxDepth = max;

        return max2;
    }
}
