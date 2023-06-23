using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public DoublyLinkedList<T> Storage = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (Storage.Length == 0)
                throw new InvalidOperationException("The storage is empty.");

            return Storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            Storage.Add(item);
        }

        public T Pop()
        {
            if (Storage.Length == 0)
                throw new InvalidOperationException("The storage is empty.");

            return Storage.RemoveAt(0);
        }

        public void Push(T item)
        {
            Storage.AddAt(0, item);
        }
    }
}
