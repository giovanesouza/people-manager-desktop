using PeopleManager.Common;

namespace PeopleManagerTests.Tests.Common
{
    [TestClass]
    public class FormatDataTests
    {
        [TestMethod]
        public void FormatCpfMustFormatAndReturnValidValue()
        {
            // Arrange
            var cpf = "12345678901";
            var expected = "123.456.789-01";

            // Act
            var formattedCpf = FormatData.FormatCpf(cpf);

            // Assert
            Assert.AreEqual(expected, formattedCpf);
        }

        [TestMethod]
        public void FormatCpfValidCpfWithoutFormattingReturnsFormattedCpf()
        {
            // Arrange
            var cpf = "123.456.789-01"; // Properly formatted CPF
            var expected = "123.456.789-01"; // Expected formatted CPF

            // Act
            var formattedCpf = FormatData.FormatCpf(cpf);

            // Assert
            Assert.AreEqual(expected, formattedCpf);
        }

        [TestMethod]
        public void FormatCpfInvalidCpfLengthLessThan11ReturnsOriginalCpf()
        {
            // Arrange
            var cpf = "1234567890";
            var expected = "1234567890";

            // Act
            var formattedCpf = FormatData.FormatCpf(cpf);

            // Assert
            Assert.AreEqual(expected, formattedCpf);
        }

        [TestMethod]
        public void FormatCpfInvalidCpfLengthMoreThan11ReturnsOriginalCpf()
        {
            // Arrange
            var cpf = "123456789012";
            var expected = "123456789012";

            // Act
            var formattedCpf = FormatData.FormatCpf(cpf);

            // Assert
            Assert.AreEqual(expected, formattedCpf);
        }
    }
}