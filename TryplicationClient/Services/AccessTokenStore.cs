using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryplicationClient.Services
{
    public class AccessTokenStore : IAccessTokenStore
    {
        public string AccessToken { get; set; }

    }
}
