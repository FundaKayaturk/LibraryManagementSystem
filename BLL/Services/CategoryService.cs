using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

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
            if (_db.Categories.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Categories.Add(record);
            _db.SaveChanges();
            return Success("Category is created successfully.");
        }

        public ServiceBase Update(Category record)
        {
            if (_db.Categories.Any(s => s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            var entity = _db.Categories.Find(record.Id);
            if (entity is null)
                return Error("Category not found!");
            entity.Name = record.Name?.Trim();
            _db.Categories.Update(entity);
            _db.SaveChanges();
            return Success("Category is updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Categories.Include(s => s.BookCategories).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Category not found!");
            _db.BookCategories.RemoveRange(entity.BookCategories);
            _db.Categories.Remove(entity);
            _db.SaveChanges();
            return Success("Category is deleted successfully.");
        }
    }
}