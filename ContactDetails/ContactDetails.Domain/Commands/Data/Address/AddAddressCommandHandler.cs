using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, Address>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public AddAddressCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public async Task<Address> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            await _contactDetailsDBService.AddAddressAsync(request._address);
            return request._address;
        }
    }
}
