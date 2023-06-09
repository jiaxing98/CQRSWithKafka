﻿using Post.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task CreateAsync(CommentEntity comment);
        Task<CommentEntity> GetByIdAsync(Guid commentId);
        Task UpdateAsync(CommentEntity comment);
        Task DeleteAsync(Guid commentId);
    }
}
