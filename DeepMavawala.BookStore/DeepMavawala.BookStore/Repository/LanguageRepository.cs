using DeepMavawala.BookStore.Data;
using DeepMavawala.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepMavawala.BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }
            ).ToListAsync();
        }
    }
}
