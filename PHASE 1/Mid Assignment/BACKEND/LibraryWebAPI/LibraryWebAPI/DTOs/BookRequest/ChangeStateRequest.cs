using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebAPI.DTOs.BookRequest
{
    public class ChangeStateRequest
    {
        // [Required]
        public Guid RequestId { get; set; }

        // [Required]
        public string? UserName { get; set; }
    }
}