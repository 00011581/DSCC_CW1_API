namespace API.Exceptions
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException(string? message) : base(message)
        {
        }
    }
}
