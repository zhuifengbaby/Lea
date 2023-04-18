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
    public class H_ZhuMemberEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// FInterID
        /// </summary>
        /// <returns></returns>
        [Column("FINTERID")]
        public string FInterID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string Name { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        /// <returns></returns>
        [Column("SEX")]
        public string Sex { get; set; }
        /// <summary>
        /// CardNumber
        /// </summary>
        /// <returns></returns>
        [Column("CARDNUMBER")]
        public string CardNumber { get; set; }
        /// <summary>
        /// SheBaoNumber
        /// </summary>
        /// <returns></returns>
        [Column("SHEBAONUMBER")]
        public string SheBaoNumber { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string Phone { get; set; }
        /// <summary>
        /// WorkAdress
        /// </summary>
        /// <returns></returns>
        [Column("WORKADRESS")]
        public string WorkAdress { get; set; }
        /// <summary>
        /// HuGuanX
        /// </summary>
        /// <returns></returns>
        [Column("HJD")]
        public string HJD { get; set; }
        [Column("HuGuanX")]
        public string HuGuanX { get; set; }
        [Column("JuZhuDi")]
        public string JuZhuDi { get; set; }
        [Column("JuZhuNumber")]
        public string JuZhuNumber { get; set; }
        [Column("ZhuHu")]
        public string ZhuHu { get; set; }
        [Column("FHouseNumber")]
        public string FHouseNumber { get; set; }

        #endregion

        #region 扩展操作
        // <summary>
        // 新增调用
        // </summary>
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