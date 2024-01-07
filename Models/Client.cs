using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Watchmasters.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Client name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Client name must be between 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Client name can contain only letters, spaces and -")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Client email is required")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Client email must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-._@\s]+$", ErrorMessage = "Client email can contain only letters, spaces, -, _, . or @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Client phone number is required")]
        [Column(TypeName = "varchar(25)")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Client phone number must be between 5 and 25 characters")]
        [RegularExpression(@"^[0-9-+\s]+$", ErrorMessage = "Client phone number can contain only letters, spaces, - or +")]
        public string PhoneNr { get; set; }

        [Required(ErrorMessage = "Client's last purchase is required")]
        [Column(TypeName = "decimal(11, 2)")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Client's last purchase can contain only digits and .")]
        public decimal LastPurchase { get; set; }
        public int PrefStoreID { get; set; }
        public Store PrefStore { get; set; }
    }
}
