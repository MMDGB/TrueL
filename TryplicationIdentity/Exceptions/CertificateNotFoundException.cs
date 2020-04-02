using System;

namespace TryplicationIdentity.Exceptions
{
    public class CertificateNotFoundException : Exception
    {
        public CertificateNotFoundException(string message) : base(message)
        {
        }
    }
}