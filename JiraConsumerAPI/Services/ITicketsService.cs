using JiraConsumerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JiraConsumerAPI.Services
{
    public interface ITicketsService
    {
        Task<string> GetSerializedResultAsync(Filter filter, DateTime start, DateTime end, string jiraIssue);

        string GetSerializedResultAsync(Filter filter, DateTime start, DateTime end);

        Task<string> GetSerializedResultAsync(DateTime start, DateTime end, List<string> jiraIssues);

        string GetSerializedResultNewTech(Filter filter, DateTime start, DateTime end);

        string GetSerializedResultNewTechByIssue(Filter filter, DateTime start, DateTime end);

        Task UpdateCache([FromServices] CacheHostedService cache);

        NetworkCredential GetCredentials();
    }
}