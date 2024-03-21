using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Notification.DTO
{
    public class MensagemDTO
    {
        /// <summary>
        /// Descrição da mensagem
        /// </summary>        
        /// <example>Registro processado com sucesso !</example>
        public String? Mensagem { get; set; }

        /// <summary>
        /// Complementando da mensagem com dados especificos
        /// </summary>        
        /// <example>800.000 registros processados.</example>
        public String? Complemento { get; set; }

        /// <summary>
        /// Tipo da mensagem = (Trace, Debug, Info, Warn, Error, Fatal).
        /// </summary>        
        /// <example>Info</example>
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
