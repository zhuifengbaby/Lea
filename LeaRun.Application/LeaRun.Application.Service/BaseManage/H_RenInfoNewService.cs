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
    /// 日 期：2022-05-03 18:04
    /// 描 述：H_RenInfoNew
    /// </summary>
    public class H_RenInfoNewService : RepositoryFactory<H_RenInfoNewEntity>, H_RenInfoNewIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<H_RenInfoNewEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<H_RenInfoNewEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件

            if (!queryParam["Arear"].IsEmpty())
            {
                string txt_Arear = queryParam["Arear"].ToString();
                expression = expression.And(t => t.Arear.Contains(txt_Arear));
            }
            if (!queryParam["ArearNumber"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["ArearNumber"].ToString();
                expression = expression.And(t => t.ArearNumber.Contains(txt_ArearNumber));
            }
            if (!queryParam["Address"].IsEmpty())
            {
                string txt_Address = queryParam["Address"].ToString();
                expression = expression.And(t => t.Address.Contains(txt_Address));
            }
            if (!queryParam["HouseType"].IsEmpty())
            {
                string txt_HouseType = queryParam["HouseType"].ToString();
                expression = expression.And(t => t.HouseType.Contains(txt_HouseType));
            }
            if (!queryParam["CodeNumber"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["CodeNumber"].ToString();
                expression = expression.And(t => t.CodeNumber.Contains(txt_CodeNumber));
            }
            if (!queryParam["CQRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["CQRen"].ToString();
                expression = expression.And(t => t.CQRen.Contains(txt_CQRen));
            }
            if (!queryParam["JZRenName"].IsEmpty())
            {
                string txt_Arear = queryParam["JZRenName"].ToString();
                expression = expression.And(t => t.JZRenName.Contains(txt_Arear));
            }
            if (!queryParam["IDCard"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["IDCard"].ToString();
                expression = expression.And(t => t.IDCard.Contains(txt_ArearNumber));
            }
            if (!queryParam["SJJZAddress"].IsEmpty())
            {
                string txt_Address = queryParam["SJJZAddress"].ToString();
                expression = expression.And(t => t.SJJZAddress.Contains(txt_Address));
            }
            if (!queryParam["HJInfo"].IsEmpty())
            {
                string txt_HouseType = queryParam["HJInfo"].ToString();
                expression = expression.And(t => t.HJInfo.Contains(txt_HouseType));
            }
            if (!queryParam["ZhiYe"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["ZhiYe"].ToString();
                expression = expression.And(t => t.ZhiYe.Contains(txt_CodeNumber));
            }
            if (!queryParam["ImpRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["ImpRen"].ToString();
                expression = expression.And(t => t.ImpRen.Contains(txt_CQRen));
            }
            if (!queryParam["JZRenType"].IsEmpty())
            {
                string txt_CQRen = queryParam["JZRenType"].ToString();
                expression = expression.And(t => t.JZRenType.Contains(txt_CQRen));
            }
            if (!queryParam["ASTime"].IsEmpty())
            {

                DateTime ASTime = queryParam["ASTime"].ToString().ToDate();
                expression = expression.And(t => t.CreateDate>=ASTime);
            }
            if (!queryParam["AETime"].IsEmpty())
            {
                DateTime AETime = queryParam["AETime"].ToString().ToDate().AddDays(1);
                expression = expression.And(t => t.CreateDate <= AETime);
            }
            if (!queryParam["SSTime"].IsEmpty())
            {
                DateTime ASTime = queryParam["SSTime"].ToString().ToDate();
                expression = expression.And(t => t.ShenDate >= ASTime);
            }
            if (!queryParam["SETime"].IsEmpty())
            {
                DateTime AETime = queryParam["SETime"].ToString().ToDate().AddDays(1);
                expression = expression.And(t => t.ShenDate <= AETime);
            }
            if (!queryParam["Status"].IsEmpty())
            {
                string Status = queryParam["Status"].ToString();
                expression = expression.And(t => t.Status==Status);
            }
            if (!queryParam["role"].IsEmpty())
            {
                string role = queryParam["role"].ToString();
                if (role == "经发局")
                {
                    expression = expression.And(t => t.Id.Contains("QY"));
                }
            }
            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<H_RenInfoNewEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<H_RenInfoNewEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Arear":              //村居
                        expression = expression.And(t => t.Arear.Contains(keyword));
                        break;
                    case "ArearNumber":              //网格名称
                        expression = expression.And(t => t.ArearNumber.Contains(keyword));
                        break;
                    case "Address":              //坐落详址
                        expression = expression.And(t => t.Address.Contains(keyword));
                        break;
                    case "HouseType":              //房屋性质
                        expression = expression.And(t => t.HouseType.Contains(keyword));
                        break;
                    case "CodeNumber":              //二维码门牌
                        expression = expression.And(t => t.CodeNumber.Contains(keyword));
                        break;
                    case "CQRen":              //产权人
                        expression = expression.And(t => t.CQRen.Contains(keyword));
                        break;
                    case "JZRenName":              //居住人姓名
                        expression = expression.And(t => t.JZRenName.Contains(keyword));
                        break;
                    case "JZRenType":              //居住人员类别
                        expression = expression.And(t => t.JZRenType.Contains(keyword));
                        break;
                    case "IDCard":              //身份证号码
                        expression = expression.And(t => t.IDCard.Contains(keyword));
                        break;
                    case "SJJZAddress":              //实际居住地址
                        expression = expression.And(t => t.SJJZAddress.Contains(keyword));
                        break;
                    case "HJInfo":              //户籍信息
                        expression = expression.And(t => t.HJInfo.Contains(keyword));
                        break;
                    case "ZhiYe":              //职业
                        expression = expression.And(t => t.ZhiYe.Contains(keyword));
                        break;
                    case "ImpRen":              //重点人员
                        expression = expression.And(t => t.ImpRen.Contains(keyword));
                        break;
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
        public H_RenInfoNewEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, H_RenInfoNewEntity entity)
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
