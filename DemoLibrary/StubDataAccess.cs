using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary.Models;
using ProjectLibrary;

namespace ProjectLibrary
{
    public class StubDataAccess : IDataAccess
    {
        private List<PersonModel> peopleList;
        private List<string> csvList;

        public StubDataAccess()
        {
            peopleList = new List<PersonModel>();
            csvList = new List<string>();
        }

        public void AddNewPerson(PersonModel person)
        {
            AddPersonToPeopleList(peopleList, person);
            csvList = ConvertModelsToCSV(peopleList);
        }

        public List<PersonModel> GetAllPeople()
        {
            return peopleList;
        }

        public void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Invalid person");
            }

            people.Add(person);
        }

        public List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            List<string> output = new List<string>();

            foreach (PersonModel user in people)
            {
                output.Add($"{user.FirstName},{user.LastName}");
            }

            return output;
        }
    }
}
