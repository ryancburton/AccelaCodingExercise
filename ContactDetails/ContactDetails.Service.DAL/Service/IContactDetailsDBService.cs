using System.Collections.Generic;
using System.Threading.Tasks;
using ContactDetails.Service.DAL.Model;

namespace ContactDetails.Service.DAL.Service
{
    public interface IContactDetailsDBService
    {
        Task<IEnumerable<Person>> GetPersonsAllAsyn();
        int FindNumberOfPersons();
        Task AddPersonAsync(Person company);
        Task EditPersonAsync(Person company);

        bool DeletePerson(int id);
        
        Task AddAddressAsync(Address company);
        Task EditAddressAsync(Address company);

        bool DeleteAddress(int id);
    }
}
