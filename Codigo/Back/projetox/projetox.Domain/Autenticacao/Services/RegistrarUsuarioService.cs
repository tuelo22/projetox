using projetox.Domain.Autenticacao.DTO.Arguments;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Autenticacao.Interfaces.Services;
using projetox.Domain.Autenticacao.ValueObjects;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.ValueObjects;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Autenticacao.Services
{
    public class RegistrarUsuarioService(IRepositoryUsuario repositoryUsuario) : ServiceBase, IRegistrarUsuarioService
    {
        public ResponseBaseDTO Registrar(NovoUsuarioDTO dto)
        {           
            Nome nome = new (dto.PrimeiroNome, dto.Sobrenome);
            AddMensagens(nome);

            Documento documento = new (dto.NumeroDocumento);
            AddMensagens(documento);

            Email email = new (dto.Email);
            AddMensagens(email);

            Senha senha = new(dto.Senha);
            AddMensagens(senha);

            Telefone telefone = new(dto.Telefone);
            AddMensagens(telefone);

            if(dto.Senha != dto.ConfirmacaoSenha)
            {
                AddMensagem(Mensagem.Error("As senhas estão divergentes."));
            }

            Usuario? usuario = repositoryUsuario.ObterPor(x => x.Email.Endereco.ToLower() == dto.Email.ToLower());

            if(usuario != null)
            {
                AddMensagem(Mensagem.Error("O e-mail informado já está sendo utiliado por outro usuário."));
            }

            usuario = repositoryUsuario.ObterPor(x => x.Documento.Numero.ToLower() == dto.NumeroDocumento.ToLower());

            if (usuario != null)
            {
                AddMensagem(Mensagem.Error("O documento informado já está sendo utiliado por outro usuário."));
            }

            if (Valido())
            {
                usuario = new(nome, documento, email, senha, telefone);
                AddMensagens(usuario);

                if (Valido())
                {
                    repositoryUsuario.Adicionar(usuario);

                    AddMensagem(Mensagem.Info("Usuário cadastrado com sucesso !"));
                }
            }

            return GetRetorno();
        }
    }
}
