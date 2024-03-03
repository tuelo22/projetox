using projetox.Domain.Notification.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Senha : Notificavel
    {
        private readonly static string IDSENHA = "57c3504f-61c6-4476-8542-95a48779ff61";

        public string Valor { get; set; }

        public Senha()
        {
            Valor = String.Empty;
        }

        public Senha(string valor)
        {
            this.Valor = valor.Contains(IDSENHA) ? valor : CriptografarSenha(valor);
        }

        public string CriptografarSenha(string senha)
        {
            if (ValidarSenha(senha))
            {
                AddMensagem(Mensagem.Error("Senha fora do padrão, por favor verificar."));

                return senha;
            }
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(senha));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return $"{builder}{IDSENHA}";
        }

        static bool ValidarSenha(string valor)
        {            
            if (valor.Length < 8)
                return false;

            if (!valor.Any(c => !char.IsLetterOrDigit(c)))
                return false;

            return true;
        }
    }
}
