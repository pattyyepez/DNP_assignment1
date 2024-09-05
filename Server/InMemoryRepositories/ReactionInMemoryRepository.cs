using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class ReactionInMemoryRepository : IReactionRepository
{
    private List<Reaction> reactions;

    public ReactionInMemoryRepository(List<Reaction> initialReactions = null)
    {
        reactions = initialReactions ?? new List<Reaction>();
        if (reactions.Count == 0)
        {
            InitializeDummyData();
        }
    }

    private void InitializeDummyData()
    {
        reactions.Add(new Reaction(1, 101, true, DateTime.Now.AddDays(-1)));
        reactions.Add(new Reaction(2, 102, false, DateTime.Now.AddDays(-2)));
    }
    public Task<Reaction> AddAsync(Reaction reaction)
    {
        reaction.Id = reactions.Any() ? reactions.Max(r => r.Id) + 1 : 1;
        reactions.Add(reaction);
        return Task.FromResult(reaction);
    }

    public Task UpdateAsync(Reaction reaction)
    {
        Reaction? existingReaction = reactions.SingleOrDefault(r => r.Id == reaction.Id);
        if (existingReaction is null)
        {
            throw new InvalidOperationException(
                $"Reaction with ID '{reaction.Id}' does not exist");
        }
        reactions.Remove(existingReaction);
        reactions.Add(reaction);
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Reaction? existingReaction = reactions.SingleOrDefault(r => r.Id == id);
        if (existingReaction is null)
        {
            throw new InvalidOperationException(
                $"Reaction with ID '{id}' does not exist");
        }
        reactions.Remove(existingReaction);
        
        return Task.CompletedTask;
    }

    public Task<Reaction> GetSingleAsync(int id)
    {
        Reaction? existingReaction = reactions.SingleOrDefault(r => r.Id == id);
        if (existingReaction is null)
        {
            throw new InvalidOperationException(
                $"Reaction with ID '{id}' does not exist");
        }
        
        return Task.FromResult(existingReaction);
    }

    public IQueryable<Reaction> GetMany()
    {
        return reactions.AsQueryable();
    }
}