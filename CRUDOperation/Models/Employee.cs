using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDOperation.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        // we use question mark to alow null value in string
        [Required]
        [Display(Name= "Employee Full Name")]
        [MaxLength(40)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }

        [Required]
        [Display(Name = "Create Password")]
        [DataType(DataType.Password)]
        public string? CreatePassword { get; set;}

        [Required]
        [Display(Name ="Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Range(18,60)]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
