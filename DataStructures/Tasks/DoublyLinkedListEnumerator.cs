using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoublyLinkedList<T> list;
        private Node<T> current;
        private bool started;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
        {
            this.list = list;
            current = null;
            started = false;
        }

        public T Current
        {
            get
            {
                if (!started || current == null)
                    throw new InvalidOperationException();
                return current.data;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!started)
            {
                current = list.Head;
                started = true;
            }
            else if (current != null)
            {
                current = current.Next;
            }

            return current != null;
        }

        public void Reset()
        {
            current = null;
            started = false;
        }
    }
}