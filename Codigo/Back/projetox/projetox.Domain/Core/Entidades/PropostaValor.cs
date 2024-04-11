using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class PropostaValor : BaseEntity
    {
        public String DescricaoNegocio { get; private set; }
        public String FazerNegocio { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual ICollection<RelacionamentoCliente> RelacionamentoClientes { get; private set; } = [];
        public virtual ICollection<CanalDistribuicaoOpcao> CanalDistribuicaoOpcoes { get; private set; } = [];
        public virtual ICollection<FonteReceita> FontesReceita { get; private set; } = [];
        public virtual ICollection<SegmentoCliente> SegmentosClientes { get; private set; } = [];

        /// <summary>
        /// Construtor do Entity
        /// </summary>
        public PropostaValor()
        {            
        }

        /// <summary>
        /// Construtor principal.
        /// </summary>
        /// <param name="descricaoNegocio"></param>
        /// <param name="fazerNegocio"></param>
        /// <param name="empresa"></param>
        public PropostaValor(String descricaoNegocio, String fazerNegocio, Empresa empresa)
        {
            DescricaoNegocio = descricaoNegocio;
            FazerNegocio = fazerNegocio;
            Empresa = empresa;

            if (String.IsNullOrEmpty(DescricaoNegocio))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição de negócio."));
            }

            if (String.IsNullOrEmpty(FazerNegocio))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição fazer negócio."));
            }
        }
          
        public void AddRelacionamentoCliente(List<RelacionamentoCliente> lista) => lista.ForEach(x => RelacionamentoClientes.Add(x));

        public void AtualizarRelacionamentoCliente(List<RelacionamentoCliente> lista)
        {
            RelacionamentoClientes.Clear();
            AddRelacionamentoCliente(lista);
        }

        public void AddCanalDistribuicaoOpcoes(List<CanalDistribuicaoOpcao> lista) => lista.ForEach(x => CanalDistribuicaoOpcoes.Add(x));

        public void AtualizarCanalDistribuicaoOpcoes(List<CanalDistribuicaoOpcao> lista)
        {
            CanalDistribuicaoOpcoes.Clear();
            AddCanalDistribuicaoOpcoes(lista);
        }

        public void AddFontesReceita(List<FonteReceita> lista) => lista.ForEach(x => FontesReceita.Add(x));

        public void AtualizarFontesReceita(List<FonteReceita> lista)
        {
            FontesReceita.Clear();
            AddFontesReceita(lista);
        }

        public void AddSegmentoCliente(List<SegmentoCliente> lista) => lista.ForEach(x => SegmentosClientes.Add(x));

        public void AtualizarSegmentoCliente(List<SegmentoCliente> lista)
        {
            SegmentosClientes.Clear();
            AddSegmentoCliente(lista);
        }
    }
}
