using System.Xml.Linq;

public class Clone_Graph
{
    [Theory]
    [InlineData("[1,2]", 1)]
    public void Test(string cfg, int expected)
    {
        var s = new Solution();

        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);
        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);

        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);

        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);

        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);

        var result = s.CloneGraph(node1);

        //result.ShouldBe(expected);
    }
}

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return null;
        }

        var processQueue = new Queue<Node>();
        processQueue.Enqueue(node);

        Node initial = null;

        while (processQueue.TryDequeue(out var srcNode))
        {
            var cloned = GetClonedNode(srcNode);

            if (cloned.val > 0)
                continue;
            cloned.val = -cloned.val;
            initial ??= cloned;

            foreach (var neighbor in srcNode.neighbors)
            {
                var clonedNode = GetClonedNode(neighbor);
                cloned.neighbors.Add(clonedNode);
                processQueue.Enqueue(neighbor);
            }
        }

        return initial;
    }

    private readonly Node?[] _cloned = new Node[101];

    private Node GetClonedNode(Node node)
    {
        var cloned = _cloned[node.val < 0 ? -node.val : node.val];

        if (cloned == null)
        {
            cloned = new Node(-node.val);
            _cloned[node.val] = cloned;
        }

        return cloned;
    }
}
