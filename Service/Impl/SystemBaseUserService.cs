using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreTools;
using Dapper;
using DapperDataAccess;
using Domin;
using Microsoft.Extensions.Options;
using Service.Contract;

namespace Service.Impl
{
   public class SystemBaseUserService: RepositoryBase, ISystemBaseUserService,IDependency
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbSettings"></param>
        public SystemBaseUserService(IOptionsMonitor<DbSettings> dbSettings) : base(dbSettings)
        {
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Add(SystemBaseUserDto dto)
        {
            using var conn=GetDbConnection();
            dto.Id = GetId();
            var r= conn.Execute(@"INSERT INTO [dbo].[System_Base_User]
                                    ([Id]
                                    ,[Name]
                                    ,[Age]
                                    ,[Mobile])
                                     VALUES
                                    (@Id
                                    ,@Name
                                    ,@Age
                                    ,@Mobile)", dto);
            return r > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            using (var conn=GetDbConnection())
            {
              var r=  conn.Execute(@"delete from [System_Base_User] where Id=@Id", id);
              return r > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool Update(SystemBaseUserDto dto)
        {
            using (var conn=GetDbConnection())
            {
                var r = conn.Execute(@"UPDATE [dbo].[System_Base_User]
                SET
                     [Name] = @Name
                    ,[Age] = @Age
                    ,[Mobile] = @Mobile
                WHERE Id = @Id", dto);
                return r>0;
            }
        }

        /// <summary>
        /// 获取单个dto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemBaseUserDto Get(long id)
        {
            using (var conn=GetDbConnection())
            {
              var dto=  conn.QueryFirstOrDefault<SystemBaseUserDto>("select * from System_Base_User where Id = @Id", new {Id = id});
              return dto;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IList<SystemBaseUserDto> GetList(string ids)
        {
            using (var conn = GetDbConnection())
            {
                var dtos = conn.Query<SystemBaseUserDto>("select * from System_Base_User where Id in @Ids", new { Ids =ids.Split(",") }).ToList();
                return dtos;
            }
        }

       
    }
}
