using projetox.Domain.Autenticacao.Entidades;

namespace projetox.Domain.Autenticacao.DTO.Arguments
{
    /// <summary>
    /// Entidade passada no token gerado no login.
    /// </summary>
    public struct UsuarioAutenticadoDTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Primeiro nome.
        /// </summary>
        public string PrimeiroNome { get; set; }
        /// <summary>
        /// Sobrenome.
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Número de documento.
        /// </summary>
        public string NumeroDocumento { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telefone.
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Conversão da entidade principal par ao DTO.
        /// </summary>
        /// <param name="entidade"></param>
        public static explicit operator UsuarioAutenticadoDTO(Usuario entidade)
        {
            return new UsuarioAutenticadoDTO()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Sobrenome = entidade.Nome.Sobrenome,
                NumeroDocumento = entidade.Documento.Numero,
                Email = entidade.Email.Endereco,
                Telefone = entidade.Telefone.Numero
            };
        }
    }
}
