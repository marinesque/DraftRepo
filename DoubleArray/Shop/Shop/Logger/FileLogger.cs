namespace Shop.Logger;

internal class FileLogger : ILogger
{
    string _fileLogPath;
    public FileLogger(string filePath)
    {
        this._fileLogPath = filePath;
    }
    public void LogError(Exception exc, string message)
    {
        SaveLog(" ERR", message);
    }

    public void LogMessage(string message)
    {
        SaveLog("INFO", message);
    }

    public void LogWarning(string message)
    {
        SaveLog("WARN", message);
    }

    void SaveLog(string tag, string message)
    {
        var sw = new StreamWriter(_fileLogPath, append: true);
        var formattedMessage = $"{tag} {DateTime.Now.ToString()}: {message}";
        sw.WriteLine(formattedMessage);
    }
}
