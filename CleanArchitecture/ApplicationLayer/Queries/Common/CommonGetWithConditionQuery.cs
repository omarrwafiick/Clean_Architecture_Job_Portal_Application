using MediatR;
using System.Linq.Expressions;

namespace ApplicationLayer.Queries.Common
{
    public class CommonGetWithConditionQuery<T> : IRequest<T> where T : class
    {
        public Expression<Func<T, object>> condition {  get; set; }
    }
}
