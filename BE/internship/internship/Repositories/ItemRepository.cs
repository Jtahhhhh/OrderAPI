using AutoMapper;
using internship.Database;
using internship.Model;
using internship.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace internship.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly FoodDBContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(FoodDBContext context,IMapper mapper) 
        {
            _context=context;
            _mapper =mapper;
        }

        public async Task<List<Item>> GetItemByid(string id)
        {
            try 
            {
                var item = await _context.Item.Where(i=>i.Item_Id == id).ToListAsync();
                return item;
            }
            catch (Exception ex) 
            {
                throw new Exception("Failed to retrieve Item by ID", ex);
            }
            
        }
    }
}
