using System.Text.RegularExpressions;

namespace PeopleManager.Common
{
    static class FormatData
    {
        public static string FormatCpf(string cpf)
        {
            cpf = Regex.Replace(cpf, @"\D", "");
            if (cpf.Length == 11)
                return Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");

            return cpf;
        }

    }
}
