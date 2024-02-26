using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Presentation.Common.Models
{
    public class RegisterModel : BaseModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }
    }
}
