using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;
using FiscalControl.Infra.Data.Interfaces;
using System.Net;

namespace FiscalControl.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RetornoApi<List<Usuario>> BuscarTodosUsuarios()
        {
            RetornoApi<List<Usuario>> retorno = new RetornoApi<List<Usuario>>()
            {
                Success = false,
                Message = $"Nenhum usuário encontrado!",
                StatusCode = HttpStatusCode.NotFound
            };

            try
            {
                var usuarios = _context.Usuario.ToList();

                if (usuarios.Any())
                {
                    retorno.Success = true;
                    retorno.Data = usuarios;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuários encontrados com sucesso";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public RetornoApi<Usuario> BuscarUsuario(Guid id)
        {
            RetornoApi<Usuario> retorno = new RetornoApi<Usuario>()
            {
                Success = false,
                Message = $"Usuário não encontrado!",
                StatusCode = HttpStatusCode.NotFound
            };

            try
            {
                var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);

                if (usuario != null)
                {
                    retorno.Success = true;
                    retorno.Data = usuario;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Usuário encontrado com sucesso";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public RetornoApi<Usuario> CriarUsuario(Usuario usuario)
        {
            RetornoApi<Usuario> retorno = new RetornoApi<Usuario>()
            {
                Success = false,
                Message = $"Falha ao criar usuário!",
                StatusCode = HttpStatusCode.InternalServerError
            };

            try
            {
                _context.Usuario.Add(usuario);
                var operacao = _context.SaveChanges();

                if (operacao == 1)
                {
                    retorno.Success = true;
                    retorno.Data = usuario;
                    retorno.StatusCode = HttpStatusCode.Created;
                    retorno.Message = "Usuário criado com sucesso";
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                return retorno;
            }
        }

        public RetornoApi<Usuario> DeletarUsuario(Guid id)
        {
            RetornoApi<Usuario> retorno = new RetornoApi<Usuario>()
            {
                Success = false,
                Message = $"Falha ao deletar usuário!",
                StatusCode = HttpStatusCode.InternalServerError
            };

            try
            {
                var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);

                if (usuario != null)
                {
                    _context.Usuario.Remove(usuario);
                    var operacao = _context.SaveChanges();

                    if (operacao == 1)
                    {
                        retorno.Success = true;
                        retorno.StatusCode = HttpStatusCode.OK;
                        retorno.Message = "Usuário deletado com sucesso";
                    }
                }
                else
                {
                    retorno.Message = "Usuário não encontrado para deletar";
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

        public RetornoApi<Usuario> EditarUsuario(Guid id, Usuario usuario)
        {
            RetornoApi<Usuario> retorno = new RetornoApi<Usuario>()
            {
                Success = false,
                Message = $"Falha ao editar usuário!",
                StatusCode = HttpStatusCode.InternalServerError
            };

            try
            {
                var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.Id == id);

                if (usuarioExistente != null)
                {
                    // Atualizar propriedades do usuárioExistente com os valores do usuário
                    _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

                    var operacao = _context.SaveChanges();

                    if (operacao == 1)
                    {
                        retorno.Success = true;
                        retorno.Data = usuarioExistente;
                        retorno.StatusCode = HttpStatusCode.OK;
                        retorno.Message = "Usuário editado com sucesso";
                    }
                }
                else
                {
                    retorno.Message = "Usuário não encontrado para editar";
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
    }
}