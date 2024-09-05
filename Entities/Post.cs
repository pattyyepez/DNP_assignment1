namespace Entities;

public class Post : Content
{
        public string Title { get; set; }

        public Post(int authorId, string title, string body, DateTime dateCreated, int likesCount, int dislikesCount)
            : base(authorId, body, dateCreated, likesCount, dislikesCount)
        {
            Title = title;
        }
}