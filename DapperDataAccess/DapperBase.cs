using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Domin;

namespace DapperDataAccess
{
    public class DapperBase
    {
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        private readonly DbSettings _dbSettings;

        /// <summary>
        /// 是否启用数据库读写分离
        /// </summary>
        public readonly bool OpenRwSeparate;


        /// <summary>
        /// 写库
        /// </summary>
        private readonly DbConnectInfo _dbWriteConnectInfo;

        /// <summary>
        /// 读库
        /// </summary>
        private readonly IList<DbConnectInfo> _dbReadConnectInfos;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbSettings"></param>
        public DapperBase(IOptionsMonitor<DbSettings> dbSettings)
        {
            
            this._dbSettings = dbSettings.CurrentValue;
            this.OpenRwSeparate = _dbSettings.OpenRWSeparate;
            this._dbWriteConnectInfo = _dbSettings.DbCollect.FirstOrDefault(t => t.DbAccessType == "write");
            if (this.OpenRwSeparate)
            {
                InitReadDbCollect();
            }
        }

        /// <summary>
        /// 初始化读库集合
        /// </summary>
        private void InitReadDbCollect()
        {
            var readDbCollect = _dbSettings.DbCollect.Where(t => t.DbAccessType == "read");
            
            foreach (var dbConnectInfo in readDbCollect)
            {
                for (int i = 0; i < dbConnectInfo.DbAccessWeight; i++)
                {
                    _dbReadConnectInfos.Add(dbConnectInfo);
                }
            }
        }

        /// <summary>
        /// 获取读库集合随机索引
        /// </summary>
        /// <returns></returns>
        private int GetReadRandomIndex()
        {
            var readDbCount = _dbReadConnectInfos.Count;
            if (readDbCount==0)
            {
                throw new Exception("数据库连接对象获取失败，未配置只读数据库");
            }
            var random = new Random(Guid.NewGuid().GetHashCode()).Next(0, -1);
            return random;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private IDbConnection GetSqlConnection(DbConnectInfo connectInfo)
        {
            switch (connectInfo.DbType)
            {
                case "sqldb":
                    return new SqlConnection(connectInfo.DbConnectString);
                case "mysqldb":
                    return new MySqlConnection(connectInfo.DbConnectString);
                default:
                    throw new Exception($"不支持的数据库类型：{connectInfo.DbAccessType}");
            }
        }

       

        /// <summary>
        /// 随机获取读库数据库连接
        /// </summary>
        /// <returns></returns>
        private IDbConnection GetReadSqlConn()
        {
            var index = GetReadRandomIndex();
            return GetSqlConnection(_dbReadConnectInfos[index]);
        }


        /// <summary>
        /// 获取数据连接对象
        /// </summary>
        /// <param name="accessType">数据库类型：读/写，默认使用写库</param>
        /// <returns></returns>
        public IDbConnection GetDbConnection(DbAccessType accessType = DbAccessType.Write)
        {
            IDbConnection conn = null;
            if (OpenRwSeparate && accessType == DbAccessType.Read)
            {
                try
                {
                    conn = GetReadSqlConn();
                }
                catch
                {
                    conn = GetSqlConnection(_dbWriteConnectInfo);
                }
            }
            else
            {
                conn = GetSqlConnection(_dbWriteConnectInfo);
            }
            return conn;
        }
    }
}
