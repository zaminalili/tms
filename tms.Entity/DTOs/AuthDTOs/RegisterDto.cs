using System.ComponentModel.DataAnnotations;

namespace tms.Entity.DTOs.AuthDTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eyni deyil.")]
        public string ConfirmPassword { get; set; }
    }
}
