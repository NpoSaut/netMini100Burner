using System;
using System.Runtime.Serialization;

namespace SautDnw.Exceptions
{
    /// <Summary>
    /// Ошибка при передаче через USB
    /// </Summary>
    [Serializable]
    public class UsbTransmitException : SautDnwException
    {
        public UsbTransmitException() : base("Ошибка при передаче через USB") { }
        public UsbTransmitException(Exception inner) : base("Ошибка при передаче через USB", inner) { }
        public UsbTransmitException(string message) : base(message) { }
        public UsbTransmitException(string message, Exception inner) : base(message, inner) { }

        protected UsbTransmitException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}