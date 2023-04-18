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
    /// 描 述：农村宅基地建房放样单
    /// </summary>
    public class Load_HomesteadLayoutFormEntity : BaseEntity
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
        /// 申请人姓名
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTNAME")]
        public string ApplicantName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTNUMBER")]
        public string ContactNumber { get; set; }
        /// <summary>
        /// 房屋位置
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGLOCATION")]
        public string BuildingLocation { get; set; }
        /// <summary>
        /// 批准书号
        /// </summary>
        /// <returns></returns>
        [Column("APPROVALNUMBER")]
        public string ApprovalNumber { get; set; }
        /// <summary>
        /// 定位放线成果图
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYINGANDMAPPINGRESULTIMAGE")]
        public string SurveyingAndMappingResultImage { get; set; }
        /// <summary>
        /// 申请建房人
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTFORBUILDING")]
        public string ApplicantForBuilding { get; set; }
        /// <summary>
        /// 申请建房人签字时间
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTFORBUILDINGSIGNDATE")]
        public DateTime? ApplicantForBuildingSignDate { get; set; }
        /// <summary>
        /// 建房施工单位
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONUNIT")]
        public string ConstructionUnit { get; set; }
        /// <summary>
        /// 施工单位签字时间
        /// </summary>
        /// <returns></returns>
        [Column("CONSTRUCTIONUNITSIGNDATE")]
        public DateTime? ConstructionUnitSignDate { get; set; }
        /// <summary>
        /// 所属社区
        /// </summary>
        /// <returns></returns>
        [Column("BELONGINGCOMMUNITY")]
        public string BelongingCommunity { get; set; }
        /// <summary>
        /// 社区签字时间
        /// </summary>
        /// <returns></returns>
        [Column("COMMUNITYSIGNDATE")]
        public DateTime? CommunitySignDate { get; set; }
        /// <summary>
        /// 农村农业部门
        /// </summary>
        /// <returns></returns>
        [Column("RURALAGRICULTURALDEPARTMENT")]
        public string RuralAgriculturalDepartment { get; set; }
        /// <summary>
        /// 农村农业部门签字时间
        /// </summary>
        /// <returns></returns>
        [Column("RURALAGRICULTURALDEPARTMENTSIGNDATE")]
        public DateTime? RuralAgriculturalDepartmentSignDate { get; set; }
        /// <summary>
        /// 镇建设规划管理部门
        /// </summary>
        /// <returns></returns>
        [Column("TOWNPLANNINGMANAGEMENTDEPARTMENT")]
        public string TownPlanningManagementDepartment { get; set; }
        /// <summary>
        /// 镇建设规划管理部门签字时间
        /// </summary>
        /// <returns></returns>
        [Column("TOWNPLANNINGMANAGEMENTDEPARTMENTSIGNDATE")]
        public DateTime? TownPlanningManagementDepartmentSignDate { get; set; }
        /// <summary>
        /// 其他相关单位
        /// </summary>
        /// <returns></returns>
        [Column("OTHERRELATEDUNITS")]
        public string OtherRelatedUnits { get; set; }
        /// <summary>
        /// 相关单位签字时间
        /// </summary>
        /// <returns></returns>
        [Column("RELATEDUNITSSIGNDATE")]
        public DateTime? RelatedUnitsSignDate { get; set; }
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