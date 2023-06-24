using System.Collections;

public class Binary_Tree_Maximum_Path_Sum
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(TreeNode head, int expected)
    {
        var s = new Solution();
        var result = s.MaxPathSum(head);
        result.ShouldBe(expected);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //yield return new object[] { new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))), 42 };

        var n1 = new TreeNode(1, new TreeNode(-1), null);

        var left = new TreeNode(-2, n1, new TreeNode(3));

        yield return new object[] { new TreeNode(1, left, new TreeNode(-3, new TreeNode(-2))), 3 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    private int _max = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        GetMax(root);

        return _max;
    }

    private int GetMax(TreeNode node)
    {
        int? leftVal = null;
        int? rightVal = null;

        if (node.left != null)
        {
            leftVal = GetMax(node.left);
        }

        if (node.right != null)
        {
            rightVal = GetMax(node.right);
        }

        var localMax = node.val;

        if (leftVal.HasValue)
        {
            var nodeVal = leftVal.Value + node.val;

            if (localMax < nodeVal)
                localMax = nodeVal;

            if (_max < nodeVal)
                _max = nodeVal;
        }

        if (rightVal.HasValue)
        {
            var nodeVal = rightVal.Value + node.val;

            if (localMax < nodeVal)
                localMax = nodeVal;

            if (_max < nodeVal)
                _max = nodeVal;
        }

        if (leftVal.HasValue && rightVal.HasValue)
        {
            var all = leftVal.Value + rightVal.Value + node.val;

            if (_max < all)
                _max = all;
        }

        if (_max < node.val)
            _max = node.val;

        return localMax;
    }
}
