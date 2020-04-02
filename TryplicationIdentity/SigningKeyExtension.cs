using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using TryplicationIdentity.Exceptions;

namespace TryplicationIdentity
{
    public static class SigningKeyExtension
    {
        public static IIdentityServerBuilder AddCertificateFromStore(this IIdentityServerBuilder builder, IConfiguration options)
        {
            var keyIssuer = options.GetValue<string>("SigningKeyIssuer");

            keyIssuer = "IdentityServer Signing Certificate";
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var certificates = store.Certificates.Find(X509FindType.FindByIssuerName, keyIssuer, true);

            if (certificates.Count > 0)
                builder.AddSigningCredential(certificates[0]);
            else
                throw new CertificateNotFoundException("A matching certificate key couldn't be found in the store");

            return builder;
        }
    }
}
