using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.ValueObjects;
using projetox.test.Autenticacao.Factoryes;

namespace projetox.test.Core.Factoryes
{
    public static class EmpresaFactory
    {
        public static Empresa CriarEmpresaPadrao()
        {
            Documento documento = new("234.908.170-28");

            NaturezaJuridica naturezaJuridica = NaturezaJuridicaFactory.CriarNaturezaJuridicaPadrao();

            Endereco endereco = new(
                "Rua simples", "555", "Apt 200",
                "Jardim Felicidade", "Marica", "Rio de Janeiro", "24914000",
                "987986798");

            Telefone telefone = new("21991902197");

            return new(Guid.NewGuid(),
                    documento, naturezaJuridica, endereco, telefone,
                    DateTime.Parse("24/11/1990"), 5, "JF Software", null);
        }

        public static Empresa CriarEmpresaComUsuarioPadrao()
        {
            Documento documento = new("234.908.170-28");

            NaturezaJuridica naturezaJuridica = NaturezaJuridicaFactory.CriarNaturezaJuridicaPadrao();

            Endereco endereco = new(
                "Rua simples", "555", "Apt 200",
                "Jardim Felicidade", "Marica", "Rio de Janeiro", "24914000",
                "987986798");

            Telefone telefone = new("21991902197");

            Empresa empresa = new(Guid.NewGuid(),
                    documento, naturezaJuridica, endereco, telefone,
                    DateTime.Parse("24/11/1990"), 5, "JF Software", null);

            empresa.AdicionarUsuario(UsuarioFactory.CriarUsuarioPadrao());

            return empresa;
        }
    }
}
