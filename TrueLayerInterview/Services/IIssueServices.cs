using System.Collections.Generic;

namespace TrueLayerInterview.Services
{
    public interface IIssueServices
    {
        IEnumerable<Issue> Get();

        void Add(Issue issue);

        void Update(Issue issue);

        void Delete(Issue issue);

        void Patch(Issue issue);
    }
}
