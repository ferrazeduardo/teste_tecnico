using API_ControleQualidade.Models.Entidades;

namespace API_ControleQualidade.Models.Interfaces.Repository
{
    public interface IParametroRepository
    {
        IEnumerable<Parametro> GetParametroByIdLote(int id);
    }
}
