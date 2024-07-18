﻿using nauka.Data;
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

        public bool CreateCategory(Category category)
        {
            //Zmiana trackera
            //dodawanie, aktualizowanie, modyfikowanie
            //moze byc connected albo disconnected
            _context.Add(category);
            _context.SaveChanges();
            return Save();
            
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            if (saved > 0)
            {
                return true;
            }
            else { 
            
                return false;
            }
        }
    }
}
