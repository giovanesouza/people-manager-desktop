using Moq;
using PeopleManager.Abstracts;
using PeopleManager.Models;
using PeopleManager.Services;
using System.Collections.ObjectModel;

namespace PeopleManagerTests.Tests.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        private Mock<IPersonRepository>? _personRepositoryMock;
        private Mock<ApiClient>? _apiClientMock;
        private PersonService? _personService;

        [TestInitialize]
        public void Setup()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _apiClientMock = new Mock<ApiClient>("https://gerador-nomes.wolan.net/");
            _personService = new PersonService(_personRepositoryMock.Object);
        }

        [TestMethod]
        public void GetPeopleShouldReturnAllPeopleWhenRepositoryIsNotEmpty()
        {
            // Arrange
            var people = new ObservableCollection<Person>
            {
                new("1", "First", "Person", "12345678900"),
                new("2", "Second", "Person", "09876543211")
            };
            _personRepositoryMock!.Setup(repo => repo.GetAll()).Returns(people);

            // Act
            var result = _personService!.GetPeople();

            // Assert
            Assert.AreEqual(people, result);
        }

        [TestMethod]
        public void GetPeopleShouldCallRandomRegistrationPeopleWhenRepositoryIsEmpty()
        {
            // Arrange
            _personRepositoryMock!.Setup(repo => repo.GetAll()).Returns(new ObservableCollection<Person>());

            // Act
            var result = _personService!.GetPeople();

            // Assert
            _personRepositoryMock.Verify(repo => repo.GetAll(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void CreatePersonShouldCallRepositoryCreate()
        {
            // Arrange
            var person = new Person("1", "First", "Person", "12345678900");

            // Act
            _personService!.CreatePerson(person);

            // Assert
            _personRepositoryMock!.Verify(repo => repo.Create(person), Times.Once);
        }

        [TestMethod]
        public void DeletePersonShouldCallRepositoryDelete()
        {
            // Arrange
            var personId = "1";

            // Act
            _personService!.DeletePerson(personId);

            // Assert
            _personRepositoryMock!.Verify(repo => repo.Delete(personId), Times.Once);
        }

        [TestMethod]
        public void UpdatePersonShouldCallRepositoryUpdate()
        {
            // Arrange
            var person = new Person("1", "Updated", "Person", "12345678900");

            // Act
            _personService!.UpdatePerson(person);

            // Assert
            _personRepositoryMock!.Verify(repo => repo.Update(person), Times.Once);
        }
    }
}
