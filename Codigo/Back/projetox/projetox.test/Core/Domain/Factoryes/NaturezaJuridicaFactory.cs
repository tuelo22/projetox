using projetox.Domain.Core.Entidades;

namespace projetox.test.Core.Domain.Factoryes
{
    public static class NaturezaJuridicaFactory
    {
        public static NaturezaJuridica CriarNaturezaJuridicaPadrao()
        {
            return new(Guid.NewGuid(), "MEI");
        }
    }
}
