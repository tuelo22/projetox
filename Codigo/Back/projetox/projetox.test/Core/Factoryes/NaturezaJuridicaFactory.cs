using projetox.Domain.Core.Entidades;

namespace projetox.test.Core.Factoryes
{
    public static class NaturezaJuridicaFactory
    {
        public static NaturezaJuridica CriarNaturezaJuridicaPadrao()
        {
            return new("MEI");
        }
    }
}
