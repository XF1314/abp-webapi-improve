using System.Data;

namespace Com.OPPO.Mo.Domain.Repositories.Dapper
{
    public interface IDapperRepository
    {
        IDbConnection DbConnection { get; }

        IDbTransaction DbTransaction { get; }
    }
}