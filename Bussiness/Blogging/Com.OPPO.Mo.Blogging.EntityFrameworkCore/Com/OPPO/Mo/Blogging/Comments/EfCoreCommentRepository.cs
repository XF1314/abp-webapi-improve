﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Com.OPPO.Mo.Blogging.EntityFrameworkCore;

namespace Com.OPPO.Mo.Blogging.Comments
{
    public class EfCoreCommentRepository : EfCoreRepository<IBloggingDbContext, Comment, Guid>, ICommentRepository
    {
        public EfCoreCommentRepository(IDbContextProvider<IBloggingDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<Comment>> GetListOfPostAsync(Guid postId)
        {
            return await DbSet
                .Where(a => a.PostId == postId)
                .OrderBy(a => a.CreationTime)
                .ToListAsync();
        }

        public async Task<int> GetCommentCountOfPostAsync(Guid postId)
        {
            return await DbSet
                .CountAsync(a => a.PostId == postId);
        }

        public async Task<List<Comment>> GetRepliesOfComment(Guid id)
        {
            return await DbSet
                .Where(a => a.RepliedCommentId == id).ToListAsync();
        }

        public async Task DeleteOfPost(Guid id)
        {
            var recordsToDelete = DbSet.Where(pt => pt.PostId == id);
            DbSet.RemoveRange(recordsToDelete);
        }
    }
}
