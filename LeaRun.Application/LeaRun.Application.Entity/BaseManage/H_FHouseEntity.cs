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
    public class H_FHouseEntity : BaseEntity
    {
        #region 实体成员
 
        [Column("ID")]
        public string ID { get; set; } 
        [Column("FInterID")]
        public string FInterID { get; set; }

        [Column("FHType")]
        public string FHType { get; set; }
 
        [Column("FHTX")]
        public string FHTX { get; set; }
  
        [Column("Area")]
        public Double? Area { get; set; }

        [Column("FHStatus")]
        public string FHStatus { get; set; }

        [Column("FQty")]
        public int? FQty { get; set; }

        [Column("Number")]
        public string Number { get; set; }
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