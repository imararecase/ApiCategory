using APICategory.DbContexts;
using APICategory.Models;
using Microsoft.EntityFrameworkCore;

namespace APICategory.Repository
{
    public class CategorySQLRepository : ICategoryRepository
    {
        private AppDbContext dbContext;
        public CategorySQLRepository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        // Listado de categorias
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var result = await this.dbContext.Categories.ToListAsync();
            if (result == null)
            {
                throw new Exception("No categories found");
            }
            return result;
        }

        // Obtener una categoria por Id
        public async Task<Category> GetCategoryById(int categoryId)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            return category;
        }

        // Crear una categoria
        public async Task<Category> CreateCategory(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        // Actualizar una categoria
        public async Task<Category> UpdateCategory(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        // Eliminar una categoria
        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if(category == null)
            {
                return false;
            }
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return true;
        }        
    }
}
