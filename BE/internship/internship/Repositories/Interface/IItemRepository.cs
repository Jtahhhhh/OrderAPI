using internship.Database;
using internship.Model;

namespace internship.Repositories.Interface
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItemByid(string id);
    }
}
