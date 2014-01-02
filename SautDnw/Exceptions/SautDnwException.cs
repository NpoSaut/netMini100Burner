using System;
using System.Runtime.Serialization;

namespace SautDnw.Exceptions
{
    /// <Summary>
    /// Ошибка работы с программатором s5pc100
    /// </Summary>
    [Serializable]
    public class SautDnwException : ApplicationException
    {
        public SautDnwException() : base("Ошибка работы с программатором s5pc100") { }
        public SautDnwException(Exception inner) : base("Ошибка работы с программатором s5pc100", inner) { }
        public SautDnwException(string message) : base(message) { }
        public SautDnwException(string message, Exception inner) : base(message, inner) { }

        protected SautDnwException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}