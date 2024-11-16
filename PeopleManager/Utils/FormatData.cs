using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleManager.Utils
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
