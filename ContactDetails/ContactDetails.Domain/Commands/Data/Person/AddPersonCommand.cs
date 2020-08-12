using MediatR;
using ContactDetails.Service.DAL.Model;

namespace ContactDetails.Domain.Commands.Data
{
    public class AddPersonCommand : IRequest<Person>
    {
        public Person _person { get; private set; }

        public AddPersonCommand(Person person)
        {
            _person = person;
        }
    }
}
