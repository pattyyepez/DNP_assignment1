namespace Entities
{
    public abstract class Content
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Body { get; set; }
        public int LikesCount { get; set; }  // Count of likes
        public int DislikesCount { get; set; }  // Count of dislikes
        public DateTime DateCreated { get; set; }

        protected Content(int authorId, string body, DateTime dateCreated, int likesCount, int dislikesCount)
        {
            AuthorId = authorId;
            Body = body;
            LikesCount = likesCount;  
            DislikesCount = dislikesCount; 
            DateCreated = dateCreated;
        }
    }
}