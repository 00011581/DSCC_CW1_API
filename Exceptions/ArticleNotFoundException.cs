namespace API.Exceptions
{
    public class ArticleNotFoundException : Exception
    {
        public ArticleNotFoundException(string? message) : base(message)
        {
        }
    }
}
