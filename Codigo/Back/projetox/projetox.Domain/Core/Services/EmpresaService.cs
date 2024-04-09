using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Core.ValueObjects;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Services
{
    public class EmpresaService(
        IRepositoryUsuario repositoryUsuario,
        IEmpresaRepository empresaRepository,
        INaturezaJuridicaRepository naturezaJuridicaRepository) : ServiceBase, IEmpresaService
    {
        public ResponseBaseDTO Cadastrar(Guid IdUsuario, EmpresaDTO dto)
        {
            Usuario? usuario = repositoryUsuario.ObterPorId(IdUsuario);

            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }

            Documento documento = new(dto.Documento);
            AddMensagens(documento);

            NaturezaJuridica? naturezaJuridica = naturezaJuridicaRepository.ObterPorId(dto.NaturezaJuridicaId);

            if (naturezaJuridica == null)
            {
                AddMensagem(Mensagem.Error("Natureza jurídica não localizada."));
            }

            Endereco endereco = new(
                dto.Endereco.Logradouro, dto.Endereco.Numero, dto.Endereco.Complemento,
                dto.Endereco.Bairro, dto.Endereco.Cidade, dto.Endereco.Estado, dto.Endereco.CEP,
                dto.Endereco.CodIBGE);
            AddMensagens(endereco);

            Telefone telefone = new(dto.Telefone);
            AddMensagens(telefone);

            if (Valido() && naturezaJuridica != null && usuario != null)
            {
                Empresa empresa = new(
                    Guid.NewGuid(),
                    documento, naturezaJuridica, endereco, telefone,
                    dto.Abertura, dto.QuantidadeFuncionario, dto.Nome, dto.URLSite);

                dto.RedesSociais.ForEach(x =>
                {
                    RedeSocial redeSocial = new(Guid.NewGuid(), x.Nome, x.URLPerfil, empresa);
                    AddMensagens(redeSocial);

                    if (Valido())
                    {
                        empresa.AdicionarRedeSocial(redeSocial);
                    }
                });

                AddMensagens(empresa);

                if (Valido())
                {
                    empresa.AdicionarUsuario(usuario);

                    empresaRepository.Adicionar(empresa);
                }
            }

            return GetRetorno();
        }

        public ObterEmpresaPorUsuarioResponseDTO Listar(Guid IdUsuario)
        {
            var empresas = empresaRepository.Listar(empresa => empresa.Usuarios.Any(usuraio => usuraio.Id == IdUsuario)).ToList();
            var dto = empresas.Select(x => (EmpresaDTO)x).ToList();

            if (empresas.Count == 0)
            {
                AddMensagem(Mensagem.Info("O filtro informado não retornou dados."));
            }

            return new ObterEmpresaPorUsuarioResponseDTO
            {
                Mensagens = GetMensagensDTO(),
                Empresas = dto
            };
        }

        public ResponseBaseDTO Atualizar(Guid IdUsuario, EmpresaDTO dto)
        {
            Usuario usuario = repositoryUsuario.ObterPorId(IdUsuario);
            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }
            else if (!usuario.Empresas.Any(x => x.Id == dto.Id))
            {
                AddMensagem(Mensagem.Error("Empresa não relacionado ao usuário."));
            }

            Empresa empresa = empresaRepository.ObterPorId(dto.Id);
            if (empresa == null)
            {
                AddMensagem(Mensagem.Error("Empresa não localizada."));
            }

            Documento documento = new(dto.Documento);
            AddMensagens(documento);

            NaturezaJuridica? naturezaJuridica = naturezaJuridicaRepository.ObterPorId(dto.NaturezaJuridicaId);

            if (naturezaJuridica == null)
            {
                AddMensagem(Mensagem.Error("Natureza jurídica não localizada."));
            }

            Endereco endereco = new(dto.Endereco.Logradouro, dto.Endereco.Numero, dto.Endereco.Complemento,
                dto.Endereco.Bairro, dto.Endereco.Cidade, dto.Endereco.Estado, dto.Endereco.CEP, dto.Endereco.CodIBGE);

            AddMensagens(endereco);

            Telefone telefone = new(dto.Telefone);
            AddMensagens(telefone);

            if (Valido() && naturezaJuridica != null && empresa != null)
            {
                empresa.AtualizarNaturezaJuridica(naturezaJuridica);
                empresa.AtualizarEndereco(endereco);
                empresa.AtualizarTelefone(telefone);
                empresa.AtualizarDocumento(documento);
                empresa.AtualizaDataAbertura(dto.Abertura);
                empresa.AtualizaQuantidadeFuncionario(dto.QuantidadeFuncionario);
                empresa.AtualizarNome(dto.Nome);
                empresa.LimparRedesSociais();

                dto.RedesSociais.ForEach(x =>
                {
                    RedeSocial redeSocial = new(Guid.NewGuid(), x.Nome, x.URLPerfil, empresa);
                    AddMensagens(redeSocial);

                    if (Valido())
                    {
                        empresa.AdicionarRedeSocial(redeSocial);
                    }
                });

                AddMensagens(empresa);

                if (Valido())
                {
                    empresaRepository.Editar(empresa);

                    AddMensagem(Mensagem.Info("Empresa atualizada com sucesso !"));
                }
            }

            return GetRetorno();
        }

        public ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdEmpresa)
        {
            Usuario usuario = repositoryUsuario.ObterPorId(IdUsuario);
            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }

            Empresa empresa = empresaRepository.ObterPorId(IdEmpresa);
            if (empresa == null)
            {
                AddMensagem(Mensagem.Error("Empresa não localizada."));
            }
            else if (!empresa.Usuarios.Any(x => x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("Empresa não relacionada ao usuário informado."));
            }

            if (Valido() && empresa != null && usuario != null)
            {
                if(empresa.Usuarios.Count >= 2)
                {
                    empresa.RemoverUsuario(usuario);
                    empresaRepository.Editar(empresa);
                }
                else
                {
                    empresaRepository.Remover(empresa);
                }

                AddMensagem(Mensagem.Error("Empresa deletada com sucesso !"));
            }

            return GetRetorno();
        }

    }
}
