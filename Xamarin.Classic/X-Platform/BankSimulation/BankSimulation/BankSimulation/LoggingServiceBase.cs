namespace BankSimulation
{
    /// <summary>
    /// base class for all classes with logging functionality,
    /// encapsulates an ILogger instance which can be injected
    /// via the constructor or the public property Logger
    /// </summary>
    public class LoggingServiceBase
    {
        /// <summary>
        /// the logger instance
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger">the injected logger instance</param>
        protected LoggingServiceBase(ILogger logger)
        {
            Logger = logger;
        }
    }
}