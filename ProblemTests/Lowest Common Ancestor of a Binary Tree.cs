public class Lowest_Common_Ancestor_of_a_Binary_Tree
{
    [Theory]
    [InlineData("[3,5,1,6,2,0,8,null,null,7,4]", 5, 1, 3)]
    [InlineData("[3,5,1,6,2,0,8,null,null,7,4]", 5, 4, 5)]
    public void Test(
        string cfg,
        int pi,
        int qi,
        int resulti)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();

        var p = root.FindNodeWithValue(pi);
        var q = root.FindNodeWithValue(qi);

        var result = s.LowestCommonAncestor(root, p, q);
        result.ShouldBe(root.FindNodeWithValue(resulti));
    }
}

public class Solution
{
    private TreeNode _p;
    private TreeNode _q;
    private TreeNode _result;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        _q = q;
        _p = p;
        Dfs(root);

        return _result;
    }

    private bool Dfs(TreeNode? node)
    {
        if (node == null)
            return false;

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        if (left && right)
        {
            _result = node;

            return false;
        }

        if (node == _q)
        {
            if (left || right)
            {
                _result = node;

                return false;
            }

            return true;
        }

        if (node == _p)
        {
            if (left || right)
            {
                _result = node;

                return false;
            }

            return true;
        }

        return left || right;
    }
}
