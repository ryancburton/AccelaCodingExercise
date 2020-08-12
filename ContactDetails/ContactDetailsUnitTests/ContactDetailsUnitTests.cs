using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ContactDetails.Service.DAL.Service;
using ContactDetails.Service.DAL.Model;
using ContactDetails.Service.DAL.DataContext;
using System.Linq;

namespace ContactDetailsUnitTests
{
    [TestClass]
    public class ContactDetailsUnitTests : IDisposable
    {
        private ContactDetailsContext _contactDetailsContext;

        public ContactDetailsUnitTests()
        {
            //Database should be mocked in Memory db
            //Calling Controller would be more of an integration test than Unit test
            InitContext();
        }

        private void InitContext()
        {
            var builder = new DbContextOptionsBuilder<ContactDetailsContext>().UseInMemoryDatabase("ContactDetails");
            _contactDetailsContext = new ContactDetailsContext(builder.Options);

            Person person = new Person
            {
                firstName = "Robin",
                lastName = "Hood"
            };

            Person person1 = new Person
            {
                firstName = "Cat",
                lastName = "Lady"
            };

            if (!_contactDetailsContext.Person.Any())
            {
                _contactDetailsContext.Person.Add(person);
                _contactDetailsContext.Person.Add(person1);
                _contactDetailsContext.SaveChangesAsync();
            }
        }

        [TestMethod]
        public void GetPersonsAll()
        {
            var contactDetailsDBService = new ContactDetailsDBService(_contactDetailsContext);

            var Persons = contactDetailsDBService.GetPersonsAllAsyn().Result;

            Assert.AreEqual(Persons.Count(), 2);
        }

        [TestMethod]
        public async Task AddPerson()
        {
            var contactDetailsDBService = new ContactDetailsDBService(_contactDetailsContext);

            Person person = new Person
            {
                firstName = "Joker",
                lastName = "None"
            };

            await contactDetailsDBService.AddPersonAsync(person).ConfigureAwait(false);
            var Persons = contactDetailsDBService.GetPersonsAllAsyn().Result;

            var result = Persons.Where(e => e.firstName == "Joker");

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public async Task EditPerson()
        {
            var contactDetailsDBService = new ContactDetailsDBService(_contactDetailsContext);

            var person = contactDetailsDBService.GetPersonsAllAsyn().Result.FirstOrDefault<Person>();
            person.lastName = "SideKick";

            await contactDetailsDBService.EditPersonAsync(person).ConfigureAwait(false);
            var Persons = contactDetailsDBService.GetPersonsAllAsyn().Result.FirstOrDefault<Person>();

            Assert.AreEqual(Persons.lastName, "SideKick");
        }

        [TestMethod]
        public async Task DeletePerson()
        {
            var contactDetailsDBService = new ContactDetailsDBService(_contactDetailsContext);

            var person = contactDetailsDBService.GetPersonsAllAsyn().Result.FirstOrDefault<Person>();
            bool success = contactDetailsDBService.DeletePerson(person.Id);
            
            Assert.AreEqual(success, true);

        }

        public void Dispose()
        {
            _contactDetailsContext.Dispose();
        }
    }
}
