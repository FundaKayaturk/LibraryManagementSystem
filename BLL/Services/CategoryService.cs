using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public class CategoryService : ServiceBase, IService<Category, CategoryModel>
    {
        public CategoryService(Db db) : base(db)
        {
        }

        public IQueryable<CategoryModel> Query()
        {
            return _db.Categories.OrderBy(c => c.Name).Select(c => new CategoryModel() { Record = c });
        }

        public ServiceBase Create(Category record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Update(Category record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}