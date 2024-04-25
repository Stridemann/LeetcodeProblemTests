using System.Diagnostics;
using System.Text;

[DebuggerDisplay(">{data}<")]
public class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode? next;

    public SinglyLinkedListNode(int val = 0, SinglyLinkedListNode? next = null)
    {
        this.data = val;
        this.next = next;
    }

    public static SinglyLinkedListNode GetList(params int[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        var cur = new SinglyLinkedListNode(values[0]);
        var head = cur;

        for (int i = 1; i < values.Length; i++)
        {
            cur.next = new SinglyLinkedListNode(values[i]);
            cur = cur.next;
        }

        return head;
    }

    public static SinglyLinkedListNode FromString(string cfg)
    {
        return GetList(cfg.Replace(" ", string.Empty).TrimStart('[').TrimEnd(']').Split(',').Select(int.Parse).ToArray());
    }

    public SinglyLinkedListNode? FindNode(int value)
    {
        for (var iter = this; iter != null; iter = iter.next)
        {
            if(iter.data == value)
                return iter;
        }

        throw new Exception("Cannot find node");
    }

    #region Overrides of Object

    public override string ToString()
    {
        return $">{data}<";
    }

    #endregion

    public string PrintMe
    {
        get
        {
            var sb = new StringBuilder();
            var node = this;
            sb.Append("[");

            while (node != null)
            {
                if (sb.Length > 1)
                    sb.Append(",");
                sb.Append(node.data);
                node = node.next;
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
