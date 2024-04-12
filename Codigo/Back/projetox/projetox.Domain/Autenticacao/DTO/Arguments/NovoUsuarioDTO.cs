namespace projetox.Domain.Autenticacao.DTO.Arguments
{
    public struct NovoUsuarioDTO
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
