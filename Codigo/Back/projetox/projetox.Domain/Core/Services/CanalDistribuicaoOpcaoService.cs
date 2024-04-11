﻿using projetox.Domain.Base.Service;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Interfaces.Repositories;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Core.Services
{
    public class CanalDistribuicaoOpcaoService(ICanalDistribuicaoOpcaoRepository _CanalDistribuicaoOpcaoRepository) : ServiceBase, ICanalDistribuicaoOpcaoService
    {
        public ListarCanalDistribuicaoOpcaoDTO ListarTodos()
        {
            var lista = _CanalDistribuicaoOpcaoRepository.Listar().ToList();

            var listaDTO = lista.Select(x => (CanalDistribuicaoOpcaoDTO)x).ToList();

            if(listaDTO.Count == 0)
            {
                AddMensagem(Mensagem.Info("Não foram encontratos dados para a busca informada."));
            }

            return new()
            {
                Mensagens = GetMensagensDTO(),
                CanaisDistribuicaoOpcao = listaDTO
            };
        }
    }
}
