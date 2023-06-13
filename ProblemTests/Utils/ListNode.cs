using System.Diagnostics;
using System.Text;

[DebuggerDisplay(">{val}<")]
public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode GetList(params int[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        var cur = new ListNode(values[0]);
        var head = cur;

        for (int i = 1; i < values.Length; i++)
        {
            cur.next = new ListNode(values[i]);
            cur = cur.next;
        }

        return head;
    }

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
                sb.Append(node.val);
                node = node.next;
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
