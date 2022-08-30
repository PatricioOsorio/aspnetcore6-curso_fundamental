using System.ComponentModel.DataAnnotations;

namespace CursoFundamental.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Name { get; set; }

    [Display(Name = "Numero de telefono")]
    [Required(ErrorMessage = "Numero de telefono obligatorio")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Correo electronico")]
    [Required(ErrorMessage = "Correo electronico obligatorio")]
    public string Email { get; set; }
  }
}
