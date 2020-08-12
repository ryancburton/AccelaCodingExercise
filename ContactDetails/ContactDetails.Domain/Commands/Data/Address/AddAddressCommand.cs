using MediatR;
using ContactDetails.Service.DAL.Model;

namespace ContactDetails.Domain.Commands.Data
{
    public class AddAddressCommand : IRequest<Address>
    {
        public Address _address { get; private set; }

        public AddAddressCommand(Address address)
        {
            _address = address;
        }
    }
}
