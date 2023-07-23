public static class TreeUtils
{
    public static TreeNode FromString(string cfg)
    {
        var inputArray = new Queue<string>();

        foreach (var s in cfg.TrimStart('[').TrimEnd(']').Replace(" ", string.Empty).Split(','))
        {
            inputArray.Enqueue(s);
        }

        var root = new TreeNode(int.Parse(inputArray.Dequeue()));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0 && inputArray.Count > 0)
        {
            var curNode = queue.Dequeue();
            var leftVal = inputArray.Dequeue();

            if (leftVal != "null")
            {
                curNode.left = new TreeNode(int.Parse(leftVal));
                queue.Enqueue(curNode.left);
            }

            if (inputArray.Count == 0)
                break;
            var rightVal = inputArray.Dequeue();

            if (rightVal != "null")
            {
                curNode.right = new TreeNode(int.Parse(rightVal));
                queue.Enqueue(curNode.right);
            }
        }

        return root;
    }
}
