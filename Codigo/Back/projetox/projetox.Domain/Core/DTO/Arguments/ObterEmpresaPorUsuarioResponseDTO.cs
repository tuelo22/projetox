using projetox.Domain.Base.DTO.Arguments;

namespace projetox.Domain.Core.DTO.Arguments
{
    public class ObterEmpresaPorUsuarioResponseDTO : ResponseBaseDTO
    {
        public List<EmpresaDTO> Empresas { get; set; } = [];
    }
}
