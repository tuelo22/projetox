using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.ValueObjects
{
    public class Endereco : Notificavel
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string CodIBGE { get; set; }

        /// <summary>
        /// Construtor do Entity
        /// </summary>
        public Endereco(){}

        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="logradouro"></param>
        /// <param name="numero"></param>
        /// <param name="complemento"></param>
        /// <param name="bairro"></param>
        /// <param name="cidade"></param>
        /// <param name="estado"></param>
        /// <param name="cep"></param>
        /// <param name="codIBGE"></param>
        public Endereco(string logradouro, string numero, string? complemento, string bairro, string cidade, string estado, string cep, string codIBGE)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            CodIBGE = codIBGE;
        }
    }
}
