using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.Entidades;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.ValueObjects;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class Empresa : PersistenceEntity
    {
        public Empresa(Usuario usuario, Documento documento, 
            NaturezaJuridica naturezaJuridica, Endereco endereco, 
            Telefone telefone,DateTime abertura, 
            int quantidadeFuncionario, string nome, string uRLSite)
        {
            Usuario = usuario;
            Documento = documento;
            NaturezaJuridica = naturezaJuridica;
            Abertura = abertura;
            Telefone = telefone;
            URLSite = uRLSite;
            Endereco = endereco;

            if (Abertura == DateTime.MinValue)
            {
                AddMensagem(Mensagem.Error("Data de abertura invalida."));
            }
            else if (Abertura > DateTime.Now)
            {
                AddMensagem(Mensagem.Error("A data de abertura não pode ser superior a data atual."));
            }

            QuantidadeFuncionario = quantidadeFuncionario;
            if(QuantidadeFuncionario < 0)
            {
                AddMensagem(Mensagem.Error("A quantidade de funcionarios não deve ser menor que zero."));
            }
            
            Nome = nome;
            if (String.IsNullOrEmpty(Nome))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o nome da empresa."));
            }
        }

        public Usuario Usuario { get; private set; }
        public Documento  Documento { get; private set; }
        public NaturezaJuridica NaturezaJuridica { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        public DateTime Abertura { get; private set; }
        public Int32 QuantidadeFuncionario { get; private set; }
        public String Nome { get; private set; }
        public String? URLSite{ get; private set; }
        public ICollection<RedeSocial> RedesSociais { get; } = new List<RedeSocial>();
    }
}
