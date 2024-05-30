using internship.Database;
using internship.Model;

namespace internship.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUserById(int id);
        Task<IEnumerable<User>> GetUsersByName(string name);
    }
}
