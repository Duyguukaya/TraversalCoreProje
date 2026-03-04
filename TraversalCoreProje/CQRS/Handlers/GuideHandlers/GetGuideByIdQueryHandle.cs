using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandle : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandle(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                GuideId = values.GuideId,
                Descrption = values.Descrption,
                Name = values.Name
            };
        }
    }
}
