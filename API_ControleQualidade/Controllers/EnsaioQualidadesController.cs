using API_ControleQualidade.Business;
using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace API_ControleQualidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnsaioQualidadesController : ControllerBase
    {
        private readonly IEnsaioQualidadeBusiness _ensaioQualidadeBusiness;

        public EnsaioQualidadesController(IEnsaioQualidadeBusiness ensaioQualidadeBusiness)
        {
            _ensaioQualidadeBusiness = ensaioQualidadeBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEnsaioQualidade([FromBody] IEnumerable<EnsaioQualidadeDTO> ensaioQualidadeDTOs)
        {
            try
            {
                await Task.Run(() => _ensaioQualidadeBusiness.InsertEnsarioQualidade(ensaioQualidadeDTOs));
                return Ok();
            }
            catch (SqlException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { erro = 500, mensagem = "Erro Interno do Servidor" });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { erro = 500, mensagem = "Erro Interno do Servidor" });
            }
        }
    }
}
