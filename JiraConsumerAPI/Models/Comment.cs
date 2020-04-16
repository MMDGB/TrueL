namespace JiraConsumerAPI.Models
{
    public class Comment : IComment
    {
        public string Base { get; set; }
        public string PolarionExtension { get; set; }

        private Comment()
        {
            Base = string.Empty;
            PolarionExtension = string.Empty;
        }

        public Comment(string[] partsOfComment) : this()
        {
            Base = partsOfComment[0];

            if (partsOfComment.Length > 1)
            {
                PolarionExtension = partsOfComment[1];
            }
        }
    }
}
