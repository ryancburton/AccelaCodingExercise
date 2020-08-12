using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Person>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public AddPersonCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public async Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            await _contactDetailsDBService.AddPersonAsync(request._person);
            return request._person;
        }
    }
}
