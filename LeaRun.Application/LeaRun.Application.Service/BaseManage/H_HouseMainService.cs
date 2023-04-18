using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.IService.BaseManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System;
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
    /// 日 期：2020-02-19 19:44
    /// 描 述：H_HouseMain
    /// </summary>
    public class H_HouseMainService : RepositoryFactory, H_HouseMainIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<H_HouseMainEntity> GetPageList(Pagination pagination, string queryJson)
        {     
            string where = " where 1=1 ";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["txt_address"].IsEmpty())
            {
                string txt_address = queryParam["txt_address"].ToString();
                 where = where + " and t1.Address like '%" + txt_address + "%'";
            }
            if (!queryParam["txt_Name"].IsEmpty())
            {
                string txt_address = queryParam["txt_Name"].ToString();
                where = where + " and t2.Name like '%" + txt_address + "%'";
            }
              if (!queryParam["txt_Phone"].IsEmpty())
            {
                string txt_Phone = queryParam["txt_Phone"].ToString();
                 where = where + " and t2.Phone like '%" + txt_Phone + "%'";
            }
            if (!queryParam["txt_CardNumber"].IsEmpty())
            {
                string txt_CardNumber = queryParam["txt_CardNumber"].ToString();
                where = where + " and t2.CardNumber like '%" + txt_CardNumber + "%'";
            }
              if (!queryParam["txt_CommunityName"].IsEmpty())
            {
                string txt_CommunityName = queryParam["txt_CommunityName"].ToString();
                 where = where + " and t1.CommunityName like '%" + txt_CommunityName + "%'";
            }
            if (!queryParam["txt_SheBaoNumber"].IsEmpty())
            {
                string txt_SheBaoNumber = queryParam["txt_SheBaoNumber"].ToString();
                where = where + " and t2.SheBaoNumber like '%" + txt_SheBaoNumber + "%'";
            }
              if (!queryParam["txt_WorkAdress"].IsEmpty())
            {
                string txt_WorkAdress = queryParam["txt_WorkAdress"].ToString();
                 where = where + " and t2.WorkAdress like '%" + txt_WorkAdress + "%'";
            }
            if (!queryParam["txt_HJD"].IsEmpty())
            {
                string txt_HJD = queryParam["txt_HJD"].ToString();
                where = where + " and t2.HJD like '%" + txt_HJD + "%'";
            }
            string sql = @"
select distinct t1.* from H_HouseMain t1 
left join 
(
select *  from
(select t1.*,t2.Name,t2.Phone,t2.CardNumber,'太仓'as HJD,t2.SheBaoNumber,t2.WorkAdress from H_HouseMain t1 
left join  H_Member t2 on t1.ID = t2.FInterID
) as tt1
union all 
(select t1.*,t2.Name,t2.Phone,t2.CardNumber,t2.HJD,t2.SheBaoNumber,t2.WorkAdress from H_HouseMain t1 
left join  H_ZhuMember t2 on t1.ID = t2.FInterID
) 
)as t2  on t1.ID =t2.ID " + where;
            return this.BaseRepository().FindList<H_HouseMainEntity>(sql);
         
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public H_HouseMainEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<H_HouseMainEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<H_MemberEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<H_MemberEntity>("select * from H_Member where FInterID='" + keyValue + "'");        }

        public IEnumerable<H_ZhuMemberEntity> GetDetails2(string keyValue)
        {
            return this.BaseRepository().FindList<H_ZhuMemberEntity>("select * from H_ZhuMember where FInterID='" + keyValue + "'");
        }

        public IEnumerable<H_HouseExcelEntity> GetDetails3()
        {
            string sql = @"select t1.Address,t2.Name,t2.HuGuanX,CQZ,Name,Sex,CardNumber,SheBaoNumber,
Phone,WorkAdress,'太仓' as HJD,HouseType,HouseStatus,HouseTX
,Area,FeiFArea,CQZNumber
 from H_HouseMain t1 
left join H_Member t2 on t1.ID =t2.FInterID
Union all
select t1.Address,t2.Name,'租客',CQZ,Name,Sex,CardNumber,SheBaoNumber,
Phone,WorkAdress,hjd as HJD,HouseType,HouseStatus,HouseTX
,Area,FeiFArea,CQZNumber
 from H_HouseMain t1 
left join H_ZhuMember t2 on t1.ID =t2.FInterID";
            return this.BaseRepository().FindList<H_HouseExcelEntity>(sql);
        }

        public IEnumerable<H_FHouseEntity> GetDetails4(string keyValue)
        {
            string sql = @"SELECT *
            FROM [LeaRunFramework_Base_2017].[dbo].[H_FHouse]";
            return this.BaseRepository().FindList<H_FHouseEntity>(sql);
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
                db.Delete<H_HouseMainEntity>(keyValue);
                db.Delete<H_MemberEntity>(t => t.ID.Equals(keyValue));
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
        public void SaveForm(string keyValue, H_HouseMainEntity entity, List<H_MemberEntity> entryList, List<H_ZhuMemberEntity> entryList2, List<H_FHouseEntity> entryList3)
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
                db.Delete<H_MemberEntity>(t => t.FInterID.Equals(keyValue));
                db.Delete<H_ZhuMemberEntity>(t => t.FInterID.Equals(keyValue));
                db.Delete<H_FHouseEntity>(t => t.FInterID.Equals(keyValue));
                foreach (H_MemberEntity item in entryList)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);
                };
                foreach (H_ZhuMemberEntity item in entryList2)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);
                };
                foreach (H_FHouseEntity item in entryList3)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);
 
                }
              
            }
            else
            {
                //主表
                entity.Create();
                db.Insert(entity);
                //明细
                foreach (H_MemberEntity item in entryList)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);
                }
                foreach (H_ZhuMemberEntity item in entryList2)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);
                }
                foreach (H_FHouseEntity item in entryList3)
                {
                    item.Create();
                    item.FInterID = entity.ID;
                    db.Insert(item);

                }
            }
            db.Commit();
        }
        catch (Exception ex)
        {
            db.Rollback();
            throw;
        }
        }
        #endregion

        public IEnumerable<H_ComEntity> GetComList()
        {
            string sql = @"select * from H_Com";
            return this.BaseRepository().FindList<H_ComEntity>(sql);
        }
        public IEnumerable<H_ComEntity> GetPageListCom(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList<H_ComEntity>(pagination);
        }
    }
}
