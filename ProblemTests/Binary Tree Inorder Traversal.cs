using System.Collections;

public class Binary_Tree_Inorder_Traversal
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode root, int expected)
    {
        var s = new Solution();
        var result = s.InorderTraversal(root);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new TreeNode(1, null, new TreeNode(2, new TreeNode(3))), 1 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        Travel(root, result);

        return result;
    }

    private void Travel(TreeNode node, List<int> list)
    {
        if (node == null) return;

        Travel(node.left, list);
        list.Add(node.val);
        Travel(node.right, list);
    }
}
