using nauka.Data;
using nauka.Interfaces;
using nauka.Modele;

namespace nauka.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)

        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
