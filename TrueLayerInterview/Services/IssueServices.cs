using System.Collections.Generic;
using System.Linq;
using TrueLayerInterview.Constants;
using TrueLayerInterview.Models;

namespace TrueLayerInterview.Services
{
    public class IssueServices : IIssueServices
    {
        private readonly List<Issue> issues;

        public IssueServices(IIssueServices studentsGenerator)
        {
            issues = new List<Issue>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < 5; i++)
            {
                issues.Add(new Issue
                {
                    Id = 1,
                    Status = Status.Open,
                    TicketName = "TIK-00" + i.ToString(),
                    TicketAssigne = new Employee
                    {
                        Id = 1,
                        Name = "John",
                        Surname = "The " + i.ToString(),
                        Position = i % 2 == 0 ? Position.SeniorDeveloper : Position.JuniorDeveloper,
                    }
                });
            }
        }

        public void Add(Issue issue)
        {
            issues.Add(issue);
        }

        public void Delete(Issue issue)
        {
            issues.Remove(issue);
        }

        public IEnumerable<Issue> Get()
        {
            return issues;
        }

        public void Update(Issue issue)
        {
            lock (issues)
            {
                Issue studentToUpdate = issues.Single(s => s.Id == issue.Id);
                studentToUpdate.Status = issue.Status;
                studentToUpdate.TicketAssigne = issue.TicketAssigne;
                studentToUpdate.TicketName = issue.TicketName;
            }
        }

        public void Patch(Issue issue)
        {
            lock (issues)
            {
                Issue studentToUpdate = issues.Single(s => s.Id == issue.Id);
                studentToUpdate.Status = issue.Status;
                studentToUpdate.TicketAssigne = issue.TicketAssigne;
                studentToUpdate.TicketName = issue.TicketName;
            }
        }
    }
}