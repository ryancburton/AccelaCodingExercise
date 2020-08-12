using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactDetails.Service.DAL.Model
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20)]
        public string lastName { get; set; }
    }
}
