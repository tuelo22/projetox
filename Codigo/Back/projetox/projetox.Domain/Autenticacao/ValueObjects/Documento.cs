﻿using projetox.Domain.Notification.Entidades;
using System.Text.RegularExpressions;

namespace projetox.Domain.Autenticacao.ValueObjects
{
    public class Documento : Notificavel
    {

        public String Numero { get; set; }

        public Documento()
        {
            Numero = String.Empty;
        }

        public Documento(String numero)
        {
            if (String.IsNullOrEmpty(numero))
            {
                Numero = String.Empty;
                AddMensagem(Mensagem.Error("É obrigatório informar o número do documento (CPF ou CNPJ)."));
            }
            else
            {
                Numero = RemoverCaracteresEspeciais(numero);

                if (Numero.Length == 11)
                {
                    if (!ValidarCPF(Numero))
                    {
                        AddMensagem(Mensagem.Error("CPF inválido, por favor verificar."));
                    }
                }
                else if (Numero.Length == 14)
                {
                    if (!ValidarCNPJ(Numero))
                    {
                        AddMensagem(Mensagem.Error("CNPJ inválido, por favor verificar."));
                    }
                }
            }

            if (!Valido())
            {
                AddMensagem(Mensagem.Error("Documento inválido, por favor verificar."));
            }
        }

        public override string ToString()
        {
            if (Numero.Length == 11)
            {
                return Convert.ToUInt64(Numero).ToString(@"000\.000\.000\-00");
            }

            if (Numero.Length == 14)
            {
                return Convert.ToUInt64(Numero).ToString(@"00\.000\.000\/0000\-00");
            }

            return string.Empty;
        }

        static string RemoverCaracteresEspeciais(string input) => new Regex("[^0-9]").Replace(input, string.Empty);

        static bool ValidarCPF(string cpf)
        {
            int[] multiplicadores1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicadores2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            string tempCpf = cpf[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        static bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicadores1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicadores2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            cnpj = cnpj.Trim().Replace(".", "").Replace("/", "").Replace("-", "");

            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj[..12];
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];

            int resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
