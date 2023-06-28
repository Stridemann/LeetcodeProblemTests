using System.Collections;

public class Balanced_Binary_Tree
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode root, bool expected)
    {
        var s = new Solution();
        var result = s.IsBalanced(root);
        result.ShouldBe(expected);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))), true };

        yield return new object[]
            { new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2)), false };

        yield return new object[]
            { new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8)), new TreeNode(5)), new TreeNode(3, new TreeNode(6))), true };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    private bool _isBalanced = true;

    public bool IsBalanced(TreeNode root)
    {
        CheckBalanced(root);

        return _isBalanced;
    }

    private int CheckBalanced(TreeNode? node)
    {
        if (node == null || !_isBalanced)
        {
            return 0;
        }

        var d1 = CheckBalanced(node.left);
        var d2 = CheckBalanced(node.right);

        if (Math.Abs(d1 - d2) > 1)
            _isBalanced = false;

        return Math.Max(d1, d2) + 1;
    }
}
