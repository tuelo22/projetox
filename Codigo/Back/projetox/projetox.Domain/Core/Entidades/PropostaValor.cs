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
            Empresa = empresa;

            SetDescricaoNegocio(descricaoNegocio);
            SetFazerNegocio(fazerNegocio);
        }

        private void SetFazerNegocio(String fazerNegocio)
        {
            FazerNegocio = fazerNegocio;

            if (String.IsNullOrEmpty(FazerNegocio))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição fazer negócio."));
            }
        }

        private void SetDescricaoNegocio(String descricaoNegocio)
        {
            DescricaoNegocio = descricaoNegocio;

            if (String.IsNullOrEmpty(DescricaoNegocio))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição de negócio."));
            }
        }

        public void AtualizarDescricaoNegocio(string descricaoNegocio) => SetDescricaoNegocio(descricaoNegocio);
        public void AtualizarFazerNegocio(string fazerNegocio) => SetFazerNegocio(fazerNegocio);

        public void AddRelacionamentoCliente(List<RelacionamentoCliente> lista) => lista.ForEach(x => RelacionamentoClientes.Add(x));
        public void AddRelacionamentoCliente(RelacionamentoCliente item) => RelacionamentoClientes.Add(item);
        public void AtualizarRelacionamentoCliente(List<RelacionamentoCliente> lista)
        {
            var opcoes = RelacionamentoClientes.ToList();
            opcoes.ForEach(x => RelacionamentoClientes.Remove(x));

            AddRelacionamentoCliente(lista);
        }

        public void AddCanalDistribuicaoOpcoes(List<CanalDistribuicaoOpcao> lista) => lista.ForEach(x => CanalDistribuicaoOpcoes.Add(x));
        public void AddCanalDistribuicaoOpcoes(CanalDistribuicaoOpcao item) => CanalDistribuicaoOpcoes.Add(item);
        public void AtualizarCanalDistribuicaoOpcoes(List<CanalDistribuicaoOpcao> lista)
        {
            var opcoes = CanalDistribuicaoOpcoes.ToList();
            opcoes.ForEach(x => CanalDistribuicaoOpcoes.Remove(x));

            AddCanalDistribuicaoOpcoes(lista);
        }

        public void AddFontesReceita(List<FonteReceita> lista) => lista.ForEach(x => FontesReceita.Add(x));
        public void AddFontesReceita(FonteReceita item) => FontesReceita.Add(item);
        public void AtualizarFontesReceita(List<FonteReceita> lista)
        {
            var opcoes = FontesReceita.ToList();
            opcoes.ForEach(x => FontesReceita.Remove(x));
            AddFontesReceita(lista);
        }
    }
}
