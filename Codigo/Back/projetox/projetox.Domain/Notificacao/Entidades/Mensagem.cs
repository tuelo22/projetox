using projetox.Domain.Notification.Enumerados;

namespace projetox.Domain.Notification.Entidades
{
    public class Mensagem
    {
        public String Valor { get; set; }
        public String? Complemento { get; set; }

        public TipoMensagem TipoMensagem { get; set; }

        private Mensagem(String mensagem, TipoMensagem tipoMensagem, String? complemento = null)
        {
            this.Valor = mensagem;
            this.TipoMensagem = tipoMensagem;
            this.Complemento = complemento;
        }

        public static Mensagem Trace(String mensagem) => new (mensagem, TipoMensagem.Trace); 
        public static Mensagem Debug(String mensagem) => new (mensagem, TipoMensagem.Debug);
        public static Mensagem Info(String mensagem) => new (mensagem, TipoMensagem.Info);
        public static Mensagem Warn(String mensagem) => new (mensagem, TipoMensagem.Warn);
        public static Mensagem Error(String mensagem) => new (mensagem, TipoMensagem.Error);
        public static Mensagem Fatal(String mensagem, string? complemento) => new(mensagem, TipoMensagem.Fatal, complemento);
    
        public static bool Sucesso(List<Mensagem> notifications) => !notifications.Any(x => x.TipoMensagem == TipoMensagem.Fatal || x.TipoMensagem == TipoMensagem.Error);
    }
}
