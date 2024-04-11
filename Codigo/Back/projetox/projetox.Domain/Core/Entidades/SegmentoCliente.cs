using projetox.Domain.Base.Entidades;
using projetox.Domain.Core.Enumerados;
using projetox.Domain.Core.ValueObjects;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class SegmentoCliente : BaseEntity
    {
        public String Ajudar { get; private set; }
        public String BuscarProduto { get; private set; }
        public String ServindoPessoa { get; private set; }
        public ClienteDispostoPagar ClienteDispostoPagar { get; private set; }

        public Monetario Valor { get; private set; }
        public virtual PropostaValor PropostaValor { get; private set; }

        public virtual ICollection<SegmentoBuscarEmpresa> SegmentoBuscarEmpresas { get; private set; } = [];
        public virtual ICollection<SegmentoReclamacaoAtendimento> SegmentoReclamacaoAtendimentos { get; private set; } = [];
        public virtual ICollection<SegmentoAjudarPessoa> SegmentoAjudarPessoas { get; private set; } = [];

        /// <summary>
        /// Construtor do Entity.
        /// </summary>
        public SegmentoCliente(){}

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="ajudar"></param>
        /// <param name="buscarProduto"></param>
        /// <param name="servindoPessoa"></param>
        /// <param name="clienteDispostoPagar"></param>
        /// <param name="valor"></param>
        /// <param name="propostaValor"></param>
        public SegmentoCliente(string ajudar, string buscarProduto, string servindoPessoa, ClienteDispostoPagar clienteDispostoPagar, Monetario valor, PropostaValor propostaValor)
        {
            Ajudar = ajudar;
            BuscarProduto = buscarProduto;
            ServindoPessoa = servindoPessoa;
            ClienteDispostoPagar = clienteDispostoPagar;
            Valor = valor;
            PropostaValor = propostaValor;

            if (String.IsNullOrEmpty(Ajudar))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Ajudar."));
            }

            if (String.IsNullOrEmpty(BuscarProduto))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Buscar Produto."));
            }

            if (String.IsNullOrEmpty(ServindoPessoa))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Servindo Pessoa."));
            }
        }
    }
}
