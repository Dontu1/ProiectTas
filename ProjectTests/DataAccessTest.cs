using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary;
using ProjectLibrary.Models;
using Moq;

namespace ProjectTests
{
    public class DataAccessTest
    {
        [Test]
        [TestCase("", "Popescu", 1)]
        [TestCase("Alice", "Bisioc", 1)]
        [TestCase("Andrei", "Dontu", 1)]
        public void AddNewPerson_Test(string firstName, string lastName, int expectedCount)
        {
            // Arrange
            IDataAccess stubDataAccess = new StubDataAccess();
            PersonModel testPerson = new PersonModel { FirstName = firstName, LastName = lastName };

            // Act
            stubDataAccess.AddNewPerson(testPerson);

            // Assert
            List<PersonModel> peopleList = stubDataAccess.GetAllPeople();
            Assert.That(peopleList.Count, Is.EqualTo(expectedCount));
            Assert.That(peopleList[expectedCount - 1].FirstName, Is.EqualTo(firstName));
            Assert.That(peopleList[expectedCount - 1].LastName, Is.EqualTo(lastName));
        }

        [Test]
        [TestCase("Ion", "Popescu", 1)]  
        [TestCase("Andrei", "Dontu", 1)]      
        [TestCase("Alice", "", 0)]    
        public void AddPersonToPeopleList_Test(string firstName, string lastName, int expectedCount)
        {
            // Arrange
            StubDataAccess stubDataAccess = new StubDataAccess();
            List<PersonModel> peopleList = new List<PersonModel>();

            // Act
           stubDataAccess.AddPersonToPeopleList(peopleList, new PersonModel { FirstName = firstName, LastName = lastName });

            // Assert
            Assert.That(peopleList.Count, Is.EqualTo(expectedCount));
        }

        //Moq Test
        [Test]
        [TestCase("Ion", "Popescu", 1)]
        [TestCase("Andrei", "Dontu", 1)]
        [TestCase("Alice", "", 0)]
        public void AddPersonToPeopleList_Test_Moq(string firstName, string lastName, int expectedCount)
        {
            // Arrange
            Mock<IDataAccess> mockDataAccess = new Mock<IDataAccess>();
            List<PersonModel> peopleList = new List<PersonModel>();

            // Setup the stub for file reading
            mockDataAccess.Setup(d => d.AddPersonToPeopleList(It.IsAny<List<PersonModel>>(), It.IsAny<PersonModel>()))
                          .Callback<List<PersonModel>, PersonModel>((list, person) => DataAccess.AddPersonToPeopleList(list, person));

            // Act
            mockDataAccess.Object.AddPersonToPeopleList(peopleList, new PersonModel { FirstName = firstName, LastName = lastName });

            // Assert
            Assert.That(peopleList.Count, Is.EqualTo(expectedCount));
        }

        //Moq Test
        [Test]
        public void GetAllPeople_Test()
        {
            // Arrange
            Mock<IDataAccess> mockDataAccess = new Mock<IDataAccess>();
            List<PersonModel> expectedPeopleList = new List<PersonModel>
            {
                new PersonModel { FirstName = "Andrei", LastName = "Dontu" },
                new PersonModel { FirstName = "Alice", LastName = "Bisioc" },
                new PersonModel { FirstName = "Dan", LastName = "Bulzan" }
            };

            // Setup the moq for data access
            mockDataAccess.Setup(d => d.GetAllPeople()).Returns(expectedPeopleList);

            // Act
            List<PersonModel> actualPeopleList = mockDataAccess.Object.GetAllPeople();

            // Assert
            Assert.That(actualPeopleList, Is.Not.Null);
            Assert.That(actualPeopleList.Count, Is.EqualTo(expectedPeopleList.Count));

            // Check individual entries
            for (int i = 0; i < expectedPeopleList.Count; i++)
            {
                Assert.That(actualPeopleList[i].FirstName, Is.EqualTo(expectedPeopleList[i].FirstName));
                Assert.That(actualPeopleList[i].LastName, Is.EqualTo(expectedPeopleList[i].LastName));
            }
        }

        [Test]
        [TestCase("", "Popescu", 1)]
        [TestCase("Alice", "Bisioc", 1)]
        [TestCase("Andrei", "Dontu", 1)]
        public void ConvertModelsToCSV_Test(string firstName, string lastName, int expectedCount)
        {
            // Arrange
            List<PersonModel> people = new List<PersonModel>();
            people.Add(new PersonModel { FirstName = firstName, LastName = lastName });

            // Act
            var result = DataAccess.ConvertModelsToCSV(people);

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedCount)); 

            string expectedString = $"{firstName},{lastName}";
            Assert.That(result[expectedCount - 1], Is.EqualTo(expectedString)); 
        }




    }
}
