using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_23.Code
{
    public class ObjectList : IEnumerable<Object>
    {
        class ObjectNode
        {
            public Object Data { get; set; }
            public ObjectNode Next { get; set; }
            public ObjectNode(Object data = null, ObjectNode next = null)
            {
                this.Data = data;
                this.Next = next;
            }
        }
        private ObjectNode head;
        private ObjectNode tail;
        /// <summary>
        /// Adds an exercise to the end of the list
        /// </summary>
        /// <param name="Object"></param>
        public void Add(Object Object)
        {
            ObjectNode node = new ObjectNode(Object);
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
            ObjectNode current = head;
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
            return base.ToString();
        }
        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Object> GetEnumerator()
        {
            ObjectNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Sort()
        {
            for (ObjectNode nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                ObjectNode min = nodeA;
                for (ObjectNode nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (((IComparable)nodeB.Data).CompareTo(min.Data) < 0)
                    {
                        min = nodeB;
                    }
                }
                Object tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }            
        }

    }
}