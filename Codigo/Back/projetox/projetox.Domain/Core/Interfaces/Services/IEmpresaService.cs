using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;

namespace projetox.Domain.Core.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase
    {
        ResponseBaseDTO Cadastrar(Guid IdUsuario, EmpresaDTO dto);

        ListarEmpresaResponseDTO Listar(Guid IdUsuario);

        ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdEmpresa);

        ResponseBaseDTO Atualizar(Guid IdUsuario, EmpresaDTO dto);
    }
}
