using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.DTO;

namespace projetox.Domain.Core.Interfaces.Services
{
    public interface IPropostaValorService : IServiceBase
    {
        ResponseBaseDTO Cadastrar(Guid IdUsuario, PropostaValorDTO dto);

        ListarPropostaValorResponseDTO Listar(Guid IdUsuario, Guid IdEmpresa);

        ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdProposta);

        ResponseBaseDTO Atualizar(Guid IdUsuario, PropostaValorDTO dto);
    }
}
