﻿using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Base.Entidades;
using projetox.Domain.Base.ValueObjects;
using projetox.Domain.Core.ValueObjects;
using projetox.Domain.Notification.Entidades;
using System;

namespace projetox.Domain.Core.Entidades
{
    public class Empresa : BaseEntity
    {
        public Empresa(
            Guid? id,
            Documento documento,
            NaturezaJuridica naturezaJuridica, Endereco endereco,
            Telefone telefone, DateTime abertura,
            int quantidadeFuncionario, string nome, string? uRLSite)
        {
            Id = id ?? Guid.NewGuid();
            Documento = documento;
            NaturezaJuridica = naturezaJuridica;
            Telefone = telefone;
            URLSite = uRLSite;
            Endereco = endereco;
            Nome = nome;

            SetNome(nome);
            SetDataAbertura(abertura);
            SetQuantidadeFuncionario(quantidadeFuncionario);
        }

        public Documento Documento { get; private set; }
        public virtual NaturezaJuridica NaturezaJuridica { get; private set; }
        public Endereco Endereco { get; private set; }
        public Telefone Telefone { get; private set; }
        public DateTime Abertura { get; private set; }
        public Int32 QuantidadeFuncionario { get; private set; }
        public String Nome { get; private set; }
        public String? URLSite { get; private set; }
        public ICollection<RedeSocial> RedesSociais { get; } = new List<RedeSocial>();
        public ICollection<Usuario> Usuarios { get; } = new List<Usuario>();

        private void SetNome(String nome)
        {
            this.Nome = nome;
            if (String.IsNullOrEmpty(this.Nome))
            {
                AddMensagem(Mensagem.Error("É obrigatório informar o nome da empresa."));
            }
        }

        private void SetQuantidadeFuncionario(int quantidadeFuncionario)
        {
            this.QuantidadeFuncionario = quantidadeFuncionario;
            if (this.QuantidadeFuncionario < 0)
            {
                AddMensagem(Mensagem.Error("A quantidade de funcionarios não deve ser menor que zero."));
            }
        }

        private void SetDataAbertura(DateTime abertura)
        {
            Abertura = abertura;

            if (Abertura == DateTime.MinValue)
            {
                AddMensagem(Mensagem.Error("Data de abertura invalida."));
            }
            else if (Abertura > DateTime.Now)
            {
                AddMensagem(Mensagem.Error("A data de abertura não pode ser superior a data atual."));
            }
        }

        public void AdicionarRedeSocial(RedeSocial redeSocial)
        {
            this.RedesSociais.Add(redeSocial);
        }

        public void RemoverRedeSocial(RedeSocial redeSocial)
        {
            this.RedesSociais.Remove(redeSocial);
        }

        public void LimparRedesSociais()
        {
            this.RedesSociais.Clear();
        }

        public void RemoverUsuario(Usuario usuario)
        {
            if (!this.Usuarios.Any(x => x.Id == usuario.Id))
            {
                AddMensagem(Mensagem.Error("Usuário não relacionado a empresa."));
            }
            else
            {
                Usuarios.Remove(usuario);
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            if (this.Usuarios.Any(x => x.Id == usuario.Id))
            {
                AddMensagem(Mensagem.Error("Usuário já relacionado a empresa."));
            }
            else
            {
                Usuarios.Add(usuario);
            }
        }

        public void AtualizarNaturezaJuridica(NaturezaJuridica naturezaJuridica) => this.NaturezaJuridica = naturezaJuridica;
        public void AtualizarEndereco(Endereco endereco) => this.Endereco = endereco;
        public void AtualizarTelefone(Telefone telefone) => this.Telefone = telefone;
        public void AtualizarDocumento(Documento documento) => this.Documento = documento;
        public void AtualizaDataAbertura(DateTime abertura) => SetDataAbertura(abertura);
        public void AtualizaQuantidadeFuncionario(int quantidadeFuncionario) => SetQuantidadeFuncionario(quantidadeFuncionario);
        public void AtualizarNome(String nome) => SetNome(nome);
    }
}
