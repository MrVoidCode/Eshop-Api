using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    internal class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentDomainRepository _repository;
        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.Text, request.ProductId);
            await _repository.AddAsync(comment);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
