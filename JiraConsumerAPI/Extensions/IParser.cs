namespace JiraConsumerAPI.Services
{
    public interface IParser
    {
        decimal SecondsToHours(float timeSpentInSeconds);

        string CreateBase(string[] partsOfComment);

        string CreatePolarionMiscField(string[] partsOfComment);

        string[] GetComment(string rawComment, bool isPolarion);

        string GetNumbers(string partOfComment);

    }
}
