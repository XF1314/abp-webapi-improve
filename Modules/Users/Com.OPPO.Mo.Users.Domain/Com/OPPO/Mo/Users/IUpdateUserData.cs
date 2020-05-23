using JetBrains.Annotations;

namespace Com.OPPO.Mo.Users
{
    public interface IUpdateUserData
    {
        bool Update([NotNull] IUserData user);
    }
}