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
    /// 描 述：农村宅基地使用承诺书
    /// </summary>
    public class Load_HomesteadCommitmentEntity : BaseEntity
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
        /// 承诺人姓名
        /// </summary>
        /// <returns></returns>
        [Column("COMMITMENTNAME")]
        public string CommitmentName { get; set; }
        /// <summary>
        /// 需求原因
        /// </summary>
        /// <returns></returns>
        [Column("DEMANDREASON")]
        public string DemandReason { get; set; }
        /// <summary>
        /// 乡镇名称
        /// </summary>
        /// <returns></returns>

        [Column("TOWNSHIPNAME")]
        public string TownshipName { get; set; }
        /// <summary>
        /// 村名称
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGENAME")]
        public string VillageName { get; set; }
        /// <summary>
        /// 组名称
        /// </summary>
        /// <returns></returns>
        [Column("GROUPNAME")]
        public string GroupName { get; set; }
        /// <summary>
        /// 时间单位月
        /// </summary>
        /// <returns></returns>
        [Column("TIMEUNITMONTH")]
        public int? TimeUnitMonth { get; set; }
        /// <summary>
        /// 时间单位日
        /// </summary>
        /// <returns></returns>
        [Column("TIMEUNITDAY")]
        public int? TimeUnitDay { get; set; }
        /// <summary>
        /// 承诺签字时间
        /// </summary>
        /// <returns></returns>
        [Column("COMMITMENTDATE")]
        public DateTime? CommitmentDate { get; set; }
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