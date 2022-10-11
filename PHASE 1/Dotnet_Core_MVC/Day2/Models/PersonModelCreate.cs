using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class PersonModelCreate
    {
        [Required(ErrorMessage ="First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        public string? LastName { get; set; }
        
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
    }
}