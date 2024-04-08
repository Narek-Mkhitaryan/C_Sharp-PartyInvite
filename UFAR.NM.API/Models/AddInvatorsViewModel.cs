using System.ComponentModel.DataAnnotations;

namespace UFAR.NM.API.Models
{
    public class AddInvatorsViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Fill in the field for the name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mail is required!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valide Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill in the field for the Phone!")]
        public string Phone { get; set; }
        //      public bool? WillAttend { get; set; }
    }
}
