public class Copy_List_with_Random_Pointer
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(Node root)
    {
        var s = new Solution();
        var result = s.CopyRandomList(root);
    }
}

public class Node
{
    public int val;
    public Node? next;
    public Node? random;

    public Node(int val, Node? next = null, Node? random = null)
    {
        this.val = val;
        this.next = next;
        this.random = random;
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var node1 = new Node(1);
        var node2 = new Node(2);
        node1.next = node2;
        node1.random = node2;
        node2.random = node2;

        yield return new object[] { node1 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head == null)
            return null;
        var nodes = new List<Node>();

        for (var tmp = head; tmp != null; tmp = tmp.next)
        {
            nodes.Add(tmp);
        }

        var result = new Node?[nodes.Count];

        for (var i = nodes.Count - 1; i >= 0; i--)
        {
            var origNode = nodes[i];
            var newNode = result[i] ??= new Node(origNode.val);

            if (origNode.random != null)
            {
                var index = nodes.IndexOf(origNode.random);
                ref Node rf = ref result[index];

                if (rf == null)
                    rf = new Node(origNode.random.val);
                newNode.random = rf;
            }

            if (i < nodes.Count - 1)
            {
                newNode.next = result[i + 1];
            }
        }

        return result[0];
    }
}
