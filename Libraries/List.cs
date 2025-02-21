using System.Collections;
using System.Collections.Generic;

namespace ListOfNodes
{

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public DoubleNode<T>? head;
        public DoubleNode<T>? tail;
        int count = 0;

        public DoubleNode<T> Add(T data)
        {
            DoubleNode<T> dNode = new DoubleNode<T>(data);
            if (head == null)
                head = tail = dNode;

            else
            {
                tail.Next = dNode;
                dNode.Previous = tail;
                tail = dNode;
            }
            count++;
            return dNode;
        }

        public void AddFirst(T data)
        {
            DoubleNode<T> dNode = new DoubleNode<T>(data);
            if (head == null)
                head = tail = dNode;
            else
            {
                dNode.Next = head;
                head.Previous = dNode;
                head = dNode;
            }
            count++;
        }
        private void AddAfter(int index, T data)
        {
            DoubleNode<T> dNode = new DoubleNode<T>(data);
            DoubleNode<T> current = head;
            DoubleNode<T> temp;
            int CountTemp = 0;

            while (current != null)
            {
                if (CountTemp == index)
                {
                    break;
                }
                current = current.Next;
                CountTemp++;
            }
            dNode.Next = current.Next;
            dNode.Previous = current;
            current.Next = dNode;
            current.Next.Previous = dNode;

            count++;
        }
        public void Insert(int index, T data)
        {
            if (index == 0)
                AddFirst(data);
            else if (index == count)
                Add(data);
            else
                AddAfter(index, data);
        }
        public bool Contains(T data)
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public bool Remove(T data)
        {
            DoubleNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            if (count < 1000) GC.Collect();
            return false;
        }
        public bool IsEmpty { get { return head == null; } }
        public int Count { get { return count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoubleNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
        public void Sort()
        {
            if (head == null || head.Next == null)
                return;

            head = MergeSort(head);
            tail = head;

            while (tail.Next != null)
            {
                tail = tail.Next;
            }
        }

        private DoubleNode<T> MergeSort(DoubleNode<T> head)
        {
            if (head == null || head.Next == null)
                return head;

            DoubleNode<T> middle = GetMiddle(head);
            DoubleNode<T> nextToMiddle = middle.Next;
            middle.Next = null;

            DoubleNode<T> left = MergeSort(head);
            DoubleNode<T> right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }

        private DoubleNode<T> GetMiddle(DoubleNode<T> head)
        {
            if (head == null)
                return head;

            DoubleNode<T> slow = head, fast = head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        private DoubleNode<T> Merge(DoubleNode<T> left, DoubleNode<T> right)
        {
            if (left == null) return right;
            if (right == null) return left;

            DoubleNode<T> result;

            if (Comparer<T>.Default.Compare(left.Data, right.Data) <= 0)
            {
                result = left;
                result.Next = Merge(left.Next, right);
                if (result.Next != null)
                    result.Next.Previous = result;
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next);
                if (result.Next != null)
                    result.Next.Previous = result;
            }
            return result;
        }

    }
}
