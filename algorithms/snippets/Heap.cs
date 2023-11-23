public class Heap<T> where T : IComparable<T>
{
    private class Node(T value)
    {
        public T Value { get; set; } = value;

        private Node right = default;
        public ref Node Right => ref right;
        private Node left = default;
        public ref Node Left => ref left;

        public void Heapify()
        {
            if(Left is not null && Left.Value.CompareTo(Value) < 0)
                SwapValueWith(Left);
            if(Right is not null && Right.Value.CompareTo(Value) < 0)
                SwapValueWith(Right);
        }

        public void SwapValueWith(Node other) => (other.Value, Value) = (Value, other.Value);

        public ref Node SmallerChild
        {
            get
            {
                if(Left is null)
                    return ref Left;
                else if(Right is null)
                    return ref Right;
                else if(left.Size <= right.Size)
                    return ref Left;
                else
                    return ref Right;
            }
        }

        public int Size => (left?.Size ?? 0) + (right?.Size ?? 0) + 1;
    }

    private Node head = default;
    
    public void Print()
    {
        var queue = new Queue<Node>();
        if(head is not null)
            queue.Enqueue(head);
        
        while(queue.Any())
        {
            var node = queue.Dequeue();
            Console.Write("{0} ", node.Value);

            if(node.Left is not null)
                queue.Enqueue(node.Left);
            if(node.Right is not null)
                queue.Enqueue(node.Right);
        }

        Console.WriteLine();
    }

    public void Enqueue(T value) => EnqueueRecursive(ref head, new Node(value));

    private void EnqueueRecursive(ref Node current, Node newNode)
    {
        if(current is null)
            current = newNode;
        else if(current.Left is null)
            current.Left = newNode;
        else if(current.Right  is null)
            current.Right = newNode;
        else 
            EnqueueRecursive(ref current.SmallerChild, newNode);

        current.Heapify();
    }

    public T Dequeue()
    {
        if(head is null)
            throw new InvalidOperationException("Heap is empty.");

        var temp = head.Value;
        HeapifyDownRecursive(ref head);
        
        return temp;
    }
    
    private void HeapifyDownRecursive(ref Node current)
    {
        if(current.Left is null && current.Right is null)
            current = null;
        else if(current.Right is null)
        {
            current.SwapValueWith(current.Left);
            HeapifyDownRecursive(ref current.Left);
        }
        else if(current.Left is null)
        {
            current.SwapValueWith(current.Right);
            HeapifyDownRecursive(ref current.Right);
        }
        else if(current.Left.Value.CompareTo(current.Right.Value) < 0)
        {
            current.SwapValueWith(current.Left);
            HeapifyDownRecursive(ref current.Left);
        }
        else 
        {
            current.SwapValueWith(current.Right);
            HeapifyDownRecursive(ref current.Right);
        }
    }
}

// Program.cs: testing
var heap = new Heap<int>();
int[] sonlar = [2, 3, 1, 5, 0, 6, 4];

foreach(var son in sonlar)
    heap.Enqueue(son);

heap.Print();

for(int i = 0; i < 10; i++)
    Console.WriteLine(heap.Dequeue());

Console.WriteLine(heap.Dequeue()); // Exception
