using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository
{
    private List<Post> posts { get; set; }

    public PostInMemoryRepository()
    {
        posts = new List<Post>();
        InitializeDummyData();  // Call to initialize dummy data
    }

    private void InitializeDummyData()
    {
        posts.Add(new Post(1, "Welcome to the Forum!", "This is the very first post.", DateTime.Now.AddDays(-10), 25, 1));
        posts.Add(new Post(2, "Second Post Title", "Here's some interesting content.", DateTime.Now.AddDays(-5), 15, 3));
        posts.Add(new Post(3, "Third Post", "Further discussion on relevant topics.", DateTime.Now.AddDays(-3), 5, 2));
    }
    
    public Task<Post> AddAsync(Post post)
    {
        post.Id = posts.Any() ? posts.Max(p => p.Id) + 1 : 1;
        posts.Add(post);
        return Task.FromResult(post);
    }
    public Task UpdateAsync(Post post)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{post.Id}' not found");
        }

        posts.Remove(existingPost);
        posts.Add(post);

        return Task.CompletedTask;
    }
    public Task DeleteAsync(int id)
    {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{id}' not found");
        }

        posts.Remove(postToRemove);
        return Task.CompletedTask;
    }
    public Task<Post> GetSingleAsync(int id)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == id);
        if (existingPost is null)
        {
            throw new InvalidOperationException(
                $"Post with ID '{id}' does not exist");
        }
        
        return Task.FromResult(existingPost);
    }
    public IQueryable<Post> GetMany()
    {
        return posts.AsQueryable();
    }


    
}