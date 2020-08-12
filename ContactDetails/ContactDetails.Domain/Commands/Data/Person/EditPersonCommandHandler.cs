using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, Person>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public EditPersonCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public async Task<Person> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            await _contactDetailsDBService.EditPersonAsync(request._person);
            return request._person;
        }
    }
}
