using Entities;

namespace RepositoryContracts;

public interface IReactionRepository
{
    Task<Reaction> AddAsync(Reaction comment);
    Task UpdateAsync(Reaction comment);
    Task DeleteAsync(int id);
    Task<Reaction> GetSingleAsync(int id);
    IQueryable<Reaction> GetMany();
}


