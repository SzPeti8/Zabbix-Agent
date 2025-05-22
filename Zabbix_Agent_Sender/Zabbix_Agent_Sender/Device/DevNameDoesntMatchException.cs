namespace Zabbix_Agent_Sender.Device
{
    /// <summary>
    /// Exception that is thrown when a device name does not match the expected value.
    /// </summary>
    public class DevNameDoesntMatchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevNameDoesntMatchException"/> class.
        /// </summary>
        public DevNameDoesntMatchException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DevNameDoesntMatchException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DevNameDoesntMatchException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DevNameDoesntMatchException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public DevNameDoesntMatchException(string message, Exception inner)
            : base(message, inner) { }
    }
}
