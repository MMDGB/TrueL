using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryplicationClient.Services
{
    public interface IClientCredentials
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string Scope { get; }
    }
}
