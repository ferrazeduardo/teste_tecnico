using System.ComponentModel.DataAnnotations;

namespace API_ControleQualidade.Models.DTOs
{
    public class LoteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; } = string.Empty;

        [StringLength(50)]
        public string STATUS { get; set; } = string.Empty;


        public MetodologiaAvalicaoDTO? MetodologiaAvalicaoDTO { get; set; }
        public IEnumerable<EnsaioQualidadeDTO>? EnsaioQualidadeDTOs { get; set; }
        public IEnumerable<ParametroDTO>? ParametroDTOs { get; set; }


    }
}
