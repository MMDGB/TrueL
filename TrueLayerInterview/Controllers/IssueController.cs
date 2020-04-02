using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TrueLayerInterview.Services;

namespace TrueLayerInterview.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class IssueController : ControllerBase
    {
        private readonly IIssueServices issueService;
        private readonly ILogger<IssueController> logger;

        public IssueController(IIssueServices studentsService, ILogger<IssueController> logger)
        {
            this.issueService = studentsService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Issue> Get()
        {
            return issueService.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Issue> Get(long id)
        {
            return issueService.Get().Single(s => s.Id == id);
        }

        [HttpPost]
        [Authorize(Policy = "RegularUser")]
        public ActionResult Post([FromBody] Issue student)
        {
            if (issueService.Get().Any(s => s.Id == student.Id))
            {
                issueService.Update(student);
                return Ok(student);
            }

            issueService.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        [Authorize(Policy = "RegularUser")]
        public ActionResult Put(long id, [FromBody] Issue student)
        {
            issueService.Update(student);
            return Ok(student);
        }

        // PATCH: api/Students
        [HttpPatch]
        [Authorize(Policy = "RegularUser")]
        public ActionResult<Issue> SimplePatch([FromBody] Issue student)
        {
            if (!issueService.Get().Any(s => s.Id == student.Id))
            {
                return NotFound();
            }

            issueService.Patch(student);
            Issue patchedStudent = issueService.Get().Single(s => s.Id == student.Id);
            return Ok(patchedStudent);
        }

        // PATCH: api/Students/5
        [HttpPatch("{id}")]
        [Authorize(Policy = "RegularUser")]
        public ActionResult<Issue> Pacth(long id, [FromBody] JsonPatchDocument<Issue> patchData)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RegularUser")]
        public ActionResult Delete(Issue issue)
        {
            issueService.Delete(issue);
            return Ok();
        }
    }
}