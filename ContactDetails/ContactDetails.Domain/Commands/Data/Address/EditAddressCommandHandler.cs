using MediatR;
using ContactDetails.Service.DAL.Model;
using System.Threading;
using ContactDetails.Service.DAL.Service;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class EditAddressCommandHandler : IRequestHandler<EditAddressCommand, Address>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public EditAddressCommandHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public async Task<Address> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            await _contactDetailsDBService.EditAddressAsync(request._address);
            return request._address;
        }
    }
}
