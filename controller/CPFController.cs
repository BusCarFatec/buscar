using System;
using System.Text.RegularExpressions;

namespace BusCar.Controller
{
    public class CPFController
    {
        public bool ValidateCpf(string cpf)
        {
            // Verifica se o CPF tem 11 dígitos e se todos os dígitos são iguais
            if (cpf.Length != 11 || Regex.IsMatch(cpf, @"(\d)\1{10}"))
            {
                Console.WriteLine("CPF inválido");
                return false;
            }

            int[] cpfArray = ConvertCpfToArray(cpf);

            if (IsCpf(1, cpfArray))
            {
                Console.WriteLine("É um CPF válido");
                return true;
            }
            else
            {
                Console.WriteLine("CPF não é válido");
                return false;
            }
        }

        public int[] ConvertCpfToArray(string cpf)
        {
            int[] cpfArray = new int[11];

            for (int i = 0; i < 11; i++)
            {
                cpfArray[i] = int.Parse(cpf[i].ToString());
            }

            return cpfArray;
        }

        public bool IsCpf(int tipo, int[] cpf)
        {
            int soma = 0;
            int resto;

            // Valida o primeiro dígito verificador
            for (int i = 0; i < 9; i++)
            {
                soma += cpf[i] * (10 - i);
            }

            resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            // Valida o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += cpf[i] * (11 - i);
            }

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            return (cpf[9] == digito1 && cpf[10] == digito2);
        }
    }
}
