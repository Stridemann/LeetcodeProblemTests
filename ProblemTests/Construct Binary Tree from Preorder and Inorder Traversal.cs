public class Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
{
    [Theory]
    [InlineData(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 })]
    public void Test(int[] arr1, int[] arr2)
    {
        var s = new Solution();
        var result = s.BuildTree(arr1, arr2);
        //result.ShouldBe(expected);
    }
}

public class Solution
{
    private int _inord;
    private int _pre;

    public TreeNode? BuildTree(int[] preorder, int[] inorder)
    {
        return Build(preorder, inorder);
    }

    private TreeNode? Build(int[] preorder, int[] inorder, int stop = int.MinValue)
    {
        if (_pre >= preorder.Length)
        {
            return null;
        }

        if (inorder[_inord] == stop)
        {
            _inord++;

            return null;
        }

        var node = new TreeNode(preorder[_pre++]);
        node.left = Build(preorder, inorder, node.val);
        node.right = Build(preorder, inorder, stop);

        return node;
    }
}
