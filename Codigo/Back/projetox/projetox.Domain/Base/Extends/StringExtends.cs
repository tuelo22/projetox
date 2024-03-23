using System.Text.RegularExpressions;

namespace projetox.Domain.Base.Extends
{
    public static partial class StringExtends
    {
        public static string RetornaApenasNumeros(this string input) => ApenasNumero().Replace(input, string.Empty);
        
        [GeneratedRegex("[^0-9]")]
        private static partial Regex ApenasNumero();
    }
}
