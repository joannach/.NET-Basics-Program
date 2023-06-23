using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        private Node<T> tail;
        public Node<T> Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public int Length { get; private set; }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);

            if (tail == null)
                head = newNode;
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
            }

            tail = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> newNode = new Node<T>(e);

            if (index == Length)
            {
                Add(e);
                return;
            }

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null)
                    head.Previous = newNode;
                head = newNode;
                if (tail == null)
                    tail = newNode;
                Length++;
                return;
            }

            int currentIndex = 0;
            foreach (T item in this)
            {
                if (currentIndex == index)
                {
                    Node<T> currentNode = GetNodeByValue(item);
                    newNode.Previous = currentNode.Previous;
                    newNode.Next = currentNode;
                    currentNode.Previous.Next = newNode;
                    currentNode.Previous = newNode;
                    Length++;
                    return;
                }
                currentIndex++;
            }
        }

        private Node<T> GetNodeByValue(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public T ElementAt(int index)
        {
            if (Length == 0)
                throw new IndexOutOfRangeException("The linked list is empty.");
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException(nameof(index));

            if (index == 0)
                return head.data;

            int currentIndex = 0;
            foreach (T item in this)
            {
                if (currentIndex == index)
                    return item;
                currentIndex++;
            }

            return tail.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        public void Remove(T item)
        {
            Node<T> nodeToRemove = GetNodeByValue(item);
            if (nodeToRemove != null)
            {
                if (nodeToRemove == head)
                {
                    if (head == null)
                        throw new InvalidOperationException("The linked list is empty.");

                    head = head.Next;
                    if (head != null)
                        head.Previous = null;
                    else
                        tail = null;
                    Length--;
                }
                else if (nodeToRemove == tail)
                {
                    if (tail == null)
                        throw new InvalidOperationException("The linked list is empty.");

                    tail = tail.Previous;
                    if (tail != null)
                        tail.Next = null;
                    else
                        head = null;
                    Length--;
                }
                else
                {
                    nodeToRemove.Previous.Next = nodeToRemove.Next;
                    nodeToRemove.Next.Previous = nodeToRemove.Previous;
                    Length--;
                }
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();

            if (Length == 0)
                throw new IndexOutOfRangeException("The linked list is empty.");
            
            if (index == 0)
            {
                T removed;
                if (head != null)
                {
                    removed = head.data;
                    head = head.Next;
                }
                else
                {
                    removed = tail.data;
                    tail = null;
                }
                Length--;
                return removed;
            }

            int currentIndex = 0;
            foreach (T item in this)
            {
                if (currentIndex == index)
                {
                    Node<T> currentNode = GetNodeByValue(item);
                    if (currentNode.Previous != null)
                        currentNode.Previous.Next = currentNode.Next;
                    if (currentNode.Next != null)
                        currentNode.Next.Previous = currentNode.Previous;

                    Length--;
                    return currentNode.data;
                }
                currentIndex++;
            }

            return default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
