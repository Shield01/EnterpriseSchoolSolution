using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.DTOs.StaffDTOs
{
    public class StaffUpdateDTO
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
