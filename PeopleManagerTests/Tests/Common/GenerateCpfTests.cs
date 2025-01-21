using PeopleManager.Common;
using System.Text.RegularExpressions;

namespace PeopleManagerTests.Tests.Common
{
    [TestClass]
    public class GenerateCpfTests
    {
        [TestMethod]
        public void GenerateCpfMustCreateAndReturnValidCpf()
        {
            // Arrange
            var cpfList = new List<string>();

            // Act
            for (int i = 0; i < 5; i++) cpfList.Add(GenerateCpf.Create());

            // Assert
            foreach (var cpf in cpfList)
            {
                Assert.IsTrue(IsValidCpf(cpf), $"Generated CPF '{cpf}' is not valid.");
                Assert.IsTrue(cpf.Length == 14, "Generated CPF length is incorrect.");
            }
        }

        private bool IsValidCpf(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        }
    }
}
