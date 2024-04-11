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
            ClienteDispostoPagar = clienteDispostoPagar;
            Valor = valor;
            PropostaValor = propostaValor;

            SetAjudar(ajudar);
            SetBuscarProduto(buscarProduto);
            SetServindoPessoa(servindoPessoa);
        }
   
        private void SetAjudar(string ajudar)
        {
            Ajudar = ajudar;

            if (String.IsNullOrEmpty(Ajudar))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Ajudar."));
            }
        } 

        private void SetBuscarProduto(string buscarProduto)
        {
            BuscarProduto = buscarProduto;
            
            if (String.IsNullOrEmpty(BuscarProduto))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Buscar Produto."));
            }
        }
        
        private void SetServindoPessoa(string servindoPessoa)
        {
            ServindoPessoa = servindoPessoa;

            if (String.IsNullOrEmpty(ServindoPessoa))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o campo Servindo Pessoa."));
            }
        }

        public void AtualizarAjudar(string ajudar) => SetAjudar(ajudar);
        public void AtualizarBuscarProduto(string buscarProduto) => SetBuscarProduto(buscarProduto);
        public void AtualizarServindoPessoa(string servindoPessoa) => SetServindoPessoa(servindoPessoa);
        public void AtualizaValor(Monetario valor) => Valor = valor;
        public void AtualizaClienteDispostoPagar(ClienteDispostoPagar clienteDispostoPagar) => ClienteDispostoPagar = clienteDispostoPagar;

        public void AddSegmentoBuscarEmpresa(List<SegmentoBuscarEmpresa> lista) => lista.ForEach(x => SegmentoBuscarEmpresas.Add(x));
        public void AddSegmentoBuscarEmpresa(SegmentoBuscarEmpresa item) => SegmentoBuscarEmpresas.Add(item);
        public void AtualizarSegmentoBuscarEmpresas(List<SegmentoBuscarEmpresa> lista)
        {
            SegmentoBuscarEmpresas.Clear();
            AddSegmentoBuscarEmpresa(lista);
        }

        public void AddSegmentoReclamacaoAtendimento(List<SegmentoReclamacaoAtendimento> lista) => lista.ForEach(x => SegmentoReclamacaoAtendimentos.Add(x));
        public void AddSegmentoReclamacaoAtendimento(SegmentoReclamacaoAtendimento item) => SegmentoReclamacaoAtendimentos.Add(item);
        public void AtualizarSegmentoReclamacaoAtendimentos(List<SegmentoReclamacaoAtendimento> lista)
        {
            SegmentoReclamacaoAtendimentos.Clear();
            AddSegmentoReclamacaoAtendimento(lista);
        }

        public void AddSegmentoAjudarPessoa(List<SegmentoAjudarPessoa> lista) => lista.ForEach(x => SegmentoAjudarPessoas.Add(x));
        public void AddSegmentoAjudarPessoa(SegmentoAjudarPessoa item) => SegmentoAjudarPessoas.Add(item);
        public void AtualizarSegmentoAjudarPessoas(List<SegmentoAjudarPessoa> lista)
        {
            SegmentoAjudarPessoas.Clear();
            AddSegmentoAjudarPessoa(lista);
        }
    }
}
