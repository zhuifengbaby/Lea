using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using LeaRun.Util;

using LeaRun.Util.Extension;
using System;

namespace LeaRun.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-05-04 13:25
    /// 描 述：Load_HomesteadAndBuildingApplication
    /// </summary>
    public class Load_HomesteadAndBuildingApplicationService : RepositoryFactory, Load_HomesteadAndBuildingApplicationIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Load_HomesteadAndBuildingApplicationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<Load_HomesteadAndBuildingApplicationEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["txt_Arear"].IsEmpty())
            {
                string txt_Arear = queryParam["txt_Arear"].ToString();
                expression = expression.And(t => t.IDNumber.Contains(txt_Arear));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<Load_HomesteadAndBuildingApplicationEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<Load_HomesteadAndBuildingApplicationEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["AllAddress"].IsEmpty())
            {
                string txt_Arear = queryParam["AllAddress"].ToString();
                expression = expression.And(t => t.IDNumber.Contains(txt_Arear));
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Load_HomesteadAndBuildingApplicationEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<Load_HomesteadAndBuildingApplicationEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<Load_HomesteadAndBuildingApplicationEntity>(keyValue);

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        
        //public void SaveDataAddToApprove(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity)
        //{

        //}
        public void SaveFormADD(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity)
        {
            IRepository db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        public void SaveForm(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity, List<Load_HomesteadAndBuildingApplicationEntity> entryList)
        {
            IRepository db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                    foreach (Load_HomesteadAndBuildingApplicationEntity item in entryList)
                    {
                        item.Create();
                        item.IDNumber = entity.ID;
                        db.Insert(item);
                    }
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);
                    //明细
                    foreach (Load_HomesteadAndBuildingApplicationEntity item in entryList)
                    {
                        item.Create();
                        item.IDNumber = entity.ID;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
#endregion
    }
}
