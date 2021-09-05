using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.DTOs.StaffDTOs
{
    public class StaffCreateDTO
    {
        //public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Age { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string StateOfOrigin { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
