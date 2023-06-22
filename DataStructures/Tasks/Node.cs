namespace Tasks
{
    public class Node<T>
    {
        public T data;

        private Node<T> next;
        public Node<T> Next 
        { 
            get { return next; }
            set { next = value; } 
        }

        private Node<T> previous;
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Node(T data)
        {
            this.data = data;
        }

    }
}
