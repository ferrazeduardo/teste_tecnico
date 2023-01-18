using System.ComponentModel.DataAnnotations;

namespace API_ControleQualidade.Models.DTOs
{
    public class MetodologiaAvalicaoDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; } = string.Empty;

        public int QT_CALCULO { get; set; }

    }
}
