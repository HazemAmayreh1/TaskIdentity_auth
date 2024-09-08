using System.ComponentModel.DataAnnotations;

namespace TaskIdentity.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }  

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }


    }
}
