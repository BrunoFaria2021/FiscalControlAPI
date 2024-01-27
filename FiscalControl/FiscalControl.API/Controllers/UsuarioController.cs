using FiscalControl.Application.DTO;
using FiscalControl.Application.Interfaces;
using FiscalControl.CrossCutting.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FiscalControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var dados = await _usuarioAppService.BuscarTodosUsuarios();

            if (!dados.Success)
            {
                return HandleResponse(dados);
            }

            return Ok(dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dados = await _usuarioAppService.BuscarUsuario(id);

            if (!dados.Success)
            {
                return HandleResponse(dados);
            }

            return Ok(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuario)
        {
            var dados = await _usuarioAppService.CriarUsuario(usuario);

            if (!dados.Success)
            {
                return HandleResponse(dados);
            }

            return Ok(dados);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UsuarioDTO usuario)
        {
            var dados = await _usuarioAppService.EditarUsuario(id, usuario);

            if (!dados.Success)
            {
                return HandleResponse(dados);
            }

            return Ok(dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dados = await _usuarioAppService.DeletarUsuario(id);

            if (!dados.Success)
            {
                return HandleResponse(dados);
            }

            return Ok(dados);
        }

        private IActionResult HandleResponse<T>(RetornoApi<T> retorno)
        {
            if (retorno.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(retorno);
            }

            if (retorno.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(retorno);
            }

            if (retorno.StatusCode == HttpStatusCode.InternalServerError)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }
    }
}