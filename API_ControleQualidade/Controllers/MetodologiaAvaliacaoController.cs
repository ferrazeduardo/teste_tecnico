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
    public class MetodologiaAvaliacaoController : ControllerBase
    {
        private readonly IMetodologiaAvaliacaoBusiness _metodologiaAvaliacaoBusiness;

        public MetodologiaAvaliacaoController(IMetodologiaAvaliacaoBusiness metodologiaAvaliacaoBusiness)
        {
            _metodologiaAvaliacaoBusiness = metodologiaAvaliacaoBusiness;
        }

        [HttpGet("ByIdLote/{id}")]
        public async Task<IActionResult> GetMetodologiaAvaliacaoByIdLote(int id)
        {
            try
            {
                var asyncMetodologiasAvaliacao = Task.Run(() => _metodologiaAvaliacaoBusiness.GetMetodologiasAvaliacaoByIdLote(id));
                await asyncMetodologiasAvaliacao;

                MetodologiaAvalicaoDTO metodolodiaAvalicao = asyncMetodologiasAvaliacao.Result;

                if (metodolodiaAvalicao is not null)
                    return Ok(metodolodiaAvalicao);

                return NotFound(new
                {
                    status = 404,
                    mensagem = "Metodologia não encontrada"
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
