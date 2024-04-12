namespace projetox.Domain.Autenticacao.DTO
{
    /// <summary>
    /// Dados de login
    /// </summary>
    public struct LoginDTO
    {
        /// <summary>
        /// Email do usuário.
        /// </summary>
        /// <example>email@email.com</example>
        public string Login { get; set; }

        /// <summary>
        /// Senha de acesso.
        /// </summary>
        /// <example>*Abc1234</example>
        public string Senha { get; set; }
    }
}
