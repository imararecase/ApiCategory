using APICategory.Models;
using APICategory.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APICategory.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: api/category/GetCategories --> lstado de categorias
        [HttpGet]
        [Route("/GetCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await categoryRepository.GetCategories());
        }

        // GET: api/category/GetCategoryById/5 --> Obtener categoria por ID
        [HttpGet]
        [Route("/GetCategoryById/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetCategoryById(id);
            if(category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        // POST: api/category/CreateCategory --> Crear una nueva categoria
        [Route("/CreateCategory")]
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var newCategory = await categoryRepository.CreateCategory(category);
            return Ok(newCategory);
         
        }

        // PUT: api/category/UpdateCategory --> Actualizar una categoria existente
        [Route("/UpdateCategory")]
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            var updateCategory = await categoryRepository.UpdateCategory(category);
            return Ok(updateCategory);
        }

        // DELETE: api/category/DeleteCategory/5 --> Eliminar una categoria por ID
        [Route("/DeleteCategory/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            var success = await categoryRepository.DeleteCategory(id);
            if (!success) return NotFound();
            return Ok(true);
        }
    }
}
