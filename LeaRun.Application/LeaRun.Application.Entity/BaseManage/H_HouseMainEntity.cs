using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-19 19:44
    /// 描 述：H_HouseMain
    /// </summary>
    public class H_HouseMainEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>

        public string ID { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>

        public string Address { get; set; }
        /// <summary>
        /// HuName
        /// </summary>
        /// <returns></returns>

        public string HuName { get; set; }
        /// <summary>
        /// CQZ
        /// </summary>
        /// <returns></returns>

        public string CQZ { get; set; }
        /// <summary>
        /// HouseType
        /// </summary>
        /// <returns></returns>

        public string HouseType { get; set; }
        /// <summary>
        /// HouseStatus
        /// </summary>
        /// <returns></returns>

        public string HouseStatus { get; set; }
        /// <summary>
        /// HouseTX
        /// </summary>
        /// <returns></returns>

        public string HouseTX { get; set; }

        public string ArearName { get; set; }
        public string CommunityName { get; set; }
        public string CQZNumber { get; set; }
        public string Url { get; set; }
        public string TDNumber { get; set; }
        public Double? Area { get; set; }
        public Double? FeiFArea { get; set; }
        public string t_lat { get; set; }
        public string t_lng { get; set; }
        #endregion

        #region 扩展操作
         //<summary>
         //新增调用
         //</summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
        }
        #endregion
    }
}