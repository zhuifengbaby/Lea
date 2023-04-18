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
    /// 日 期：2022-04-28 19:54
    /// 描 述：H_Member
    /// </summary>
    public class H_MemberService : RepositoryFactory<H_MemberEntity>, H_MemberIService
    {
        public IEnumerable<H_MemberEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<H_MemberEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "CardNumber":              //身份证号码
                        expression = expression.And(t => t.CardNumber.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<H_MemberEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<H_MemberEntity>();
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
                    case "HouseType":              //房屋类型
                        expression = expression.And(t => t.HouseType.Contains(keyword));
                        break;
                    case "CodeNumber":              //二维码门牌
                        expression = expression.And(t => t.CodeNumber.Contains(keyword));
                        break;
                    case "Name":              //居住人
                        expression = expression.And(t => t.Name.Contains(keyword));
                        break;
                    case "CardNumber":              //身份证号码
                        expression = expression.And(t => t.CardNumber.Contains(keyword));
                        break;
                    case "HJD":              //户籍地
                        expression = expression.And(t => t.HJD.Contains(keyword));
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
        public H_MemberEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, H_MemberEntity entity)
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
