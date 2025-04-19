 
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.QueriesJobApplicationQueries
{
    public class JobApplicationGetAllQuery : IRequest<IEnumerable<JobApplication>> 
    {
    }
}