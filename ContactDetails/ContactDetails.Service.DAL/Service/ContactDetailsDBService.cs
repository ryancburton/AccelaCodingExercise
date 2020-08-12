using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetails.Service.DAL.DataContext;
using ContactDetails.Service.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactDetails.Service.DAL.Service
{
    public class ContactDetailsDBService : IContactDetailsDBService
    {
        private readonly ContactDetailsContext _contactDetailsContext;
        public ContactDetailsDBService(ContactDetailsContext contactDetailsContext)
        {
            _contactDetailsContext = contactDetailsContext;
        }

        public async Task<IEnumerable<Person>> GetPersonsAllAsyn() => await _contactDetailsContext.Person.ToListAsync();

        public int FindNumberOfPersons() => _contactDetailsContext.Person.Count();

        public async Task AddPersonAsync(Person person)
        {
            await _contactDetailsContext.Person.AddAsync(person).ConfigureAwait(false);
            await _contactDetailsContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task EditPersonAsync(Person person)
        {
            try
            {
                var local = _contactDetailsContext.Set<Person>().Local.FirstOrDefault(entry => entry.Id.Equals(entry.Id));

                if (local != null)
                {
                    _contactDetailsContext.Entry(local).State = EntityState.Detached;
                }

                _contactDetailsContext.Entry(person).State = EntityState.Modified;
                await _contactDetailsContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool DeletePerson(int id)
        {
            try
            {
                Person local = _contactDetailsContext.Person.Find(id);
                
                if (local != null)
                {
                    _contactDetailsContext.Person.Remove(local);
                    _contactDetailsContext.Entry(local).State = EntityState.Deleted;
                    _contactDetailsContext.SaveChangesAsync();
                    return true;
                }

                return false;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task AddAddressAsync(Address address)
        {
            await _contactDetailsContext.Address.AddAsync(address).ConfigureAwait(false);
            await _contactDetailsContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task EditAddressAsync(Address address)
        {
            try
            {
                var local = _contactDetailsContext.Set<Address>().Local.FirstOrDefault(entry => entry.Id.Equals(entry.Id));

                if (local != null)
                {
                    _contactDetailsContext.Entry(local).State = EntityState.Detached;
                }

                _contactDetailsContext.Entry(address).State = EntityState.Modified;
                await _contactDetailsContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool DeleteAddress(int id)
        {
            try
            {
                Address local = _contactDetailsContext.Address.Find(id);

                if (local != null)
                {
                    _contactDetailsContext.Address.Remove(local);
                    _contactDetailsContext.Entry(local).State = EntityState.Deleted;
                    _contactDetailsContext.SaveChangesAsync();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }
    }
}
