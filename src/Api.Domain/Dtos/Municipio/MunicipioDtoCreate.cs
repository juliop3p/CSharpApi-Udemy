using System;
using System.ComponentModel.DataAnnotations;
using src.Api.Domain.Dtos.Uf;

namespace src.Api.Domain.Dtos.Municipio
{
  public class MunicipioDtoCreate
  {
    [Required(ErrorMessage = "Nome de Município é Campo Obrigatório")]
    [MaxLength(60, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O Código do IBGE é Inválido")]
    public int CodIBGE { get; set; }

    [Required(ErrorMessage = "Código de UF é Campo Obrigatório")]
    public Guid UfId { get; set; }
  }
}
