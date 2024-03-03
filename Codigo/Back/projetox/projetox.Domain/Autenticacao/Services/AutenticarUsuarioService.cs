using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repository;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Services
{
    public class AutenticarUsuarioService : Notificavel, IAutenticarUsuarioService
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AutenticarUsuarioService(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }
        public Usuario? Autenticar(string emial, string senha)
        {
            Senha senhacriptografada = new(senha);

           var usuario = _repositoryUsuario.ListarPor(x => x.Email.Endereco == emial && x.Senha.Valor == senhacriptografada.Valor).FirstOrDefault();

            if(usuario == null)
            {               
                AddMensagem(Mensagem.Error("Dados incorretos."));

                return null;
            }

            return usuario;
        }
    }
}
