using System;

namespace PeopleManager.Common
{
    public static class GenerateCpf
    {
        public static string Create()
        {
            Random random = new Random();
            int[] cpf = new int[11];

            // Generate 9 randomic digits
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = random.Next(0, 10);
            }

            // Calculate the first verify digit
            cpf[9] = CalculateCheckDigit(cpf, 9);

            // Calculate the second verify digit
            cpf[10] = CalculateCheckDigit(cpf, 10);

            // Format the CPF
            return string.Format("{0:000\\.000\\.000\\-00}", long.Parse(string.Join("", cpf)));
        }

        static int CalculateCheckDigit(int[] cpf, int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += cpf[i] * (size + 1 - i);
            }

            int rest = sum % 11;
            return rest < 2 ? 0 : 11 - rest;
        }

    }
}
