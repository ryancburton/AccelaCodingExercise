using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public DeleteAddressCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_contactDetailsDBService.DeleteAddress(request._id));
        }
    }
}
