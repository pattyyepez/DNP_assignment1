namespace Entities;

public class Comment : Content
{
    public int RespondingId { get; set; } 

    public Comment(int authorId, int respondingId, string body, DateTime dateCreated, int likesCount, int dislikesCount)
        : base(authorId, body, dateCreated, likesCount, dislikesCount)
    {
        RespondingId = respondingId;
    }
}