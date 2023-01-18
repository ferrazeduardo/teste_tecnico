namespace API_ControleQualidade.Models.Entidades
{
    public class Parametro
    {
        public int ID_PARAMETRO { get; set; }
        public string DS_PARAMETRO { get; set; } = string.Empty;
        public float VALOR_NOMINAL { get; set; }
        public float LIMITE_INFERIOR { get; set; }
        public float LIMITE_SUPERIOR { get; set; }
        public int ID_METODO_AVALIACAO { get; set; }
        public int ID_TIPO_PARAMETRO { get; set; }

        public TipoParametro? TipoParametro { get; set; }

    }
}