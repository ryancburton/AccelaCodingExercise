using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactDetails.Service.DAL.Model
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string street { get; set; }

        [Required]
        [StringLength(20)]
        public string city { get; set; }
        [Required]
        [StringLength(15)]
        public string state { get; set; }

        [Required]
        [StringLength(10)]
        public string postalCode { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
