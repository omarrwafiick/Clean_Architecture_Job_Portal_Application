using DomainLayer.Models;
using MediatR;
using System.Linq.Expressions;

namespace ApplicationLayer.Queries.JobApplicationQueries
{
    public class JobApplicationGetWithConditionQuery : IRequest<JobApplication>  
    {
        public Expression<Func<JobApplication, bool>> condition {  get; set; }
    }
}
