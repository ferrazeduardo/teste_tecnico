using API_ControleQualidade.Models.Entidades;

namespace API_ControleQualidade.Models.Interfaces.Repository
{
    public interface ILoteRepository
    {
        IEnumerable<Lote> AllGet();
        Lote GetLote(int id);
    }
}
