using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDOperation.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        // we use question mark to alow null value in string
        [Required]
        [Display(Name = "Student Full Name")]
        [MaxLength(40)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        [MaxLength(40)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string? CourseName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Graduation Degree Name")]
        [MaxLength(40)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string? GraduationDegreeName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOJ_Class { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
