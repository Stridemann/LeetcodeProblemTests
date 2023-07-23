public class Validate_Binary_Search_Tree
{
    [Theory]
    [InlineData("[2,1,3]", true)]
    [InlineData("[5,1,4,null,null,3,6]", false)]
    public void Test(string cfg, bool expected)
    {
        var root = TreeUtils.FromString(cfg);
        var s = new Solution();
        var result = s.IsValidBST(root);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        return Validate(root, out _);
    }

    private bool Validate(TreeNode node, out (int min, int max) minMax)
    {
        minMax = (node.val, node.val);

        if (node.left != null)
        {
            if (!Validate(node.left, out var ltMinMax))
            {
                return false;
            }

            if (ltMinMax.max >= node.val)
            {
                return false;
            }

            minMax.min = Math.Min(minMax.min, ltMinMax.min);
        }

        if (node.right != null)
        {
            if (!Validate(node.right, out var rtMinMax))
            {
                return false;
            }

            if (rtMinMax.min <= node.val)
            {
                return false;
            }

            minMax.max = Math.Max(minMax.max, rtMinMax.max);
        }

        return true;
    }
}
