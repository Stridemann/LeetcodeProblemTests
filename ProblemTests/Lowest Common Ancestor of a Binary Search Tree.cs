public class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
{
    [Theory]
    [InlineData("[6,2,8,0,4,7,9,null,null,3,5]", 2, 8, 6)]
    [InlineData("[6,2,8,0,4,7,9,null,null,3,5]", 2, 4, 2)]
    public void Test(
        string cfg,
        int p,
        int q,
        int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var pn = root.FindNodeWithValue(p);
        var qn = root.FindNodeWithValue(q);
        var result = s.LowestCommonAncestor(root, pn, qn);
        result.val.ShouldBe(expected);
    }
}

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var node = root;

        while (true)
        {
            if (node == p)
            {
                return p;
            }

            if (node == q)
            {
                return q;
            }

            if (p.val < node.val && q.val < node.val)
            {
                node = node.left;
            }

            else if (p.val > node.val && q.val > node.val)
            {
                node = node.right;
            }
            else
            {
                return node;
            }
        }
    }
}
