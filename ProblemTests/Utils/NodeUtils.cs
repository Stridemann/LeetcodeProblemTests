namespace Utils
{
    public static class NodeUtils
    {
        public static Node FromString(string cfg)
        {
            var inputArray = new Queue<string>();

            foreach (var s in cfg.TrimStart('[').TrimEnd(']').Replace(" ", string.Empty).Split(','))
            {
                inputArray.Enqueue(s);
            }

            var root = new Node(int.Parse(inputArray.Dequeue()));
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0 && inputArray.Count > 0)
            {
                var curNode = queue.Dequeue();
                var leftVal = inputArray.Dequeue();

                if (leftVal != "null")
                {
                    curNode.left = new Node(int.Parse(leftVal));
                    queue.Enqueue(curNode.left);
                }

                if (inputArray.Count == 0)
                    break;
                var rightVal = inputArray.Dequeue();

                if (rightVal != "null")
                {
                    curNode.right = new Node(int.Parse(rightVal));
                    queue.Enqueue(curNode.right);
                }
            }

            return root;
        }
    }
}
