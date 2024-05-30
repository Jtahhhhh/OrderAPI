using AutoMapper;
using internship.Database;
using internship.Model;
using internship.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace internship.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(FoodDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<User>> GetUserById(int id)
        {
            try
            {
                var users = await _context.User.Where(u => u.Id == id).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("Failed to retrieve users by ID", ex);
            }
        }
        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            return await _context.User.Where(u => u.Name.Contains(name)).ToListAsync();
        }
    }
}
