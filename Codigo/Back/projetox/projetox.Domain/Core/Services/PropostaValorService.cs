using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Repositories;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Services
{
    public class PropostaValorService(
        IRepositoryUsuario repositoryUsuario,
        IEmpresaRepository empresaRepository,
        IPropostaValorRepository propostaValorRepository,
        ICanalDistribuicaoOpcaoRepository canalDistribuicaoOpcaoRepository) : ServiceBase, IPropostaValorService
    {
        public ResponseBaseDTO Atualizar(Guid IdUsuario, PropostaValorDTO dto)
        {
            Usuario usuario = repositoryUsuario.ObterPorId(IdUsuario);
            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }
            else if (!usuario.Empresas.Any(x => x.Id == dto.EmpresaId && x.PropostasValor.Any(y => y.Id == dto.Id)))
            {
                AddMensagem(Mensagem.Error("Proposta de valor não relacionado ao usuário."));
            }

            Empresa empresa = empresaRepository.ObterPorId(dto.EmpresaId);
            if (empresa == null)
            {
                AddMensagem(Mensagem.Error("Empresa não localizada."));
            }

            PropostaValor? proposta = null;

            if(dto.Id != null)
            {
                proposta = propostaValorRepository.ObterPorId(dto.Id.Value);
            }

            if (proposta == null)
            {
                AddMensagem(Mensagem.Error("Proposta de valor não localizada."));
            }

            if (Valido() && proposta != null)
            {
                proposta.AtualizarDescricaoNegocio(dto.DescricaoNegocio);
                proposta.AtualizarFazerNegocio(dto.FazerNegocio);

                List<FonteReceita> fonteReceitas = [];
                dto.FontesReceita.ForEach(x =>
                {
                    FonteReceita fonte = new(x.Descricao, proposta);
                    AddMensagens(fonte);
                    fonteReceitas.Add(fonte);
                });

                proposta.AtualizarFontesReceita(fonteReceitas);

                List<CanalDistribuicaoOpcao> canais = [];
                dto.CanaisDistribuicaoOpcao.ForEach(x =>
                {
                    CanalDistribuicaoOpcao? fonte = null;

                    if(x.Id != null)
                    {
                        fonte = canalDistribuicaoOpcaoRepository.ObterPorId(x.Id.Value);
                    }

                    if (fonte == null)
                    {
                        AddMensagem(Mensagem.Error("Opção de canal de distribuição {x.Id} não localizado."));
                    }
                    else
                    {
                        canais.Add(fonte);
                    }
                });

                proposta.AtualizarCanalDistribuicaoOpcoes(canais);

                List<RelacionamentoCliente> relacionamentos = [];
                dto.RelacionamentoClientes.ForEach(x =>
                {
                    RelacionamentoCliente fonte = new(x.Descricao, proposta);
                    AddMensagens(fonte);
                    relacionamentos.Add(fonte);
                });

                proposta.AtualizarRelacionamentoCliente(relacionamentos);

                AddMensagens(proposta);

                if (Valido())
                {
                    propostaValorRepository.Editar(proposta);
                    AddMensagem(Mensagem.Info("Proposta de valor alterada com sucesso !"));
                }
            }

            return GetRetorno();
        }

        public ResponseBaseDTO Cadastrar(Guid IdUsuario, PropostaValorDTO dto)
        {
            Usuario? usuario = repositoryUsuario.ObterPorId(IdUsuario);

            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }

            Empresa? empresa = empresaRepository.ObterPorId(dto.EmpresaId);

            if (empresa == null)
            {
                AddMensagem(Mensagem.Error("Empresa não localizada."));
            }

            if (Valido() && usuario != null && empresa != null)
            {
                PropostaValor proposta = new PropostaValor(dto.DescricaoNegocio, dto.FazerNegocio, empresa);

                dto.FontesReceita.ForEach(x =>
                {
                    FonteReceita fonte = new(x.Descricao, proposta);
                    AddMensagens(fonte);
                    proposta.AddFontesReceita(fonte);
                });

                dto.CanaisDistribuicaoOpcao.ForEach(x =>
                {
                    CanalDistribuicaoOpcao? fonte = null;

                    if(x.Id != null)
                    {
                        fonte = canalDistribuicaoOpcaoRepository.ObterPorId(x.Id.Value);
                    }

                    if (fonte == null)
                    {
                        AddMensagem(Mensagem.Error($"Opção de canal de distribuição {x.Id} não localizado."));
                    }
                    else
                    {
                        proposta.AddCanalDistribuicaoOpcoes(fonte);
                    }
                });

                dto.RelacionamentoClientes.ForEach(x =>
                {
                    RelacionamentoCliente fonte = new(x.Descricao, proposta);
                    AddMensagens(fonte);
                    proposta.AddRelacionamentoCliente(fonte);
                });

                AddMensagens(proposta);

                if (Valido())
                {
                    propostaValorRepository.Adicionar(proposta);
                    AddMensagem(Mensagem.Info("Proposta de valor cadastrada com sucesso !"));
                }
            }

            return GetRetorno();
        }

        public ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdProposta)
        {
            Usuario usuario = repositoryUsuario.ObterPorId(IdUsuario);
            if (usuario == null)
            {
                AddMensagem(Mensagem.Error("Usuario não localizado."));
            }

            PropostaValor propostaValor = propostaValorRepository.ObterPorId(IdProposta);

            if (propostaValor == null)
            {
                AddMensagem(Mensagem.Error("Proposta de valor não localizada."));
            }
            else if(!propostaValor.Empresa.Usuarios.Any(x=> x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("A Proposta de valor não pertence a uma empresa relacionada ao usuário."));
            }

            if(Valido() && propostaValor != null)
            {
                propostaValorRepository.Remover(propostaValor);
             
                AddMensagem(Mensagem.Info("Proposta de valor deletada com sucesso !"));
            }

            return GetRetorno();
        }

        public ListarPropostaValorResponseDTO Listar(Guid IdUsuario, Guid IdEmpresa)
        {
            var propostas = propostaValorRepository
                .Listar(x => x.Empresa.Usuarios.Any(usuario => usuario.Id == IdUsuario) && x.Empresa.Id == IdEmpresa)
                .ToList();

            var dto = propostas.Select(x => (PropostaValorDTO)x).ToList();

            if (propostas.Count == 0)
            {
                AddMensagem(Mensagem.Info("O filtro informado não retornou dados."));
            }

            return new ListarPropostaValorResponseDTO
            {
                Mensagens = GetMensagensDTO(),
                PropostasValor = dto
            };
        }
    }
}
