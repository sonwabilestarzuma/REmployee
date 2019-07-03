using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REmployee.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

    }
}
