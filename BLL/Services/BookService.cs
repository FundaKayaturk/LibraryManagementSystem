using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    //public interface IBookService
    //{
    //    public IQueryable<BookModel> Query();
    //    public ServiceBase Create(Book record);
    //    public ServiceBase Update(Book record);
    //    public ServiceBase Delete(int id);
    //}

    public class BookService : ServiceBase, IService<Book, BookModel>
    {
        public BookService(Db db) : base(db)
        {
        }

        public IQueryable<BookModel> Query()
        {
            return _db.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.PublicationYear)
                .Select(b => new BookModel { Record = b });
        }
        

        public ServiceBase Create(Book record)
        {
            if (_db.Books.Any(b => b.Title.ToLower() == record.Title.ToLower().Trim()))
            {
                return Error("Book with the same title exists!");
            }

            record.Title = record.Title?.Trim();
            _db.Books.Add(record);
            _db.SaveChanges();

            return Success("Book created successfully.");
        }

        public ServiceBase Update(Book record)
        {
            if (_db.Books.Any(b => b.Id != record.Id && b.Title.ToLower() == record.Title.ToLower().Trim()))
            {
                return Error("Book with the same title exists!");
            }

            record.Title = record.Title?.Trim();
            _db.Books.Update(record);
            _db.SaveChanges();

            return Success("Book updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Books.Include(b => b.Reservations).SingleOrDefault(b => b.Id == id);
    
            if (entity is null)
            {
                return Error("Book can't be found!");
            }

            
            if (entity.Reservations.Any())
            {
                return Error("Book has active reservations and cannot be deleted!");
            }

            
            _db.Books.Remove(entity);
            _db.SaveChanges();

            return Success("Book deleted successfully.");
        }
    }
}