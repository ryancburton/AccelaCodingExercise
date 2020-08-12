using Microsoft.EntityFrameworkCore;

namespace ContactDetails.Service.DAL.DataContext
{
    public class ContactDetailsContext : DbContext
    {
        public ContactDetailsContext(DbContextOptions<ContactDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<ContactDetails.Service.DAL.Model.Person> Person { get; set; }

        public DbSet<ContactDetails.Service.DAL.Model.Address> Address { get; set; }
    }
}
