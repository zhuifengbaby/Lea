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
    /// 描 述：农村宅基地辅房和附属设施验收意见表
    /// </summary>
    public class Load_AuxiliaryRoomBuildingAcceptanceEntity : BaseEntity
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
        /// 申请户主
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTHOLDER")]
        public string ApplicantHolder { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [Column("IDNUMBER")]
        public string IDNumber { get; set; }
        /// <summary>
        /// 乡村建设规划许可证号
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONLICENSENUMBER")]
        public string ConstructionLicenseNumber { get; set; }
        /// <summary>
        /// 施工负责人
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONMANAGER")]
        public string ConstructionManager { get; set; }
        /// <summary>
        /// 农村宅基地批准书号
        /// </summary>
        /// <returns></returns>
        [Column("HOMESTEADAPPROVALNUMBER")]
        public string HomesteadApprovalNumber { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        /// <returns></returns>
        [Column("COMMENCEMENTDATE")]
        public DateTime? CommencementDate { get; set; }
        /// <summary>
        /// 竣工日期
        /// </summary>
        /// <returns></returns>
        [Column("COMPLETIONDATE")]
        public DateTime? CompletionDate { get; set; }
        /// <summary>
        /// 村或社区意见
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEOPINION")]
        public string VillageOpinion { get; set; }
        /// <summary>
        /// 村或社区经办人
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEOPERATOR")]
        public string VillageOperator { get; set; }
        /// <summary>
        /// 村或社区经办时间
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEOPERATETIME")]
        public DateTime? VillageOperateTime { get; set; }
        /// <summary>
        /// 规划建设管理部门意见
        /// </summary>
        /// <returns></returns>
        [Column("PLANNINGMANAGEMENTOPINION")]
        public string PlanningManagementOpinion { get; set; }
        /// <summary>
        /// 规划建设管理部门经办人
        /// </summary>
        /// <returns></returns>
        [Column("PLANNINGMANAGEMENTOPERATOR")]
        public string PlanningManagementOperator { get; set; }
        /// <summary>
        /// 规划建设管理部门经办时间
        /// </summary>
        /// <returns></returns>
        [Column("PLANNINGMANAGEMENTOPERATETIME")]
        public DateTime? PlanningManagementOperateTime { get; set; }
        /// <summary>
        /// 自然资源部门意见
        /// </summary>
        /// <returns></returns>
        [Column("NATURALRESOURCEOPINION")]
        public string NaturalResourceOpinion { get; set; }
        /// <summary>
        /// 自然资源部门经办人
        /// </summary>
        /// <returns></returns>
        [Column("NATURALRESOURCEOPERATOR")]
        public string NaturalResourceOperator { get; set; }
        /// <summary>
        /// 自然资源部门经办时间
        /// </summary>
        /// <returns></returns>
        [Column("NATURALRESOURCEOPERATETIME")]
        public DateTime? NaturalResourceOperateTime { get; set; }
        /// <summary>
        /// 农业农村部门意见
        /// </summary>
        /// <returns></returns>
        [Column("AGRICULTURERURALOPINION")]
        public string AgricultureRuralOpinion { get; set; }
        /// <summary>
        /// 农业农村部门经办人
        /// </summary>
        /// <returns></returns>
        [Column("AGRICULTURERURALOPERATOR")]
        public string AgricultureRuralOperator { get; set; }
        /// <summary>
        /// 农业农村部门经办时间
        /// </summary>
        /// <returns></returns>
        [Column("AGRICULTURERURALOPERATETIME")]
        public DateTime? AgricultureRuralOperateTime { get; set; }
        /// <summary>
        /// 乡镇镇府验收意见
        /// </summary>
        /// <returns></returns>
        [Column("TOWNSHIPACCEPTANCEOPINION")]
        public string TownshipAcceptanceOpinion { get; set; }
        /// <summary>
        /// 乡镇镇府验收经办人
        /// </summary>
        /// <returns></returns>
        [Column("TOWNSHIPACCEPTANCEOPERATOR")]
        public string TownshipAcceptanceOperator { get; set; }
        /// <summary>
        /// 乡镇镇府验收经办时间
        /// </summary>
        /// <returns></returns>
        [Column("TOWNSHIPACCEPTANCEOPERATETIME")]
        public DateTime? TownshipAcceptanceOperateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// 辅房竣工平面简图
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONPLANDIAGRAM")]
        public string ConstructionPlanDiagram { get; set; }
        /// <summary>
        /// 户主姓名
        /// </summary>
        /// <returns></returns>
        [Column("OWNERNAME")]
        public string OwnerName { get; set; }
        /// <summary>
        /// 村组
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGEGROUP")]
        public string VillageGroup { get; set; }
        /// <summary>
        /// 绘制人
        /// </summary>
        /// <returns></returns>
        [Column("DRAWER")]
        public string Drawer { get; set; }
        /// <summary>
        /// 绘制时间
        /// </summary>
        /// <returns></returns>
        [Column("DRAWINGTIME")]
        public DateTime? DrawingTime { get; set; }
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