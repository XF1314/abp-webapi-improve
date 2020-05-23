using Volo.Abp.Uow;
using Com.OPPO.Mo.Users;

namespace Com.OPPO.Mo.Blogging.Users
{
    public class BlogUserLookupService : UserLookupService<BlogUser, IBlogUserRepository>, IBlogUserLookupService
    {
        public BlogUserLookupService(
            IBlogUserRepository userRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                unitOfWorkManager)
        {
            
        }

        protected override BlogUser CreateUser(IUserData externalUser)
        {
            return new BlogUser(externalUser);
        }
    }
}