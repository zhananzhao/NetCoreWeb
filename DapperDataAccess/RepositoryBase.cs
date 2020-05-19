using System;
using Dapper;
using DapperDataAccess.Helper;
using Domin;
using Microsoft.Extensions.Options;

namespace DapperDataAccess
{
    public class RepositoryBase:DapperBase
    {
        private IdHelper _idHelper; 

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbSettings"></param>
        public RepositoryBase(IOptionsMonitor<DbSettings> dbSettings) : base(dbSettings)
        {
            _idHelper=new IdHelper(1,1);
        }

        public long GetId()
        {
            return _idHelper.NextId();
        }
    }
}
