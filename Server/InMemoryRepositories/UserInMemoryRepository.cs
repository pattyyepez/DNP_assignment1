using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users = new List<User>();
    public UserInMemoryRepository()
    {
        InitializeDummyData(); 
    }

    private void InitializeDummyData()
    {
        users.Add(new User("domi", "sep"));
        users.Add(new User("joan", "sep"));
        users.Add(new User("seba", "sep"));
    }

    public Task<User> AddAsync(User user)
    {
        user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateAsync(User user)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == user.Id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{user.Id}' does not exist");
        }
        users.Remove(existingUser);
        users.Add(user);
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' does not exist");
        }
        users.Remove(existingUser);
        
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int id)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' does not exist");
        }
        
        return Task.FromResult(existingUser);
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }   
}