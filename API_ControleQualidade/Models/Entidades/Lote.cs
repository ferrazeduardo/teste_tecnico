namespace API_ControleQualidade.Models.Entidades
{
    public sealed class Lote
    {
        public int ID_LOTE { get; set; }
        public string NM_LOTE { get; set; } = string.Empty;
        public string STATUS { get; set; } = string.Empty;
        public DateTime DH_REGISTRO { get; set; }
        public IEnumerable<EnsaioQualidade>? EnsaioQualidades { get; set; }
        public MetodolodiaAvalicao? MetodolodiaAvalicao { get; set; }
        public IEnumerable<Parametro>? Parametros { get; set; }


    }
}
