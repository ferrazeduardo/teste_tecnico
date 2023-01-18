namespace API_ControleQualidade.Models.Entidades
{
    public class MetodolodiaAvalicao
    {
        public int ID_METODO_AVALIACAO { get; set; }
        public string DS_METODO_AVALIACAO { get; set; } = string.Empty;
        public DateTime DH_REGISTRO { get; set; }
        public int QT_MINIMA { get; set; }
        public string AGRUPAMENTO { get; set; } = string.Empty;
        public int QT_CALCULO { get; set; }
        public string TP_CALCULO { get; set; } = string.Empty;
        public int ID_LOTE { get; set; }


    }
}
