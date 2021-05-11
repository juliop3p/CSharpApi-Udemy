using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace src.Api.Domain.Entities
{
  public class CepEntity : BaseEntity
  {
    [Required]
    [MaxLength(10)]
    public string Cep { get; set; }

    [Required]
    [MaxLength(60)]
    public string Logradouro { get; set; }

    [MaxLength(10)]
    public string Numero { get; set; }

    [Required]
    public Guid MuniciopioId { get; set; }

    public MunicipioEntity Municiopio { get; set; }
  }
}
