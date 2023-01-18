using System.ComponentModel.DataAnnotations;

namespace API_ControleQualidade.Models.DTOs
{
    public class EnsaioQualidadeDTO
    {
        public int lote { get; set; }
        public int parametro { get; set; }
        public float vl_quantitativo { get; set; }
        public string vl_qualitativo { get; set; } = string.Empty;
        public int NR_ORDEM { get; set; } 
    }
}
