using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-05-04 13:25
    /// 描 述：农村宅基地批准书
    /// </summary>
    public class Load_HomesteadApprovalEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 申请编号
        /// </summary>
        /// <returns></returns>
        [Column("ApplicationNo")]
        public String ApplicationNo { get; set; }

        /// <summary>
        /// 宅基地号码
        /// </summary>
        /// <returns></returns>
        [Column("HOMESTEADNUMBER")]
        public string HomesteadNumber { get; set; }
        /// <summary>
        /// 户主姓名
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDERNAME")]
        public string HouseholderName { get; set; }
        /// <summary>
        /// 批准用地面积
        /// </summary>
        /// <returns></returns>
        [Column("APPROVEDLANDAREA")]
        public decimal? ApprovedLandArea { get; set; }
        /// <summary>
        /// 房屋占地面积
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEAREA")]
        public decimal? HouseArea { get; set; }
        /// <summary>
        /// 土地所有权人姓名
        /// </summary>
        /// <returns></returns>
        [Column("LANDOWNERNAME")]
        public string LandOwnerName { get; set; }
        /// <summary>
        /// 土地位置
        /// </summary>
        /// <returns></returns>
        [Column("LANDLOCATION")]
        public string LandLocation { get; set; }
        /// <summary>
        /// 东至
        /// </summary>
        /// <returns></returns>
        [Column("EASTERNBOUNDARY")]
        public string EasternBoundary { get; set; }
        /// <summary>
        /// 南至
        /// </summary>
        /// <returns></returns>
        [Column("SOUTHERNBOUNDARY")]
        public string SouthernBoundary { get; set; }
        /// <summary>
        /// 西至
        /// </summary>
        /// <returns></returns>
        [Column("WESTERNBOUNDARY")]
        public string WesternBoundary { get; set; }
        /// <summary>
        /// 北至
        /// </summary>
        /// <returns></returns>
        [Column("NORTHERNBOUNDARY")]
        public string NorthernBoundary { get; set; }
        /// <summary>
        /// 批准书有效期
        /// </summary>
        /// <returns></returns>
        [Column("VALIDITYPERIOD")]
        public DateTime? ValidityPeriod { get; set; }
        /// <summary>
        /// 批准时间
        /// </summary>
        /// <returns></returns>
        [Column("APPROVALDATE")]
        public DateTime? ApprovalDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string Remarks { get; set; }
        /// <summary>
        /// ApproveStatus
        /// </summary>
        /// <returns></returns>
        [Column("APPROVESTATUS")]
        public string ApproveStatus { get; set; }
        /// <summary>
        /// DelestStatus
        /// </summary>
        /// <returns></returns>
        [Column("DELESTSTATUS")]
        public string DelestStatus { get; set; }
        /// <summary>
        /// CreateUser
        /// </summary>
        /// <returns></returns>
        [Column("CREATEUSER")]
        public string CreateUser { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// UpdateTime
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UpdateTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
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