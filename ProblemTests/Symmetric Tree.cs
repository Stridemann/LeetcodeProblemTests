using System.Collections;

public class Symmetric_Tree
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode root, bool expected)
    {
        var s = new Solution();
        var result = s.IsSymmetric(root);
        result.ShouldBe(expected);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3))), true };
        yield return new object[] { new TreeNode(1, new TreeNode(2, null, new TreeNode(3)), new TreeNode(2, null, new TreeNode(3))), false };
        yield return new object[] { new TreeNode(1, new TreeNode(2), new TreeNode(3)), false };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymmetric(root.left, root.right);
    }

    public bool IsSymmetric(TreeNode? p, TreeNode? q)
    {
        if (p?.val != q?.val)
            return false;

        if (p == null)
            return true;

        return IsSymmetric(p.left, q.right) && IsSymmetric(p.right, q.left);
    }
}
