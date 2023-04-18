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
    /// 描 述：用于存储建房审批的记录
    /// </summary>
    public class Load_HomesteadExamineApproveEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public String ID { get; set; }

        /// <summary>
        /// 申请编号
        /// </summary>
        /// <returns></returns>
        [Column("ApplicationNo")]
        public String ApplicationNo { get; set; }

        /// <summary>
        /// 建房适用类型
        /// </summary>
        /// <returns></returns>
        [Column("APPLICABLETYPE")]
        public string ApplicableType { get; set; }
        /// <summary>
        /// 建房审批的当前状态
        /// </summary>
        /// <returns></returns>
        [Column("APPROVALSTATUS")]
        public string ApprovalStatus { get; set; }
        /// <summary>
        /// 申报状态
        /// </summary>
        /// <returns></returns>
        [Column("APPLICATIONSTATUS")]
        public string ApplicationStatus { get; set; }
        /// <summary>
        /// 申报人 
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANT")]
        public string Applicant { get; set; }
        /// <summary>
        /// 审批人员
        /// </summary>
        /// <returns></returns>
        [Column("APPROVER")]
        public string Approver { get; set; }
        /// <summary>
        /// 申报时间
        /// </summary>
        /// <returns></returns>
        [Column("APPLICATIONTIME")]
        public DateTime? ApplicationTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDTIME")]
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEDTIME")]
        public DateTime? UpdatedTime { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        /// <returns></returns>
        [Column("NOTE")]
        public string Note { get; set; }
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