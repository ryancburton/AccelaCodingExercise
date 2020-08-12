using MediatR;
using ContactDetails.Domain.Response;
using ContactDetails.Service.DAL.Model;

namespace ContactDetails.Domain.Commands.Data
{
    public class EditAddressCommand : IRequest<Address>
    {
        public Address _address { get; private set; }

        public EditAddressCommand(Address address)
        {
            _address = address;
        }
    }
}
