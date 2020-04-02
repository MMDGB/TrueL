using IdentityServer4.Models;
using System.Collections.Generic;

namespace TryplicationIdentity.Student
{
    public class TicketAPIResources
    {
        public static IEnumerable<ApiResource> Get()
        {
            return new List<ApiResource> {
                new ApiResource()
                {
                    Name = "StudentAPI",

                    Scopes =
                    {
                        new Scope("studentapi.admin"),
                        new Scope("studentapi.readwrite"),
                        new Scope("studentapi.readonly")
                    }
                }
            };
        }
    }
}