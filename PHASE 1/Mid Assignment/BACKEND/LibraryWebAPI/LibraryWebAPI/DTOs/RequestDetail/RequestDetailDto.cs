namespace LibraryWebAPI.DTOs.RequestDetailDto
{
    public class RequestDetailDto
    {
        public Guid DetailId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid RequestForeignKey { get; set; }

        public Guid BookForeignKey {get; set;}
    }
}