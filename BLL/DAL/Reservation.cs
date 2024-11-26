namespace BLL.DAL
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        public User User { get; set; }
        public Book Book { get; set; }
    }
}