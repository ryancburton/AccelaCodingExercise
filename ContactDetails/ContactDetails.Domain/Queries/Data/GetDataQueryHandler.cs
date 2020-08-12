using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using ContactDetails.Service.DAL.Model;
using ContactDetails.Service.DAL.Service;

namespace ContactDetails.Domain.Queries.Data
{
    public class GetPersonsAllQueryHandler : IRequestHandler<GetPersonsAllQuery, IEnumerable<Person>>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public GetPersonsAllQueryHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public async Task<IEnumerable<Person>> Handle(GetPersonsAllQuery request, CancellationToken cancellationToken)
        {
            return await _contactDetailsDBService.GetPersonsAllAsyn();
        }
    }

    public class GetPersonsNumberQueryHandler : IRequestHandler<GetPersonsNumberQuery, int>
    {
        private readonly IContactDetailsDBService _contactDetailsDBService;

        public GetPersonsNumberQueryHandler(IContactDetailsDBService contactDetailsDBService)
        {
            _contactDetailsDBService = contactDetailsDBService;
        }

        public Task<int> Handle(GetPersonsNumberQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_contactDetailsDBService.FindNumberOfPersons());
        }
    }
}
