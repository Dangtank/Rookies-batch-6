using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DTOs.BookRequest
{
    public class ChangeStateRequest
    {
        [Required]
        public Guid RequestId { get; set; }

        [Required]
        public string? UserName { get; set; }
    }
}