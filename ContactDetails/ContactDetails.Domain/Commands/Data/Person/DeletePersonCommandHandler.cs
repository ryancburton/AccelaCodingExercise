using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public DeletePersonCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_contactDetailsDBService.DeletePerson(request._id));
        }
    }
}
