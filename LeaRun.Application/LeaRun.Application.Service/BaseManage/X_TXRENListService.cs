using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using LeaRun.Util;

using LeaRun.Util.Extension;

namespace LeaRun.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-10-30 20:53
    /// 描 述：X_TXRENList
    /// </summary>
    public class X_TXRENListService : RepositoryFactory<X_TXRENListEntity>, X_TXRENListIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<X_TXRENListEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<X_TXRENListEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Arear":              //村社区
                        expression = expression.And(t => t.Arear.Contains(keyword));
                        break;
                    case "HuName":              //户主姓名
                        expression = expression.And(t => t.HuName.Contains(keyword));
                        break;
                    case "TXStatus":              //状态
                        expression = expression.And(t => t.TXStatus.Contains(keyword));
                        break;
                    case "Name":              //退休适龄人员姓名
                        expression = expression.And(t => t.Name.Contains(keyword));
                        break;
                    case "SFZNumber":              //身份证号码
                        expression = expression.And(t => t.SFZNumber.Contains(keyword));
                        break;
                    //case "CreateDate":              //归档日期
                    //    expression = expression.And(t => t.CreateDate.Contains(keyword));
                    //    break;
                    default:
                        break;
                }
            }
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<X_TXRENListEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<X_TXRENListEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Arear":              //村社区
                        expression = expression.And(t => t.Arear.Contains(keyword));
                        break;
                    case "HuName":              //户主姓名
                        expression = expression.And(t => t.HuName.Contains(keyword));
                        break;
                    case "TXStatus":              //状态
                        expression = expression.And(t => t.TXStatus.Contains(keyword));
                        break;
                    case "Name":              //退休适龄人员姓名
                        expression = expression.And(t => t.Name.Contains(keyword));
                        break;
                    case "SFZNumber":              //身份证号码
                        expression = expression.And(t => t.SFZNumber.Contains(keyword));
                        break;
                    //case "CreateDate":              //归档日期
                    //    expression = expression.And(t => t.CreateDate.Contains(keyword));
                    //    break;
                    default:
                        break;
                }
            }
            return this.BaseRepository().IQueryable(expression).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public X_TXRENListEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, X_TXRENListEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
