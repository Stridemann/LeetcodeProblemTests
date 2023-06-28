public class Solution
{
    private readonly List<int> _list = new List<int>();

    public IList<int> PostorderTraversal(TreeNode? root)
    {
        Traversal(root);

        return _list;
    }

    private void Traversal(TreeNode? node)
    {
        if (node == null)
            return;

        Traversal(node.left);
        Traversal(node.right);
        _list.Add(node.val);
    }
}
