namespace Google
{
  public class ListNode
  {
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val = 0, ListNode next = null)
    {
      this.val = val;
      this.next = next;
    }
  }

  public class Solution
  {
    public ListNode Reverse(ListNode head)
    {
      ListNode curr = head;
      ListNode next = null;
      ListNode prev = null;

      while (curr != null)
      {
        next = curr.next;
        curr.next = prev;

        prev = curr;
        curr = next;
      }

      head = prev;
      return head;
    }
  }
}