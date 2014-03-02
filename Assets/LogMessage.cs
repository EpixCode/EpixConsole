public class LogMessage 
{
    public ELogType LogType { get; private set; }
    public string Message { get; private set; }
    public string StackTrace { get; private set; }

    public LogMessage(ELogType logType, string message, string stackTrace)
    {
        this.LogType = logType;
        this.Message = message;
        this.StackTrace = stackTrace;
    }
}
