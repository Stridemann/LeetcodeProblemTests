public class Binary_Tree_Zigzag_Level_Order_Traversal
{
    [Theory]
    [InlineData("[3,9,20,null,null,15,7]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.ZigzagLevelOrder(root);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var leftRight = new Stack<TreeNode>();
        var rightLeft = new Stack<TreeNode>();
        var result = new List<IList<int>>();

        if(root == null)
            return result;

        leftRight.Push(root);

        while (leftRight.Count > 0 || rightLeft.Count > 0)
        {
            var resultleft = new List<int>();

            while (leftRight.TryPop(out var node))
            {
                resultleft.Add(node.val);

                if (node.left != null)
                    rightLeft.Push(node.left);

                if (node.right != null)
                    rightLeft.Push(node.right);
            }

            if (resultleft.Count > 0)
                result.Add(resultleft);

            var resultRight = new List<int>();

            while (rightLeft.TryPop(out var node))
            {
                resultRight.Add(node.val);

                if (node.right != null)
                    leftRight.Push(node.right);

                if (node.left != null)
                    leftRight.Push(node.left);
            }

            if (resultRight.Count > 0)
                result.Add(resultRight);
        }

        return result;
    }
}
