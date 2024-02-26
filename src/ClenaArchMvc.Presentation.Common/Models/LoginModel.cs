using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Presentation.Common.Models
{
    public class LoginModel : BaseModel
    {
        public string? ReturnUrl { get; set; }
    }
}
