using System.Collections.Generic;

namespace Domin
{
    public class DbSettings
    {
        /// <summary>
        /// 是否开启读写分离
        /// </summary>
        public bool OpenRWSeparate { get; set; }

        /// <summary>
        /// 数据库配置集合
        /// </summary>
        public IList<DbConnectInfo> DbCollect { get; set; }
    }
    public class DbConnectInfo
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DbConnectString { get; set; }

        /// <summary>
        /// 数据库访问类型
        /// </summary>
        public string DbAccessType { get; set; }

        /// <summary>
        /// 访问权重
        /// </summary>
        public int DbAccessWeight { get; set; }
    }

   
    public enum DbType
    {
        sqldb=1,
        mysqldb=2
    }

    public enum DbAccessType
    {
        /// <summary>
        /// 使用写库
        /// </summary>
        Write=1,

        /// <summary>
        /// 使用读库
        /// </summary>
        Read=2
    }
}
