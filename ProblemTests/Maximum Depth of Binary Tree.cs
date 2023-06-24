using System.Collections;

public class Maximum_Depth_of_Binary_Tree
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode root)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(root);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new TreeNode(0) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    private int _max = 0;

    public int MaxDepth(TreeNode root)
    {
        Deeper(root, 1);

        return _max;
    }

    private void Deeper(TreeNode node, int depth)
    {
        if (node == null)
            return;

        if (_max < depth)
            _max = depth;
        Deeper(node.right, depth + 1);
        Deeper(node.left, depth + 1);
    }
}
