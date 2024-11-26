using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IAuthorService
    {
        public IQueryable<AuthorModel> Query();
        public ServiceBase Create(Author record);
        public ServiceBase Update(Author record);
        public ServiceBase Delete(int id);
    }

    public class AuthorService : ServiceBase, IAuthorService
    {

        public AuthorService(Db db) : base(db)
        {
        }

        public IQueryable<AuthorModel> Query()
        {
            return _db.Authors.OrderBy(a => a.FirstName).ThenBy(a => a.LastName).Select(a => new AuthorModel() { Record = a});
            
        }

        public ServiceBase Create(Author record)
        {
            if (_db.Authors.Any(a => a.FirstName.ToUpper() == record.FirstName.ToUpper().Trim() && a.LastName.ToUpper() == record.LastName.ToUpper().Trim()))
                return Error("An author with the same name already exists!");
            
            record.FirstName = record.FirstName?.Trim();
            record.LastName = record.LastName?.Trim();
            _db.Authors.Add(record);
            _db.SaveChanges(); // commit to the database
            return Success("Author created successfully.");
        }

        public ServiceBase Update(Author record)
        {
            if (_db.Authors.Any(a => 
                    a.Id != record.Id && 
                    a.FirstName.ToUpper() == record.FirstName.ToUpper().Trim() && 
                    a.LastName.ToUpper() == record.LastName.ToUpper().Trim()))
                return Error("Another author with the same name already exists!");

            var entity = _db.Authors.SingleOrDefault(a => a.Id == record.Id);
            if (entity is null)
                return Error("Author can't be found!");

            entity.FirstName = record.FirstName?.Trim();
            entity.LastName = record.LastName?.Trim();
            entity.Biography = record.Biography;
            _db.Authors.Update(entity);
            _db.SaveChanges();
            return Success("Author updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Authors.Include(a => a.Books).SingleOrDefault(a => a.Id == id);
            if (entity is null)
                return Error("Author can't be found!");

            if (entity.Books.Any())
                return Error("Author has relational books!");

            _db.Authors.Remove(entity);
            _db.SaveChanges();
            return Success("Author deleted successfully.");
        }
    }
}