using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDapperRepository
    {
        Task<TReturn> ExecuteClassStoredProcedure<TReturn>(string StoredProc, params object[] Parameters);
        Task<IEnumerable<TReturn>> ExecuteIEnumerableStoredProcedure<TReturn>(string StoredProc, params object[] Parameters);
    }
}
