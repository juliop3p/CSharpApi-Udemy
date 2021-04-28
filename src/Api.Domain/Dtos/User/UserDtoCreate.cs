using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
  public class UserDtoCreate
  {
    [Required(ErrorMessage = "Nome é um campo obrigatório!")]
    [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email é campo obrigatório para Login!")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }
  }
}
