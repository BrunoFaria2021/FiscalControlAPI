using FiscalControl.Application.DTO;
using FiscalControl.Application.Interfaces;
using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;
using FiscalControl.Infra.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FiscalControl.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        private readonly IConfiguration _configuration;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IAutenticacaoRepository autenticacaoRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _autenticacaoRepository = autenticacaoRepository;
            _configuration = configuration;
        }

        public async Task<RetornoApi<List<UsuarioViewModel>>> BuscarTodosUsuarios()
        {
            var retorno = new RetornoApi<List<UsuarioViewModel>>();

            try
            {
                var usuarios = _usuarioRepository.BuscarTodosUsuarios();

                if (usuarios.Success)
                {
                    var usuariosViewModel = usuarios.Data.ConvertAll(usuario => MapUsuarioToViewModel(usuario));

                    retorno.Success = true;
                    retorno.Data = usuariosViewModel;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuários encontrados com sucesso";
                }
                else
                {
                    retorno.Message = "Nenhum usuário encontrado";
                    retorno.StatusCode = HttpStatusCode.NotFound;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public async Task<RetornoApi<UsuarioViewModel>> BuscarUsuario(Guid id)
        {
            var retorno = new RetornoApi<UsuarioViewModel>();

            try
            {
                var usuario = _usuarioRepository.BuscarUsuario(id);
                if (usuario.Success)
                {
                    var usuarioViewModel = MapUsuarioToViewModel(usuario.Data);

                    retorno.Success = true;
                    retorno.Data = usuarioViewModel;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuário encontrado com sucesso";
                }
                else
                {
                    retorno.Message = "Usuário não encontrado";
                    retorno.StatusCode = HttpStatusCode.NotFound;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public async Task<RetornoApi<UsuarioViewModel>> CriarUsuario(UsuarioDTO usuarioDTO)
        {
            var retorno = new RetornoApi<UsuarioViewModel>();

            try
            {
                var checarEmail = _autenticacaoRepository.BuscarUsuarioPorEmail(usuarioDTO.Email);

                if (checarEmail.Data != null)
                {
                    retorno.Message = "Este email já está sendo utilizado";
                    retorno.Success = false;
                    retorno.StatusCode = HttpStatusCode.BadGateway;
                    return retorno;
                }

                var senhaSegura = HashSenha.HashSenhaUsuario(usuarioDTO.Senha);

                var novoUsuario = new Usuario
                {
                    Nome = usuarioDTO.Nome,
                    Email = usuarioDTO.Email,
                    Senha = senhaSegura,
                    // Outras propriedades
                };

                var usuarioCriado = _usuarioRepository.CriarUsuario(novoUsuario);

                if (usuarioCriado.Success)
                {
                    var usuarioViewModel = MapUsuarioToViewModel(usuarioCriado.Data);

                    retorno.Success = true;
                    retorno.Data = usuarioViewModel;
                    retorno.StatusCode = HttpStatusCode.Created;
                    retorno.Message = "Usuário criado com sucesso";
                }
                else
                {
                    retorno.Message = "Falha ao criar o usuário";
                    retorno.StatusCode = HttpStatusCode.InternalServerError;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public async Task<RetornoApi<UsuarioViewModel>> DeletarUsuario(Guid id)
        {
            var retorno = new RetornoApi<UsuarioViewModel>();

            try
            {
                var resultado = _usuarioRepository.DeletarUsuario(id);

                if (resultado.Success)
                {
                    retorno.Success = true;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuário deletado com sucesso";
                }
                else
                {
                    retorno.Message = "Falha ao deletar o usuário";
                    retorno.StatusCode = HttpStatusCode.InternalServerError;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public async Task<RetornoApi<UsuarioViewModel>> EditarUsuario(Guid id, UsuarioDTO usuarioDTO)
        {
            var retorno = new RetornoApi<UsuarioViewModel>();

            try
            {
                var usuarioExistente = _usuarioRepository.BuscarUsuario(id);

                if (!usuarioExistente.Success)
                {
                    retorno.Message = "Usuário não encontrado";
                    retorno.StatusCode = HttpStatusCode.NotFound;
                    return retorno;
                }

                usuarioExistente.Data.Nome = usuarioDTO.Nome;
                usuarioExistente.Data.Email = usuarioDTO.Email;

                var usuarioAtualizado = _usuarioRepository.EditarUsuario(id, usuarioExistente.Data);

                if (usuarioAtualizado.Success)
                {
                    var usuarioViewModel = MapUsuarioToViewModel(usuarioAtualizado.Data);

                    retorno.Success = true;
                    retorno.Data = usuarioViewModel;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuário atualizado com sucesso";
                }
                else
                {
                    retorno.Message = "Falha ao atualizar o usuário";
                    retorno.StatusCode = HttpStatusCode.InternalServerError;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        private UsuarioViewModel MapUsuarioToViewModel(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                // Mapear outras propriedades conforme necessário
            };
        }
    }
}