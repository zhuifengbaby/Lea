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
    /// 描 述：浮桥镇农村宅基地辅房和附属设施建设申请备案表
    /// </summary>
    public class Load_AuxiliaryRoomApplicationEntity : BaseEntity
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
        /// 申请人
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTNAME")]
        public string ApplicantName { get; set; }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string Village { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        /// <returns></returns>
        [Column("GROUPNAME")]
        public string GroupName { get; set; }
        /// <summary>
        /// 号
        /// </summary>
        /// <returns></returns>
        [Column("HOUSENUMBER")]
        public string HouseNumber { get; set; }
        /// <summary>
        /// 户口性质
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDNATURE")]
        public string HouseholdNature { get; set; }
        /// <summary>
        /// 宅基地批准书号
        /// </summary>
        /// <returns></returns>
        [Column("HOMESTEADAPPROVALNUMBER")]
        public string HomesteadApprovalNumber { get; set; }
        /// <summary>
        /// 申请人签字
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTSIGNATURE")]
        public string ApplicantSignature { get; set; }
        /// <summary>
        /// 申请人签字时间
        /// </summary>
        /// <returns></returns>
        [Column("APPLICANTSIGNATUREDATE")]
        public DateTime? ApplicantSignatureDate { get; set; }
        /// <summary>
        /// 申请辅房建设内容
        /// </summary>
        /// <returns></returns>
        [Column("AUXILIARYCONSTRUCTIONCONTENT")]
        public string AuxiliaryConstructionContent { get; set; }
        /// <summary>
        /// 总平面图
        /// </summary>
        /// <returns></returns>
        [Column("MASTERPLAN")]
        public string MasterPlan { get; set; }
        /// <summary>
        /// 村社区审核意见
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGECOMMUNITYREVIEW")]
        public string VillageCommunityReview { get; set; }
        /// <summary>
        /// 村社区经办人
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGECOMMUNITYAGENT")]
        public string VillageCommunityAgent { get; set; }
        /// <summary>
        /// 村社区经办时间
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGECOMMUNITYAGENTDATE")]
        public DateTime? VillageCommunityAgentDate { get; set; }
        /// <summary>
        /// 镇领导单位意见
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPUNITOPINION")]
        public string TownLeadershipUnitOpinion { get; set; }
        /// <summary>
        /// 镇领导经办人1
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENT1")]
        public string TownLeadershipAgent1 { get; set; }
        /// <summary>
        /// 镇领导经办时间1
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENTDATE1")]
        public DateTime? TownLeadershipAgentDate1 { get; set; }
        /// <summary>
        /// 镇领导经办人2
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENT2")]
        public string TownLeadershipAgent2 { get; set; }
        /// <summary>
        /// 镇领导经办时间2
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENTDATE2")]
        public DateTime? TownLeadershipAgentDate2 { get; set; }
        /// <summary>
        /// 镇领导经办人3
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENT3")]
        public string TownLeadershipAgent3 { get; set; }
        /// <summary>
        /// 镇领导经办时间3
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAGENTDATE3")]
        public DateTime? TownLeadershipAgentDate3 { get; set; }
        /// <summary>
        /// 镇领导核准意见
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAPPROVALOPINION")]
        public string TownLeadershipApprovalOpinion { get; set; }
        /// <summary>
        /// 镇领导小组核准经办人
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAPPROVALAGENT")]
        public string TownLeadershipApprovalAgent { get; set; }
        /// <summary>
        /// 镇领导小组核准经办时间
        /// </summary>
        /// <returns></returns>
        [Column("TOWNLEADERSHIPAPPROVALAGENTDATE")]
        public DateTime? TownLeadershipApprovalAgentDate { get; set; }
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