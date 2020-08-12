using MediatR;
using ContactDetails.Domain.Response;
using ContactDetails.Service.DAL.Model;

namespace ContactDetails.Domain.Commands.Data
{
    public class EditPersonCommand : IRequest<Person>
    {
        public Person _person { get; private set; }

        public EditPersonCommand(Person person)
        {
            _person = person;
        }
    }
}
