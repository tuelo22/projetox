using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;

namespace projetox.Domain.Core.Interfaces.Services
{
    public interface ISegmentoClienteService : IServiceBase
    {
        ResponseBaseDTO Cadastrar(Guid IdUsuario, SegmentoClienteDTO dto);

        ListarSegmentoClienteResponseDTO Listar(Guid IdUsuario, Guid IdPropostaValor);

        ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdSegmentoCliente);

        ResponseBaseDTO Atualizar(Guid IdUsuario, SegmentoClienteDTO dto);
    }
}
