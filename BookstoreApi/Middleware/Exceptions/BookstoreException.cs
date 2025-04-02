namespace BookstoreApi.Middleware.Exceptions;

public class BookstoreException : Exception
{
    public BookstoreException(string message) : base(message) { }
}
