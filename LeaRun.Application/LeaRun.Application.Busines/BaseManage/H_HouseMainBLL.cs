using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Application.Service.BaseManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-19 19:44
    /// 描 述：H_HouseMain
    /// </summary>
    public class H_HouseMainBLL
    {
        private H_HouseMainIService service = new H_HouseMainService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<H_HouseMainEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        public IEnumerable<H_ComEntity> GetPageListJsonCom(Pagination pagination, string queryJson)
        {
            return service.GetPageListCom(pagination, queryJson);
        }

        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public H_HouseMainEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<H_MemberEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(keyValue);
        }

        public IEnumerable<H_ZhuMemberEntity> GetDetails2(string keyValue)
        {
            return service.GetDetails2(keyValue);
        }

        public IEnumerable<H_FHouseEntity> GetDetails4(string keyValue)
        {
            return service.GetDetails4(keyValue);
        }

        public IEnumerable<H_HouseExcelEntity> GetDetails3()
        {
            return service.GetDetails3();
        }
        public IEnumerable<H_ComEntity> GetComList()
        {
            return service.GetComList();
        }
        
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, H_HouseMainEntity entity, List<H_MemberEntity> entryList, List<H_ZhuMemberEntity> entryList2, List<H_FHouseEntity> entryList3)
        {
            try
            {
                service.SaveForm(keyValue, entity, entryList, entryList2,entryList3);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
