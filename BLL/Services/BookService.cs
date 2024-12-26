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
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.PublicationYear)
                .Select(b => new BookModel { Record = b });
        }
        

        public ServiceBase Create(Book record)
        {
            if (record.AvailableCopies > record.TotalCopies)
            {
                return Error("Available copies cannot be greater than total copies.");
            }

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
            if (record.AvailableCopies > record.TotalCopies)
            {
                return Error("Available copies cannot be greater than total copies.");
            }

            if (_db.Books.Any(b => b.Id != record.Id && b.Title.ToLower() == record.Title.ToLower().Trim()))
            {
                return Error("Book with the same title exists!");
            }
            
            var entity = _db.Books.Include(b => b.BookCategories).SingleOrDefault(b => b.Id == record.Id);
            if (entity is null)
                return Error("Book not found!");
            _db.BookCategories.RemoveRange(entity.BookCategories);
            entity.Title = record.Title?.Trim();
            entity.PublicationYear = record.PublicationYear;
            entity.AvailableCopies = record.AvailableCopies;
            entity.TotalCopies = record.TotalCopies;
            entity.AuthorId = record.AuthorId;
            entity.BookCategories = record.BookCategories;
            _db.Books.Update(entity);
            _db.SaveChanges();
            return Success("Book updated successfully.");
        }
        public ServiceBase Delete(int id)
        {
            /*var entity = _db.Books.Include(b => b.Reservations).SingleOrDefault(b => b.Id == id);

            if (entity is null)
            {
                return Error("Book can't be found!");
            }

            if (entity.Reservations.Any())
            {
                return Error("Book has active reservations and cannot be deleted!");
            }*/

            /*_db.Books.Remove(entity);*/
            _db.SaveChanges();

            return Success("Book deleted successfully.");
        }
    }
}