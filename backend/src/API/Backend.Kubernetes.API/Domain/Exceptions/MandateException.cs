using System;

namespace Backend.Kubernetes.API.Domain.Exceptions
{
    public class MandateException : Exception
    {
        public MandateException() { }
        public MandateException(string message) : base(message) { }
        public MandateException(string message, Exception inner) : base(message, inner) { }
    }
}
