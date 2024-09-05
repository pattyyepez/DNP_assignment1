namespace Entities;

public class Reaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ContentId { get; set; }
    public bool IsLike { get; set; }  // True for like, false for dislike
    public DateTime DateCreated { get; set; }

    public Reaction(int userId, int contentId, bool isLike, DateTime dateCreated)
    {
        UserId = userId;
        ContentId = contentId;
        IsLike = isLike;
        DateCreated = dateCreated;
    }
}