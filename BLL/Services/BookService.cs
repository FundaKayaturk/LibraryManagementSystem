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
                .Include(b => b.Author) // Yazar bilgisi dahil edilir
                .OrderBy(b => b.Title) // Kitap başlıklarına göre sıralanır
                .ThenBy(b => b.PublicationYear) // Yayın yılına göre sıralama yapılır
                .Select(b => new BookModel { Record = b }); // BookModel'de yer alan 'Record' olarak döner
        }
        

        public ServiceBase Create(Book record)
        {
            // Eğer aynı başlığa sahip bir kitap varsa hata döner
            if (_db.Books.Any(b => b.Title.ToLower() == record.Title.ToLower().Trim()))
            {
                return Error("Book with the same title exists!");
            }

            record.Title = record.Title?.Trim(); // Başlıkta gereksiz boşluklar temizlenir
            _db.Books.Add(record); // Yeni kitap eklenir
            _db.SaveChanges(); // Değişiklik veritabanına kaydedilir

            return Success("Book created successfully.");
        }

        public ServiceBase Update(Book record)
        {
            // Eğer başka bir kitap aynı başlığa sahip ve id farklıysa hata döner
            if (_db.Books.Any(b => b.Id != record.Id && b.Title.ToLower() == record.Title.ToLower().Trim()))
            {
                return Error("Book with the same title exists!");
            }

            record.Title = record.Title?.Trim(); // Başlıkta gereksiz boşluklar temizlenir
            _db.Books.Update(record); // Güncelleme işlemi yapılır
            _db.SaveChanges(); // Değişiklikler kaydedilir

            return Success("Book updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            // Kitap ve ona ait rezervasyonlarla birlikte sorgulanır
            var entity = _db.Books.Include(b => b.Reservations).SingleOrDefault(b => b.Id == id);
    
            if (entity is null) // Kitap bulunamazsa hata döner
            {
                return Error("Book can't be found!");
            }

            // Eğer kitap üzerinde rezervasyonlar varsa, silemezsiniz
            if (entity.Reservations.Any())
            {
                return Error("Book has active reservations and cannot be deleted!");
            }

            // Kitap silinir
            _db.Books.Remove(entity);
            _db.SaveChanges(); // Değişiklikler kaydedilir

            return Success("Book deleted successfully.");
        }
    }
}