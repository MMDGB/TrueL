﻿namespace TryplicationClient.Services
{
    public interface IAccessTokenStore
    {
        string AccessToken { get; set; }
    }
}