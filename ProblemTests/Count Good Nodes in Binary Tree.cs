public class Count_Good_Nodes_in_Binary_Tree
{
    [Theory]
    [InlineData("[3,1,4,3,null,1,5]", 4)]
    [InlineData("[3,3,null,4,2]", 3)]
    [InlineData("[2,null,4,10,8,null,null,4]", 4)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.GoodNodes(root);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int _good;

    public int GoodNodes(TreeNode root)
    {
        CountGood(root, root.val);

        return _good;
    }

    private void CountGood(TreeNode node, int maxNode)
    {
        if (node.val >= maxNode)
            _good++;

        if (maxNode < node.val)
            maxNode = node.val;

        if (node.left != null)
        {
            CountGood(node.left, maxNode);
        }

        if (node.right != null)
        {
            CountGood(node.right, maxNode);
        }
    }
}
