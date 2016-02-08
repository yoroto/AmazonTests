namespace ClassLibrary4
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }

        public T Value { get; private set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
