using Common.Application;
using Shop.Domain.CommentAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    internal class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        private readonly ICommentDomainRepository _repository;
        public EditCommentCommandHandler(ICommentDomainRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null || comment.UserId != request.UserId)
            {
                return OperationResult.NotFound();
            }
            comment.Edit(request.Text);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
