using JiraConsumerAPI.Models;
using JiraConsumerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JiraConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ITicketsService service;
        IJiraConfiguration _jiraConfiguration;

        public DataController(ITicketsService service, IJiraConfiguration jiraConfiguration)
        {
            this.service = service;
            _jiraConfiguration = jiraConfiguration;
        }

        // Get report data for specific jira task
        // GET api/Data/2020-01-01/2020-01-31/TIS-85?isPolarion=true&showUsers=true
        [HttpGet("{start}/{end}/{jiraIssue}")]
        public async Task<string> GetAllTicketsWithTotalNumberOfHoursAsync(DateTime start, DateTime end, string jiraIssue, [FromQuery] Filter filter)
        {
            return await service.GetSerializedResultAsync(filter, start, end, jiraIssue);
        }

        // Get report data for specific jira task
        // GET api/Data/credentials
        [HttpGet("credentials")]
        public NetworkCredential GetCredentials(DateTime start, DateTime end, string jiraIssue, [FromQuery] Filter filter)
        {
            return service.GetCredentials();
        }

        // Get report data for specific jira task
        // GET api/Data/credentials
        [HttpPost("updateCache")]
        public async Task GetCredentials()
        {
            await _jiraConfiguration.UpdateKnownTasks();
           return ;
        }

        // Get result of 3 concatenated issues in order to recreate the Polarion Warranty task 
        // GET api/data/allSystems/2020-01-01/2020-01-31/defects?isPolarion=true&showUsers=true
        //[HttpGet("allSystems/defects/{start}/{end}")]
        [HttpGet("allSystems/{start}/{end}/defects")]
        public string GetDeffectTicketsOnAllSystemsAsync(DateTime start, DateTime end, [FromQuery] Filter filter)
        {
            return service.GetSerializedResultAsync(filter, start, end);
        }

        // Get result of 3 concatenated issues in order to recreate the New Technology tasks 
        // GET api/data/newTech/2020-01-01/2020-01-31/defects?isPolarion=true&showUsers=true
        //[HttpGet("allSystems/defects/{start}/{end}")]
        [HttpGet("newTech/{start}/{end}/defects")]
        public string GetDeffectTicketsOnNewTechs(DateTime start, DateTime end, [FromQuery] Filter filter)
        {
            return service.GetSerializedResultNewTech(filter, start, end);
        }

        // Get result of 3 concatenated issues in order to recreate the New Technology tasks 
        // GET api/data/newTech/2020-01-01/2020-01-31/defects?isPolarion=true&showUsers=true
        //[HttpGet("allSystems/defects/{start}/{end}")]
        [HttpGet("newTechByIssue/{start}/{end}/defects")]
        public string GetIssueDeffectTicketsOnNewTechs(DateTime start, DateTime end, [FromQuery] Filter filter)
        {
            return  service.GetSerializedResultNewTechByIssue(filter, start, end);
        }

        // GET api/data/allSystems/2020-01-01/2020-01-31/defects?isPolarion=true&showUsers=true
        [HttpPost("{start}/{end}/jiraIssuesIds")]
        //[HttpGet("{start}/{end}/jiraIssuesIds")]
        public async Task<string> GetAllDataForJiraIssuesAsync(DateTime start, DateTime end, [FromBody] List<string> jiraIssuesIds) //[FromQuery] Filter filter)
        {
            return await service.GetSerializedResultAsync(start, end, jiraIssuesIds);
            //return await service.GetSerializedResult(filter, start, end, jiraIssues);
        }
    }
}