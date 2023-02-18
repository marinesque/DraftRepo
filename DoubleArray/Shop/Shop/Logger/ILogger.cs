namespace Shop.Logger;

public interface ILogger
{
    void LogError(Exception exc, string message);

    void LogWarning(string message);

    void LogMessage(string message);
}
