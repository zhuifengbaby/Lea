using System;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class H_ComEntity : BaseEntity
    {
        #region 实体成员
 
        [Column("ID")]
        public string ID { get; set; }
        [Column("ParentId")]
        public string ParentId { get; set; }

        [Column("ComName")]
        public string ComName { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("WYName")]
        public string WYName { get; set; }

        [Column("FWDate")]
        public string FWDate { get; set; }

        [Column("SQDuty")]
        public string SQDuty { get; set; }

        [Column("SQDutyPhone")]
        public string SQDutyPhone { get; set; }

        [Column("WYDuty")]
        public string WYDuty { get; set; }

        [Column("WYDutyPhone")]
        public string WYDutyPhone { get; set; }


        [Column("WYLeader")]
        public string WYLeader { get; set; }

        [Column("WYLeadrPhone")]
        public string WYLeadrPhone { get; set; }

        [Column("HuCount")]
        public string HuCount { get; set; }

        [Column("Note")]
        public string Note { get; set; }
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