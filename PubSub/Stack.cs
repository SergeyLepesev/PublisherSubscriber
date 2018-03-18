using System;
using System.Collections;
using System.Collections.Generic;

namespace PubSub
{
    public class StackNode<T>
    {
        public T Item { get; set; }
        public StackNode<T> Next { get; set; }
        public StackNode(T item)
        {
            Item = item;
        }
    }

    public class Stack<T> : IEnumerable<T>
    {
        public event EventHandler NotifyPop;
        public event EventHandler NotifyPush;

        private StackNode<T> _head;
        public int Count { get; private set; }

        public void Push(T item)
        {
            var node = new StackNode<T>(item);
            node.Next = _head;
            _head = node;
            Count++;
            NotifyPush?.Invoke(this, EventArgs.Empty);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("stack empty");
            StackNode<T> node = _head;
            _head = _head.Next;
            Count--;
            NotifyPop?.Invoke(this, EventArgs.Empty);
            return node.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            StackNode<T> node = _head;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}