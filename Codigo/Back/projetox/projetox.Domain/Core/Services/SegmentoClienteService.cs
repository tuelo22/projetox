using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Service;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Entidades;
using projetox.Domain.Core.Enumerados;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Services
{
    public class SegmentoClienteService(
        IPropostaValorRepository propostaValorRepository,
        ISegmentoClienteRepository segmentoClienteRepository,
        ISegmentoAjudarPessoaRepository segmentoAjudarPessoaRepository,
        ISegmentoBuscarEmpresaRepository segmentoBuscarEmpresaRepository,
        ISegmentoReclamacaoAtendimentoRepository segmentoReclamacaoAtendimentoRepository) : ServiceBase, ISegmentoClienteService
    {
        public ResponseBaseDTO Atualizar(Guid IdUsuario, SegmentoClienteDTO dto)
        {
            SegmentoCliente segmento = null;
            if (dto.Id != null)
            {
                segmento = segmentoClienteRepository.ObterPorId(dto.Id.Value);
            }             

            if (segmento == null)
            {
                AddMensagem(Mensagem.Error("Segmento do cliente não localizada."));
            }
            else if(!segmento.PropostaValor.Empresa.Usuarios.Any(x => x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("Empresa da proposta de valor não relacionada ao usuário."));
            }

            bool Sucesso = Enum.TryParse<ClienteDispostoPagar>(dto.ClienteDispostoPagar, out var opcao);

            if (!Sucesso)
            {
                AddMensagem(Mensagem.Error("O enumerado ClienteDispostoPagar está com um valor invalido."));
            }

            if (Valido() && segmento != null)
            {
                List<SegmentoAjudarPessoa> segmentoAjudarPessoas = [];
                dto.SegmentoAjudarPessoas.ForEach(x =>
                {
                    SegmentoAjudarPessoa fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmentoAjudarPessoas.Add(fonte);
                });

                List<SegmentoBuscarEmpresa> segmentoBuscarEmpresas = [];
                dto.SegmentoBuscarEmpresas.ForEach(x =>
                {
                    SegmentoBuscarEmpresa fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmentoBuscarEmpresas.Add(fonte);
                });

                List<SegmentoReclamacaoAtendimento> segmentoReclamacaoAtendimentos = [];
                dto.SegmentoReclamacaoAtendimentos.ForEach(x =>
                {
                    SegmentoReclamacaoAtendimento fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmentoReclamacaoAtendimentos.Add(fonte);
                });

                segmento.AtualizarAjudar(dto.Ajudar);
                segmento.AtualizarBuscarProduto(dto.BuscarProduto);
                segmento.AtualizarServindoPessoa(dto.ServindoPessoa);
                segmento.AtualizaValor(dto.Valor);
                segmento.AtualizaClienteDispostoPagar(opcao);
                
                ValidaListas(segmento);
                AddMensagens(segmento);

                if (Valido())
                {
                    segmentoClienteRepository.Editar(segmento);

                    segmentoAjudarPessoaRepository.RemoverLista(segmento.SegmentoAjudarPessoas);
                    segmentoAjudarPessoaRepository.AdicionarLista(segmentoAjudarPessoas);
                    segmentoBuscarEmpresaRepository.RemoverLista(segmento.SegmentoBuscarEmpresas);
                    segmentoBuscarEmpresaRepository.AdicionarLista(segmentoBuscarEmpresas);
                    segmentoReclamacaoAtendimentoRepository.RemoverLista(segmento.SegmentoReclamacaoAtendimentos);
                    segmentoReclamacaoAtendimentoRepository.AdicionarLista(segmentoReclamacaoAtendimentos);

                    AddMensagem(Mensagem.Info("Segmento do cliente alterado com sucesso !"));
                }
            }

            return GetRetorno();
        }

        public ResponseBaseDTO Cadastrar(Guid IdUsuario, SegmentoClienteDTO dto)
        {
            PropostaValor proposta = propostaValorRepository.ObterPorId(dto.PropostaValorId);

            if (proposta == null)
            {
                AddMensagem(Mensagem.Error("Proposta de valor não localizada."));
            }
            else if (!proposta.Empresa.Usuarios.Any(x => x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("Empresa da proposta de valor não relacionada ao usuário."));
            }

            bool Sucesso = Enum.TryParse<ClienteDispostoPagar>(dto.ClienteDispostoPagar, out var opcao);

            if (!Sucesso)
            {
                AddMensagem(Mensagem.Error("O enumerado ClienteDispostoPagar está com um valor invalido."));
            }

            if (Valido() && proposta != null)
            {
                SegmentoCliente segmento = new(dto.Ajudar, dto.BuscarProduto, dto.ServindoPessoa, opcao, dto.Valor, proposta);

                dto.SegmentoAjudarPessoas.ForEach(x =>
                {
                    SegmentoAjudarPessoa fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmento.AddSegmentoAjudarPessoa(fonte);
                });

                dto.SegmentoBuscarEmpresas.ForEach(x =>
                {
                    SegmentoBuscarEmpresa fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmento.AddSegmentoBuscarEmpresa(fonte);
                });

                dto.SegmentoReclamacaoAtendimentos.ForEach(x =>
                {
                    SegmentoReclamacaoAtendimento fonte = new(x.Descricao, segmento);
                    AddMensagens(fonte);
                    segmento.AddSegmentoReclamacaoAtendimento(fonte);
                });
                
                ValidaListas(segmento);

                AddMensagens(segmento);

                if (Valido())
                {
                    segmentoClienteRepository.Adicionar(segmento);
                    AddMensagem(Mensagem.Info("Segmento do cliente cadastrado com sucesso !"));
                }
            }

            return GetRetorno();
        }

        private void ValidaListas(SegmentoCliente segmento)
        {
            if(segmento.SegmentoAjudarPessoas.Count == 0)
            {
                AddMensagem(Mensagem.Error("O segmento do cliente deve possuir ao menos um segmento ajudar pessoas."));
            }

            if (segmento.SegmentoBuscarEmpresas.Count == 0)
            {
                AddMensagem(Mensagem.Error("O segmento do cliente deve possuir ao menos um segmento buscar empresas."));
            }

            if (segmento.SegmentoReclamacaoAtendimentos.Count == 0)
            {
                AddMensagem(Mensagem.Error("O segmento do cliente deve possuir ao menos um segmento reclamação e atendimentos."));
            }
        }

        public ResponseBaseDTO Deletar(Guid IdUsuario, Guid IdSegmentoCliente)
        {
            SegmentoCliente segmento = segmentoClienteRepository.ObterPorId(IdSegmentoCliente);

            if (segmento == null)
            {
                AddMensagem(Mensagem.Error("Segmento do cliente não localizada."));
            }
            else if (segmento.PropostaValor.Empresa.Usuarios.Any(x => x.Id == IdUsuario))
            {
                AddMensagem(Mensagem.Error("Empresa da proposta de valor não relacionada ao usuário."));
            }

            if(Valido() && segmento != null)
            {
                segmentoClienteRepository.Editar(segmento);
                AddMensagem(Mensagem.Info("Segmento do cliente deletado com sucesso !"));
            }

            return GetRetorno();
        }

        public ListarSegmentoClienteResponseDTO Listar(Guid IdUsuario, Guid IdPropostaValor)
        {
            var segmentos = segmentoClienteRepository
                .Listar(x=> x.PropostaValor.Id == IdPropostaValor && x.PropostaValor.Empresa.Usuarios.Any(y => y.Id == IdUsuario))
                .ToList();

            var dto = segmentos.Select(x => (SegmentoClienteDTO)x).ToList();

            if (segmentos.Count == 0)
            {
                AddMensagem(Mensagem.Info("O filtro informado não retornou dados."));
            }

            return new ListarSegmentoClienteResponseDTO
            {
                Mensagens = GetMensagensDTO(),
                SegmentosClientes = dto
            };
        }
    }
}
