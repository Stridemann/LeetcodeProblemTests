public class Add_Two_Numbers
{
    [Theory]
    [InlineData("[2,4,3]", "[5,6,4]", "[7,0,8]")]
    [InlineData("[5]", "[5]", "[0,1]")]
    [InlineData("[9,9,9,9,9,9,9]", "[9,9,9,9]", "[8,9,9,9,0,0,0,1]")]
    public void Test(string l1Str, string l2Str, string expected)
    {
        var s = new Solution();
        var l1 = ListNode.FromString(l1Str);
        var l2 = ListNode.FromString(l2Str);
        var result = s.AddTwoNumbers(l1, l2);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        var reminder = 0;
        ListNode? head = l1;
        ListNode? last = l1;

        var l1Iter = l1;
        var l2Iter = l2;

        while (l1Iter != null && l2Iter != null)
        {
            var sum = l1Iter.val + l2Iter.val + reminder;
            reminder = sum / 10;
            l1Iter.val = l2Iter.val = sum % 10;
            l1Iter = l1Iter.next;
            l2Iter = l2Iter.next;

            if (l1Iter != null)
            {
                last = l1Iter;
                head = l1;
            }
            else if (l2Iter != null)
            {
                last = l2Iter;
                head = l2;
            }
        }

        if (reminder > 0)
        {
            if (l1Iter == null && l2Iter == null)//equal length lists with reminder left
            {
                last.next = new ListNode(reminder);

                return head;
            }

            while (reminder > 0 && last != null)
            {
                var sum = last.val + reminder;
                reminder = sum / 10;
                last.val = sum % 10;

                if (last.next == null && reminder > 0)
                {
                    last.next = new ListNode(reminder);

                    return head;
                }

                last = last.next;
            }
        }

        return head;
    }
}
