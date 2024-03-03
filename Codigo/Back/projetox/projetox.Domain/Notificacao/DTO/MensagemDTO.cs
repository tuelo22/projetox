using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Notification.DTO
{
    public class MensagemDTO
    {
        public String? Mensagem { get; set; }
        public String? Complemento { get; set; }
        public String? TipoMensagem { get; set; }

        public static explicit operator MensagemDTO(Mensagem entidade)
        {
            return new MensagemDTO()
            {
                Mensagem = entidade.Valor,
                Complemento = entidade.Complemento,
                TipoMensagem = entidade.TipoMensagem.ToString()
            };
        }
    }
}
