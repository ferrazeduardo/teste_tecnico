using API_ControleQualidade.Models.Interfaces.Repository;
using Microsoft.AspNetCore.Hosting.Server;

namespace API_ControleQualidade.Repository
{
    public class ConnectionString : IConnectionString
    {
        public string GetConnectionString()
        {
            return "Server=IP_BANCO;Database=TESTE_TECNICO;User Id=sa;Password=SENHA;";
        }
    }
}
