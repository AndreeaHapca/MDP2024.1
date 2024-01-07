using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Watchmasters.Models
{
    public class Store
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Store name is required")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Store name must be between 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Store name can contain only letters, spaces and -")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Store city can contain only letters, spaces and -")]
        public string City { get; set; }

        [Required(ErrorMessage = "Store address is required")]
        [Column(TypeName = "varchar(200)")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-.\s]+$", ErrorMessage = "Store address can contain only letters, digits, spaces and -")]
        public string Address { get; set; }
        public ICollection<Watch> Watches { get; set; }
    }
}
