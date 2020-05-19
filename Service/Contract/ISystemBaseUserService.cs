using System;
using System.Collections.Generic;
using System.Text;
using Domin;

namespace Service.Contract
{
    interface ISystemBaseUserService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Add(SystemBaseUserDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(long id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Update(SystemBaseUserDto dto);

        /// <summary>
        /// 获取单个dto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SystemBaseUserDto Get(long id);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IList<SystemBaseUserDto> GetList(string ids);


    }
}
