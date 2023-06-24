using System.Collections;

public class Same_Tree
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode p, TreeNode q)
    {
        var s = new Solution();
        var result = s.IsSameTree(p, q);
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
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p?.val != q?.val)
            return false;

        if (p == null)
            return true;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
