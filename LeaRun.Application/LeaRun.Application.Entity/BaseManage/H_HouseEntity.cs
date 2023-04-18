using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_House
    /// </summary>
    public class H_HouseEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 村居
        /// </summary>
        /// <returns></returns>
        [Column("AREAR")]
        public string Arear { get; set; }
        /// <summary>
        /// 网格名称
        /// </summary>
        /// <returns></returns>
        [Column("AREARNUMBER")]
        public string ArearNumber { get; set; }
        /// <summary>
        /// 坐落详址
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESS")]
        public string Address { get; set; }
        /// <summary>
        /// 房屋性质
        /// </summary>
        /// <returns></returns>
        [Column("HOUSETYPE")]
        public string HouseType { get; set; }
        /// <summary>
        /// 二维码门牌
        /// </summary>
        /// <returns></returns>
        [Column("CODENUMBER")]
        public string CodeNumber { get; set; }
        /// <summary>
        /// 产权人
        /// </summary>
        /// <returns></returns>
        [Column("CQREN")]
        public string CQRen { get; set; }
        /// <summary>
        /// 地址（全）
        /// </summary>
        /// <returns></returns>
        [Column("ALLADDRESS")]
        public string AllAddress { get; set; }
        /// <summary>
        /// AA
        /// </summary>
        /// <returns></returns>
        [Column("AA")]
        public string AA { get; set; }
        /// <summary>
        /// BB
        /// </summary>
        /// <returns></returns>
        [Column("BB")]
        public string BB { get; set; }
        /// <summary>
        /// CC
        /// </summary>
        /// <returns></returns>
        [Column("CC")]
        public string CC { get; set; }
        /// <summary>
        /// DD
        /// </summary>
        /// <returns></returns>
        [Column("DD")]
        public string DD { get; set; }
        /// <summary>
        /// EE
        /// </summary>
        /// <returns></returns>
        [Column("EE")]
        public string EE { get; set; }
        /// <summary>
        /// FF
        /// </summary>
        /// <returns></returns>
        [Column("FF")]
        public string FF { get; set; }
        /// <summary>
        /// GG
        /// </summary>
        /// <returns></returns>
        [Column("GG")]
        public string GG { get; set; }
        /// <summary>
        /// HH
        /// </summary>
        /// <returns></returns>
        [Column("HH")]
        public string HH { get; set; }

        [Column("IsDeleted")]
        public string IsDeleted { get; set; }

        [Column("DeletedNote")]
        public string DeletedNote { get; set; }


        [Column("DeleteDate")]
        public string DeleteDate { get; set; }
        [Column("DeleteName")]
        public string DeleteName { get; set; }
        [Column("Sort")]
        public string Sort { get; set; }
        [Column("Zhuang")]
        public string Zhuang { get; set; }
        [Column("NewArearNumber")]
        public string NewArearNumber { get; set; }
        [Column("OldArearNumber")]
        public string OldArearNumber { get; set; }
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