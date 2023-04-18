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
    /// 描 述：浮桥镇农村宅基地辅房和附属设施建设申请备案表
    /// </summary>
    public class Load_AuxiliaryRoomApplicationService : RepositoryFactory, Load_AuxiliaryRoomApplicationIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Load_AuxiliaryRoomApplicationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<Load_AuxiliaryRoomApplicationEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["txt_Arear"].IsEmpty())
            {
                string txt_Arear = queryParam["txt_Arear"].ToString();
                expression = expression.And(t => t.ID.Contains(txt_Arear));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<Load_AuxiliaryRoomApplicationEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<Load_AuxiliaryRoomApplicationEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["AllAddress"].IsEmpty())
            {
                string txt_Arear = queryParam["AllAddress"].ToString();
                expression = expression.And(t => t.ID.Contains(txt_Arear));
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Load_AuxiliaryRoomApplicationEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<Load_AuxiliaryRoomApplicationEntity>(keyValue);
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
                db.Delete<Load_AuxiliaryRoomApplicationEntity>(keyValue);

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Load_AuxiliaryRoomApplicationEntity entity)
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
        public void SaveFormADD(string keyValue, Load_AuxiliaryRoomApplicationEntity entity)
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

        #endregion
    }
}
