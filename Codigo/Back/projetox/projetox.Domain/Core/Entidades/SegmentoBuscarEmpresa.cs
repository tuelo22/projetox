using projetox.Domain.Base.Entidades;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Entidades
{
    public class SegmentoBuscarEmpresa : BaseEntity
    {
        public string Descricao { get; private set; }

        public virtual SegmentoCliente SegmentoCliente { get; private set; }

        public SegmentoBuscarEmpresa(){}

        public SegmentoBuscarEmpresa(string Descricao, SegmentoCliente SegmentoCliente)
        {
            this.Descricao = Descricao;

            if (String.IsNullOrEmpty(Descricao))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar a descrição do seguimento busca empresa."));
            }

            this.SegmentoCliente = SegmentoCliente;
        }
    }
}
