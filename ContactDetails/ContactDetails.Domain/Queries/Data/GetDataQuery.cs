using System.Collections.Generic;
using ContactDetails.Service.DAL.Model;
using MediatR;

namespace ContactDetails.Domain.Queries.Data
{
    public class GetPersonsAllQuery : IRequest<IEnumerable<Person>>
    {
        public GetPersonsAllQuery()
        {

        }
    }

    public class GetPersonsNumberQuery : IRequest<int>
    {
        public GetPersonsNumberQuery()
        {

        }
    }
}
