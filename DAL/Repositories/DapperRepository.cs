using DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        public Task<TReturn> ExecuteClassStoredProcedure<TReturn>(string StoredProc, params object[] Parameters)
        {
            return Task.Run(() =>
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    db.Open();

                    var parameters = new Dapper.DynamicParameters();

                    if (Parameters.Length != 0)
                    {
                        foreach (var props in Parameters[0].GetType().GetProperties())
                        {
                            parameters.Add("@" + props.Name, props.GetValue(Parameters[0]));
                        }
                    }

                    return Task.FromResult(db.QueryFirst<TReturn>(StoredProc, parameters, commandType: CommandType.StoredProcedure));
                }
            });
        }

        public Task<IEnumerable<TReturn>> ExecuteIEnumerableStoredProcedure<TReturn>(string StoredProc, params object[] Parameters)
        {
            return Task.Run(() =>
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    db.Open();

                    var parameters = new DynamicParameters();

                    if (Parameters.Length != 0)
                    {
                        foreach (var props in Parameters[0].GetType().GetProperties())
                        {
                            parameters.Add("@" + props.Name, props.GetValue(Parameters[0]));
                        }
                    }

                    return Task.FromResult(db.Query<TReturn>(StoredProc, parameters, commandType: CommandType.StoredProcedure));
                }
            });
        }
    }
}
