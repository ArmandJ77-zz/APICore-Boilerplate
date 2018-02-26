using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    /// <summary>
    /// Used when implimenting multiple  queries each returning a diffirent result while sharing criteria
    /// </summary>
    /// <typeparam name="TCriteria"></typeparam>
    public abstract class BaseDynamicCriteriaHandler<TCriteria> : BaseHandler
    {
        protected BaseDynamicCriteriaHandler(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public abstract Task<dynamic> ExecuteAsync(TCriteria criteria);
    }
}
