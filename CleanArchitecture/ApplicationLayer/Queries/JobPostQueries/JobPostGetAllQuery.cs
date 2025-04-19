 
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.JobPostQueries
{
    public class JobPostGetAllQuery: IRequest<IEnumerable<JobPost>>  
    {
    }
}