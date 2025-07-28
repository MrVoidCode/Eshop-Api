using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentDomainRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }
    }
}
