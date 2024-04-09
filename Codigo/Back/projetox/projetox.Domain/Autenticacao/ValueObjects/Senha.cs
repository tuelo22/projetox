using projetox.Domain.Notification.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Senha : Notificavel
    {
        private const string IDSENHA = "57c3504f-61c6-4476-8542-95a48779ff61";

        public string Valor { get; set; }

        public Senha()
        {
            Valor = String.Empty;
        }

        public Senha(string valor)
        {
            this.Valor = valor.Contains(IDSENHA) ? valor : CriptografarSenha(valor);
        }

        private string CriptografarSenha(string senha)
        {
            if (!ValidarSenha(senha))
            {
                AddMensagem(Mensagem.Error("A senha não atende aos requisitos necessários, por favor verificar."));

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

        // A senha deve ter mais de 8 caracteres e possuir um caracter especial.
        private static bool ValidarSenha(string valor)
        {            
            if (valor.Length < 8)
                return false;

            if (!valor.Any(c => !char.IsLetterOrDigit(c)))
                return false;

            return true;
        }

        public String ResetarSenha()
        {
            var senha = GerarSenha();

            Valor = CriptografarSenha(senha);

            return senha;
        }

        private static string GerarSenha()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";

            Random random = new();

            char[] senhaArray = new char[8];

            for (int i = 0; i < 7; i++)
            {
                senhaArray[i] = caracteres[random.Next(caracteres.Length)];
            }

            senhaArray[7] = "!@#$%^&*()-_=+"[random.Next(12)];

            for (int i = 0; i < senhaArray.Length; i++)
            {
                int randomIndex = random.Next(senhaArray.Length);
                char temp = senhaArray[i];
                senhaArray[i] = senhaArray[randomIndex];
                senhaArray[randomIndex] = temp;
            }
            return new string(senhaArray);
        }
    }
}
