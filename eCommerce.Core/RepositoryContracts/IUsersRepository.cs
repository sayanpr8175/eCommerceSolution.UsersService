
using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    // Method to add a user to data store and return the added user
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    Task<ApplicationUser?>GetUserByEmailAndPassword(string? email, string? password);
    /// <summary>
    ///  Returns users data based on provided user ID
    ///  
    ///  I am making this interface specifically for other direct comm from other microservices
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByUserID(Guid? userID);

}

