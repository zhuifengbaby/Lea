using LeaRun.Application.Entity.BaseManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-05-04 13:25
    /// 描 述：Load_HomesteadAndBuildingApplication
    /// </summary>
    public interface Load_HomesteadAndBuildingApplicationIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<Load_HomesteadAndBuildingApplicationEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<Load_HomesteadAndBuildingApplicationEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Load_HomesteadAndBuildingApplicationEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveFormADD(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity); 

        void SaveForm(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity, List<Load_HomesteadAndBuildingApplicationEntity> entryList);

        ///// <summary>
        ///// 保存申报数据到审批表
        ///// </summary>
        ///// <param name="keyValue"></param>
        ///// <param name="entity"></param>
        //void SaveDataAddToApprove(string keyValue, Load_HomesteadExamineApproveEntity entity); 
        #endregion
    }
}
