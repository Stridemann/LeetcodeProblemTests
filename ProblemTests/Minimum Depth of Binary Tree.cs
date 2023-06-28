using System.Collections;

public class Minimum_Depth_of_Binary_Tree
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode root, int depth)
    {
        var s = new Solution();
        var result = s.HasPathSum(root, 10);
        result.ShouldBe(true);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new TreeNode(1, new TreeNode(2)), 2 };
        //yield return new object[] { new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))), true };

        //yield return new object[]
        //    { new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2)), false };

        //yield return new object[]
        //    { new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8)), new TreeNode(5)), new TreeNode(3, new TreeNode(6))), true };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    private int _targetSum;
    private bool _found;

    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root == null)
            return false;
        _targetSum = targetSum;
        CheckSum(root, 0);

        return _found;
    }

    private bool CheckSum(TreeNode? node, int sum)
    {
        if (node == null || _found)
            return false;

        var curSum = node.val + sum;

        if (curSum == _targetSum && node.left == null && node.right == null)
            return _found = true;

        return CheckSum(node.left, curSum) || CheckSum(node.right, curSum);
    }
}
