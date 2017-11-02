namespace BankSimulation
{
    /// <summary>
    /// our logging interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// logs the given message to ...
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);
    }
}