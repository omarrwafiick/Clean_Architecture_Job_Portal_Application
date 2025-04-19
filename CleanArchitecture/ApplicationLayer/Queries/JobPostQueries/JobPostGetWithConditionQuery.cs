using DomainLayer.Models;
using MediatR;
using System.Linq.Expressions;

namespace ApplicationLayer.Queries.JobPostQueries
{
    public class JobPostGetWithConditionQuery: IRequest<JobPost>  
    {
        public Expression<Func<JobPost, object>> condition {  get; set; }
    }
}
