using System.ComponentModel.DataAnnotations;

namespace UFAR.NM.API.Models.Entites
{
    public class Invations
    {
       
        [Required(ErrorMessage = "Favourite Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mail is required!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valide fancy email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favourite Phone is required!")]
        public string Phone { get; set; }
        public Guid Id { get; set; }

    }
}




