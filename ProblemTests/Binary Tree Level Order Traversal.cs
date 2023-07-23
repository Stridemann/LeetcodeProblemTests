using System.Xml.Linq;

public class Binary_Tree_Level_Order_Traversal
{
    [Theory]
    [InlineData("[3,9,20,null,null,15,7]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.LevelOrder(root);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();

        if (root == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var level = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var cur = queue.Dequeue();
                level.Add(cur.val);

                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }

                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }

            result.Add(level);
        }

        return result;
    }
}
