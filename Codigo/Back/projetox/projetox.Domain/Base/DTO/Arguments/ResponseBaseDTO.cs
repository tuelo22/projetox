using projetox.Domain.Notification.DTO;

namespace projetox.Domain.Base.DTO.Arguments
{
    /// <summary>
    /// Resposta padrão com a lista de mensagens geradas na requisição.
    /// </summary>
    public class ResponseBaseDTO
    {
        /// <summary>
        /// Lista de mensagens.
        /// </summary>
        public List<MensagemDTO> Mensagens { get; set; }
    }
}
