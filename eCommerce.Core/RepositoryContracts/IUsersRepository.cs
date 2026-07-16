
using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    // Method to add a user to data store and return the added user
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    Task<ApplicationUser?>GetUserByEmailAndPassword(string? email, string? password);

}

