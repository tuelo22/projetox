using projetox.Domain.Core.ValueObjects;

namespace projetox.Domain.Core.DTO
{
    public class EmpresaDTO
    {
        public Guid UsuarioId { get; set; }
        public string Documento { get; set; }
        public Guid NaturezaJuridicaId { get; set; }
        public DateTime Abertura { get; set; }
        public Int32 QuantidadeFuncionario { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String URLSite { get; set; }
        public Endereco Endereco { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; } = [];
    }
}
