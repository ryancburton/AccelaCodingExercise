﻿using MediatR;
using ContactDetails.Domain.Response;
using ContactDetails.Service.DAL.Model;
using System.Threading.Tasks;

namespace ContactDetails.Domain.Commands.Data
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int _id { get; private set; }

        public DeleteAddressCommand(int id)
        {
            _id = id;
        }
    }
}
