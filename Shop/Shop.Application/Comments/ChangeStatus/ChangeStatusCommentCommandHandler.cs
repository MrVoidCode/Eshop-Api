using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus;

internal class ChangeStatusCommentCommandHandler : IBaseCommandHandler<ChangeStatusCommentCommand>
{
    private readonly IDomainCommentRepository _repository;

    public ChangeStatusCommentCommandHandler(IDomainCommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeStatusCommentCommand request,
        CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId);
        if (comment == null)
        {
            return OperationResult.NotFound();
        }

        comment.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();
    }
}