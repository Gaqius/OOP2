using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace L3.Code
{
    /// <summary>
    /// Custom list class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T> : IEnumerable<T>, IComparable<MyList<T>>, IEquatable<MyList<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data, Node next = null)
            {
                this.Data = data;
                this.Next = next;
            }
        }
        private Node head;
        private Node tail;
        /// <summary>
        /// Adds an exercise to the end of the list
        /// </summary>
        /// <param name="Item"></param>
        public void Add(T Item)
        {
            Node node = new Node(Item);
            if (tail != null && head != null)
            {
                tail.Next = node;
                tail = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }
        /// <summary>
        /// Counts how many exercises are in the list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }
        /// <summary>
        /// To string override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("MyList<{0}>( Count = {0} )", Count());
        }
        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Sort()
        {
            for (Node nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                Node min = nodeA;
                for (Node nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data.CompareTo(min.Data) < 0)
                    {
                        min = nodeB;
                    }
                }
                T tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }
        /// <summary>
        /// Compare to application for MyList
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(MyList<T> other)
        {
            int thisCount = this.Count();
            int otherCount = other.Count();
            if (thisCount < otherCount)
            {
                return -1;
            }
            else if (thisCount > otherCount) return 1;
            else return 0;
        }
        /// <summary>
        /// Equals application for MyList
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MyList<T> other)
        {
            return other.Count() == this.Count();
        }
    }
}