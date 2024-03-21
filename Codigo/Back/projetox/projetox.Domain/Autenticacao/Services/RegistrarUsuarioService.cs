using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Notification.DTO;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Services
{
    public class RegistrarUsuarioService : ServiceBase, IRegistrarUsuarioService
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public RegistrarUsuarioService(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public ResponseBaseDTO Registrar(NovoUsuarioDTO usuarioDTO)
        {           
            Nome nome = new (usuarioDTO.PrimeiroNome, usuarioDTO.Sobrenome);
            AddMensagens(nome);

            Documento documento = new (usuarioDTO.NumeroDocumento);
            AddMensagens(documento);

            Email email = new (usuarioDTO.Email);
            AddMensagens(email);

            Senha senha = new(usuarioDTO.Senha);
            AddMensagens(senha);

            Usuario usuario = new(nome, documento, email, senha, usuarioDTO.Telefone);
            AddMensagens(usuario);

            if(usuarioDTO.Senha != usuarioDTO.ConfirmacaoSenha)
            {
                AddMensagem(Mensagem.Error("As senhas estão divergentes."));
            }

            if (Valido())
            {
                _repositoryUsuario.Adicionar(usuario);

                AddMensagem(Mensagem.Info("Usuário cadastrado com sucesso !"));
            }

            return new ResponseBaseDTO()
            {
                Mensagens = GetMensagens().ToList().Select(x => (MensagemDTO)x).ToList(),
            };
        }
    }
}
