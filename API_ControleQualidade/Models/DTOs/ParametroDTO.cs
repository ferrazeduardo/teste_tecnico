using API_ControleQualidade.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace API_ControleQualidade.Models.DTOs
{
    public class ParametroDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; } = string.Empty;
        public float VALOR_NOMINAL { get; set; }
        public float LIMITE_INFERIOR { get; set; }
        public float LIMITE_SUPERIOR { get; set; }
        [Required]
        public string TIPO { get; set; } = string.Empty;

    }
}