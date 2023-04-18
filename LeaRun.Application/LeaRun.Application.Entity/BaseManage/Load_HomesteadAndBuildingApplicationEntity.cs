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
    /// 描 述：Load_HomesteadAndBuildingApplication
    /// </summary>
    public class Load_HomesteadAndBuildingApplicationEntity : BaseEntity
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
        /// 审批状态
        /// </summary>
        /// <returns></returns>
        [Column("APPROVESTATUS")]
        public string ApproveStatus { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTNAME")]
        public string ApplicantName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Column("GENDER")]
        public string Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        [Column("AGE")]
        public int? Age { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTNUMBER")]
        public string ContactNumber { get; set; }
        /// <summary>
        /// 身份照号码
        /// </summary>
        /// <returns></returns>
        [Column("IDNUMBER")]
        public string IDNumber { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        /// <returns></returns>
        [Column("REGISTEREDRESIDENCE")]
        public string RegisteredResidence { get; set; }
        /// <summary>
        /// 家庭成员姓名
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYMEMBERNAME")]
        public string FamilyMemberName { get; set; }
        /// <summary>
        /// 家庭成员与户主关系
        /// </summary>
        /// <returns></returns>
        [Column("RELATIONSHIPWITHHOUSEHOLDER")]
        public string RelationshipWithHouseholder { get; set; }
        /// <summary>
        /// 家庭成员省份证号码
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYMEMBERIDNUMBER")]
        public string FamilyMemberIDNumber { get; set; }
        /// <summary>
        /// 家庭成员户口所在地
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYMEMBERREGISTEREDRESIDENCE")]
        public string FamilyMemberRegisteredResidence { get; set; }
        /// <summary>
        /// 宅基地面积
        /// </summary>
        /// <returns></returns>
        [Column("LANDAREA")]
        public decimal? LandArea { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGAREA")]
        public decimal? BuildingArea { get; set; }
        /// <summary>
        /// 权属证号码
        /// </summary>
        /// <returns></returns>
        [Column("OWNERSHIPCERTIFICATENUMBER")]
        public string OwnershipCertificateNumber { get; set; }
        /// <summary>
        /// 宅基地情况
        /// </summary>
        /// <returns></returns>
        [Column("LANDSITUATION")]
        public string LandSituation { get; set; }
        /// <summary>
        /// 申请宅基地面积
        /// </summary>
        /// <returns></returns>
        [Column("APPLIEDLANDAREA")]
        public decimal? AppliedLandArea { get; set; }
        /// <summary>
        /// 申请占地面积
        /// </summary>
        /// <returns></returns>
        [Column("APPLIEDOCCUPIEDAREA")]
        public decimal? AppliedOccupiedArea { get; set; }
        /// <summary>
        /// 申请地址
        /// </summary>
        /// <returns></returns>
        [Column("APPLIEDADDRESS")]
        public string AppliedAddress { get; set; }
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
        /// 土地性质
        /// </summary>
        /// <returns></returns>
        [Column("LANDNATURE")]
        public string LandNature { get; set; }
        /// <summary>
        /// 建房类型
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGTYPE")]
        public string BuildingType { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        /// <returns></returns>
        [Column("APPLIEDBUILDINGAREA")]
        public decimal? AppliedBuildingArea { get; set; }
        /// <summary>
        /// 建筑层数
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGFLOORS")]
        public int? BuildingFloors { get; set; }
        /// <summary>
        /// 建筑高度
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGHEIGHT")]
        public decimal? BuildingHeight { get; set; }
        /// <summary>
        /// 是否已征求意见
        /// </summary>
        /// <returns></returns>
        [Column("CONSULTATIONSOUGHT")]
        public bool? ConsultationSought { get; set; }
        /// <summary>
        /// 申请理由
        /// </summary>
        /// <returns></returns>
        [Column("APPLICATIONREASON")]
        public string ApplicationReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string Remarks { get; set; }
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