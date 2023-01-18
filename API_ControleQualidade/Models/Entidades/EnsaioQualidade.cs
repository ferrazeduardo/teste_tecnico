namespace API_ControleQualidade.Models.Entidades
{
    public class EnsaioQualidade
    {
        public int ID_ENSAIO_QUALIDADE { get; set; }
        public int ID_LOTE { get; set; }
        public int ID_PARAMETRO { get; set; }
        public DateTime DH_REGISTRO { get; set; }
        public float VL_QUANTITATIVO { get; set; }
        public string VL_QUALITATIVO { get; set; } = string.Empty;
        public int NR_ORDEM { get; set; }


    }
}
