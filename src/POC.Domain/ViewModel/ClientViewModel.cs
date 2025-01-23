using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace POC.Domain.ViewModel
{
    public class ClientViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MinLength(8)]
        [MaxLength(100)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string AccessToken { get; set; }

    }
}