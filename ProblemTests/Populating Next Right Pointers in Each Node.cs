using System.Xml.Linq;
using Utils;

public class Populating_Next_Right_Pointers_in_Each_Node
{
    [Theory]
    [InlineData("[1,2,3,4,5,6,7]", 1)]
    public void Test(string cfg, int expected)
    {
        var root = NodeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.Connect(root);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly List<Node?> _byLevels = new List<Node?>();

    public Node Connect(Node root)
    {
        if (root == null)
            return null;
        Dfs(root, 0);

        return root;
    }

    private void Dfs(Node node, int level)
    {
        if (level == _byLevels.Count)
        {
            _byLevels.Add(node);
        }
        else
        {
            if (_byLevels[level] != null)
                _byLevels[level].next = node;
            _byLevels[level] = node;
        }

        if (node.left != null)
        {
            Dfs(node.left, level + 1);
        }

        if (node.right != null)
        {
            Dfs(node.right, level + 1);
        }
    }
}
