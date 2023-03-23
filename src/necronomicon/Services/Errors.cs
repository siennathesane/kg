namespace necronomicon.Services;

public class InvalidIdentifierException : Exception {
    public InvalidIdentifierException() {}
    public InvalidIdentifierException(string message) : base(message) {}
    public InvalidIdentifierException(string message, Exception inner) : base(message, inner) {}
}
