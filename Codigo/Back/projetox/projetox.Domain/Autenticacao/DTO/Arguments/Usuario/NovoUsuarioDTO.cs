﻿namespace projetox.Domain.Autenticacao.DTO.Arguments.Usuario
{
    public struct NovoUsuarioDTO
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}
