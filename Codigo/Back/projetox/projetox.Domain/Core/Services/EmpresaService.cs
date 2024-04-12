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
        INaturezaJuridicaRepository naturezaJuridicaRepository,
        IRedeSocialRepository redeSocialRepository) : ServiceBase, IEmpresaService
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

            var existe = empresaRepository.ListarPor(x => x.Documento.Numero == dto.Documento).ToList();

            if (existe.Any())
            {
                AddMensagem(Mensagem.Error("Empresa já cadastrada."));
            }

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
                    documento, naturezaJuridica, endereco, telefone,
                    dto.Abertura, dto.QuantidadeFuncionario, dto.Nome, dto.URLSite, dto.Objetivo);

                dto.RedesSociais.ForEach(x =>
                {
                    RedeSocial redeSocial = new(x.Nome, x.URLPerfil, empresa);
                    AddMensagens(redeSocial);

                    if (Valido())
                    {
                        empresa.AdicionarRedeSocial(redeSocial);
                        AddMensagem(Mensagem.Info("Empresa cadastrada com sucesso !"));
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

        public ListarEmpresaResponseDTO Listar(Guid IdUsuario)
        {
            var empresas = empresaRepository.Listar(empresa => empresa.Usuarios.Any(usuraio => usuraio.Id == IdUsuario)).ToList();
            var dto = empresas.Select(x => (EmpresaDTO)x).ToList();

            if (empresas.Count == 0)
            {
                AddMensagem(Mensagem.Info("O filtro informado não retornou dados."));
            }

            return new ListarEmpresaResponseDTO
            {
                Mensagens = GetMensagensDTO(),
                Empresas = dto
            };
        }

        public ResponseBaseDTO Atualizar(Guid IdUsuario, EmpresaDTO dto)
        {
            Empresa empresa = null;

            if (dto.Id != null)
            {
                empresa = empresaRepository.ObterPorId(dto.Id.Value);
            }

            if (empresa == null)
            {
                AddMensagem(Mensagem.Error("Empresa não localizada."));
            }
            else if (!empresa.Usuarios.Any(x => x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("Empresa não relacionado ao usuário."));
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

                List<RedeSocial> redeSocials = [];

                dto.RedesSociais.ForEach(x =>
                {
                    RedeSocial redeSocial = new(x.Nome, x.URLPerfil, empresa);
                    AddMensagens(redeSocial);

                    if (Valido())
                    {
                        redeSocials.Add(redeSocial);
                    }
                });

                AddMensagens(empresa);

                if (Valido())
                {
                    redeSocialRepository.RemoverLista(empresa.RedesSociais);
                    redeSocialRepository.AdicionarLista(redeSocials);

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

                AddMensagem(Mensagem.Info("Empresa deletada com sucesso !"));
            }

            return GetRetorno();
        }

    }
}
