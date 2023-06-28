using System.Diagnostics;

[DebuggerDisplay("[{val}, {left?.val}<->{right?.val}]")]
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    [DebuggerStepThrough]
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    #region Overrides of Object

    public override string ToString()
    {
        return val.ToString();
    }

    #endregion
}
