namespace ListOfNodes
{
    public class DoubleNode<T>
    {
        public DoubleNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoubleNode<T> Next { get; internal set; }
        public DoubleNode<T> Previous { get; internal set; }
    }
}