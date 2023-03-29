using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace MasterOfCoinsAPI.Repositories
{
    public abstract class BaseRepository<T>
        where T:class
    {
        public readonly IDbConnection connection;
        public BaseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public virtual bool Execute(string sql, object parameters)
        {
            using var conn = connection;
            var rows = conn.Execute(sql, parameters);
            return rows > 0;
        }

        public virtual T GetById(string sql, object parameters)
        {
            using var conn = connection;
            return conn.QueryFirst<T>(sql, parameters);
        }

        public virtual List<T> GetAll(string sql)
        {
            using var conn = connection;
            return conn.Query<T>(sql).ToList();
        }
    }
}
