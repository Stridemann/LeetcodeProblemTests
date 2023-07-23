public class Binary_Tree_Right_Side_View
{
    [Theory]
    [InlineData("[1,2,3,null,5,null,4]", new int[] { 1, 3, 4 })]
    public void Test(string cfg, int[] expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.RightSideView(root);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var levelCount = queue.Count;

            for (int i = 0; i < levelCount; i++)
            {
                var node = queue.Dequeue();

                if (node.right != null)
                    queue.Enqueue(node.right);

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (i == 0)
                    result.Add(node.val);
            }
        }

        return result;
    }
}
