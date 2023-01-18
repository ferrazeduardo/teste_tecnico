using API_ControleQualidade.Business;
using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Interfaces.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace API_ControleQualidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly ILoteBusiness _loteBusiness;

        public LoteController(ILoteBusiness loteBusiness)
        {
            _loteBusiness = loteBusiness;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var async = Task.Run(() => _loteBusiness.GetAll());
                await async;
                IEnumerable<LoteDTO> loteDTOs = async.Result;

                if (loteDTOs is not null)
                    return Ok(loteDTOs);

                return NotFound(new
                {
                    status = 404,
                    mensagem = "lotes não econtrados"
                });
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLote(int id)
        {
            try
            {
                var async = Task.Run(() => _loteBusiness.GetLote(id));
                await async;
                LoteDTO loteDTO = async.Result;

                if (loteDTO is not null)
                    return Ok(loteDTO);

                return NotFound(new
                {
                    status = 404,
                    mensagem = "lote não encontrado"
                });
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
