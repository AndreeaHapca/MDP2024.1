using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Watchmasters.Models
{
    public class Watch
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Watch brand is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Watch brand must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage ="Watch brand can contain only letters and spaces")]
        public string Brand { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Watch model is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Watch model must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Watch model can contain only letters, digits, spaces and -")]
        public string Model { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Watch reference number is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Watch reference number must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Watch reference number can contain only letters, digits, spaces, . or -")]
        public string RefNr { get; set; }

        [Column(TypeName = "varchar(4)")]
        [Required(ErrorMessage = "Watch year of manufacturing is required")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Watch year of manufacturing must be 4 digits long")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Watch year of manufacturing can contain only digits")]
        public string Year { get; set; }

        [Column(TypeName = "decimal(11, 2)")]
        [Required(ErrorMessage = "Watch price is required")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Watch price can contain only digits and .")]
        public decimal Price { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required(ErrorMessage = "Watch description is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Watch description must be between 5 and 500 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-+.,\s]+$", ErrorMessage = "Watch description can contain only letters spaces and symbols")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(1)")]
        [Required(ErrorMessage = "Watch gender is required")]
        [StringLength(1, ErrorMessage = "Watch gender must be 1 digit long")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Watch gender can contain only uppercase letters")]
        public string Gender { get; set; }
        
        public int StoreID { get; set; }

        public Store Store { get; set; }
    }
}
