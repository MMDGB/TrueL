using JiraConsumerAPI.Services;
using System.Linq;

namespace JiraConsumerAPI.Extensions
{
    public class Parser : IParser
    {
        public decimal SecondsToHours(float timeSpentInSeconds)
        {
            float hours = timeSpentInSeconds / 3600;
            return (decimal)hours;
        }

        public string CreateBase(string[] partsOfComment)
        {
            string ticketFromPolarion = partsOfComment[0].Trim() + "-";

            if (partsOfComment.Count() > 1)
            {
                ticketFromPolarion += GetNumbers(partsOfComment[1]);
            }
            return ticketFromPolarion;
        }

        public string CreatePolarionMiscField(string[] partsOfComment)
        {
            if (partsOfComment.Count() > 1)
            {
                if (partsOfComment[1].Contains("FM"))
                {
                    string[] result = partsOfComment[1].Split("FM").Select(s => s.Trim()).ToArray();
                    string res = GetNumbers(result[1]);
                    return "(FM" + res + ": Umsetzung)";
                }
            }

            return string.Empty;
        }

        public string[] GetComment(string rawComment, bool isPolarion)
        {
            rawComment = rawComment.ToUpperInvariant().Trim();

            // use "FEP-" instead of "FEP" because there are multiple logs in Jira that start with FEPLAS => see FEPLAS autotets comment for TIS-85
            // "FNS" and "SFR" are okay because only by mistake you can log something on FINAS or SAFIR that is not related to a polarion ticket that start with FNS or SFR. 
            if (!(rawComment.StartsWith("FNS") || rawComment.StartsWith("FEP-") || rawComment.StartsWith("SFR")))
            {
                if (!isPolarion)
                {
                    return new string[] { rawComment };
                }
                return null;
            }

            string[] partsOfComment = rawComment.Split('-').Select(s => s.Trim()).ToArray();

            string[] comment = new string[2];
            comment[0] = CreateBase(partsOfComment);
            comment[1] = CreatePolarionMiscField(partsOfComment);

            return comment;
        }

        public string GetNumbers(string partOfComment)
        {
            string numbersFromComment = null;
            int j = 0;

            while (j < partOfComment.Count() && char.IsDigit(partOfComment[j]))
            {
                numbersFromComment += partOfComment[j];
                j++;
            }

            return numbersFromComment;
        }
    }
}
