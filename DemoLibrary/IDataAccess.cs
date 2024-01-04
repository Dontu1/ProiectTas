using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary.Models;

namespace ProjectLibrary
{
    public interface IDataAccess
    {
        void AddNewPerson(PersonModel person);
        List<PersonModel> GetAllPeople();
        void AddPersonToPeopleList(List<PersonModel> people, PersonModel person);
        List<string> ConvertModelsToCSV(List<PersonModel> people);
    }
}
