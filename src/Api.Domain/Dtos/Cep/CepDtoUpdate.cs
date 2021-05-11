using System;
using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.Dtos.Cep
{
  public class CepDtoUpdate
  {
    [Required(ErrorMessage = "CEP é campo obrigatório")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Logradouro é campo obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "Numero é campo obrigatório")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "Municipio é campo obrigatório")]
    public Guid MunicipioId { get; set; }
  }
}
