using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System.Data;

namespace LeaRun.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_House
    /// </summary>
    public class H_HouseService : RepositoryFactory, H_HouseIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<H_HouseEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<H_HouseEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["txt_Arear"].IsEmpty())
            {
                string txt_Arear = queryParam["txt_Arear"].ToString();
                expression = expression.And(t => t.Arear.Contains(txt_Arear));
            }
            if (!queryParam["txt_ArearNumber"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["txt_ArearNumber"].ToString();
                expression = expression.And(t => t.ArearNumber.Contains(txt_ArearNumber));
            }
            if (!queryParam["txt_Address"].IsEmpty())
            {
                string txt_Address = queryParam["txt_Address"].ToString();
                expression = expression.And(t => t.Address.Contains(txt_Address));
            }
            if (!queryParam["txt_HouseType"].IsEmpty())
            {
                string txt_HouseType = queryParam["txt_HouseType"].ToString();
                expression = expression.And(t => t.HouseType.Contains(txt_HouseType));
            }
            if (!queryParam["txt_CodeNumber"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["txt_CodeNumber"].ToString();
                expression = expression.And(t => t.CodeNumber.Contains(txt_CodeNumber));
            }
            if (!queryParam["txt_CQRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["txt_CQRen"].ToString();
                expression = expression.And(t => t.CQRen.Contains(txt_CQRen));
            }
            if (!queryParam["txt_HouseStatus"].IsEmpty())
            {
                string txt_HouseStatus = queryParam["txt_HouseStatus"].ToString();
                expression = expression.And(t => t.HH==txt_HouseStatus);
            }
            return this.BaseRepository().FindList(expression,pagination);
        }


        public IEnumerable<H_HouseEntity> GetPageList2(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<H_HouseEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["txt_Arear"].IsEmpty())
            {
                string txt_Arear = queryParam["txt_Arear"].ToString();
                expression = expression.And(t => t.Arear.Contains(txt_Arear));
            }
            if (!queryParam["txt_ArearNumber"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["txt_ArearNumber"].ToString();
                expression = expression.And(t => t.ArearNumber.Contains(txt_ArearNumber));
            }
            if (!queryParam["txt_Address"].IsEmpty())
            {
                string txt_Address = queryParam["txt_Address"].ToString();
                expression = expression.And(t => t.Address.Contains(txt_Address));
            }
            if (!queryParam["txt_HouseType"].IsEmpty())
            {
                string txt_HouseType = queryParam["txt_HouseType"].ToString();
                expression = expression.And(t => t.HouseType.Contains(txt_HouseType));
            }
            if (!queryParam["txt_CodeNumber"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["txt_CodeNumber"].ToString();
                expression = expression.And(t => t.CodeNumber.Contains(txt_CodeNumber));
            }
            if (!queryParam["txt_CQRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["txt_CQRen"].ToString();
                expression = expression.And(t => t.CQRen.Contains(txt_CQRen));
            }
            if (!queryParam["txt_HouseStatus"].IsEmpty())
            {
                string txt_HouseStatus = queryParam["txt_HouseStatus"].ToString();
                expression = expression.And(t => t.HH == txt_HouseStatus);
            }
            expression = expression.And(t => t.IsDeleted.Contains("待审核"));

            return this.BaseRepository().FindList(expression, pagination);
        }

        public IEnumerable<H_HouseEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<H_HouseEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["AllAddress"].IsEmpty())
            {
                string txt_Arear = queryParam["AllAddress"].ToString();
                expression = expression.And(t => t.AllAddress.Contains(txt_Arear));
            }
            return this.BaseRepository().FindList(expression);
        }


      public DataTable GetList2(string queryJson)
        {
            string sql = queryJson;
            return new RepositoryFactory().BaseRepository().FindTable(sql);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public H_HouseEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<H_HouseEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<H_RenInfoEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<H_RenInfoEntity>("select * from H_RenInfo where AllAddress='" + keyValue + "'");        }
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
                db.Delete<H_HouseEntity>(keyValue);
         
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
        public void SaveForm(string keyValue, H_HouseEntity entity,List<H_RenInfoEntity> entryList)
        {
        IRepository db = this.BaseRepository().BeginTrans();
        try
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //主表
                entity.Modify(keyValue);
                db.Update(entity);
                //明细
                db.Delete<H_RenInfoEntity>(t => t.AllAddress.Equals(keyValue));
                foreach (H_RenInfoEntity item in entryList)
                {
                    item.Create();
                    item.AllAddress = entity.ID;
                    db.Insert(item);
                }
            }
            else
            {
                //主表
                entity.Create();
                db.Insert(entity);
                //明细
                foreach (H_RenInfoEntity item in entryList)
                {
                    item.Create();
                    item.AllAddress = entity.ID;
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

        public void SaveFormADD(string keyValue, H_HouseEntity entity)
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
