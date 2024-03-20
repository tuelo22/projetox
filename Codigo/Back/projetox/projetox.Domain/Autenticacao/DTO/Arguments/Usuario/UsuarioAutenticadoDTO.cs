namespace projetox.Domain.Autenticacao.DTO.Arguments.Usuario
{
    public struct UsuarioAutenticadoDTO
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
