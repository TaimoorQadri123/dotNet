using System.ComponentModel.DataAnnotations;

namespace FirstApplication.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(20,ErrorMessage ="Name canot be longer than 20 charactestics")]
        public string Name { get; set; }



        [EmailAddress(ErrorMessage ="Invalid EmailAddress ")]

        public string Email { get; set; }


        [Range(18, 60, ErrorMessage = "Age must be between 18 and 20")]
        public int Age { get; set; }
    }
}