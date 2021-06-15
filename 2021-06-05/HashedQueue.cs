namespace Google
{
  using System.Collections.Generic;

  internal class HashNode
  {
    public int Id { get; set; }

    public HashNode Next { get; set; }

    public HashNode(int id)
    {
      this.Id = id;
    }
  }

  internal class HashLinkedList
  {
    private HashNode head = null;
    private HashNode current = null;

    private readonly Dictionary<int, string> nodeMap = null;

    internal HashLinkedList()
    {
      this.nodeMap = new Dictionary<int, string>();
    }

    internal void AddAtEnd(int id, string value)
    {
      if (this.head == null)
      {
        this.head = new HashNode(id);
        this.current = this.head;
      }
      else
      {
        this.current.Next = new HashNode(id);
        this.current = this.current.Next;
      }

      this.nodeMap[id] = value;
    }

    internal (int, string) RemoveFromStart()
    {
      if (this.head == null)
      {
        return (0, string.Empty);
      }

      var item = this.head;
      this.head = head.Next;

      return (item.Id, this.nodeMap[item.Id]);
    }

    internal void Replace(int id, string newValue)
    {
      if (this.nodeMap.TryGetValue(id, out string _))
      {
        this.nodeMap[id] = newValue;
      }
    }
  }

  public class HashedQueue
  {
    private readonly HashLinkedList queue = null;

    public HashedQueue()
    {
      this.queue = new HashLinkedList();
    }

    public void Add(int id, string value)
    {
      this.queue.AddAtEnd(id, value);
    }

    public (int, string) Remove()
    {
      return this.queue.RemoveFromStart();
    }

    public void Replace(int id, string newValue)
    {
      this.queue.Replace(id, newValue);
    }
  }
}
