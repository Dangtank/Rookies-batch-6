namespace Test.Data.Entities
{
    public class BookRequestDetail
    {
        public Guid DetailId { get; set; }
        public string? BookingDate { get; set; }
        public string? ReturnDate { get; set; }
        public Guid RequestForeignKey { get; set; }

        public Guid BookForeignKey { get; set; }
        public virtual Book Book { get; set; }
        public virtual BookRequest BookRequest { get; set; } = null!;

    }
}