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
    public class H_HouseExcelEntity : BaseEntity
    {
        #region 实体成员

        [Column("Address")]
        public string Address { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        /// <returns></returns>
        [Column("HuName")]
        public string HuName { get; set; }
        /// <summary>
        /// CardNumber
        /// </summary>
        /// <returns></returns>
        [Column("HuGuanX")]
        public string HuGuanX { get; set; }
        /// <summary>
        /// SheBaoNumber
        /// </summary>
        /// <returns></returns>
        [Column("CQZ")]
        public string CQZ { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        /// <returns></returns>
        [Column("Name")]
        public string Name { get; set; }
        /// <summary>
        /// WorkAdress
        /// </summary>
        /// <returns></returns>
        [Column("Sex")]
        public string Sex { get; set; }
        /// <summary>
        /// HuGuanX
        /// </summary>
        /// <returns></returns>
        [Column("CardNumber")]
        public string CardNumber { get; set; }

        [Column("SheBaoNumber")]
        public string SheBaoNumber { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }


        [Column("WorkAdress")]
        public string WorkAdress { get; set; }


        [Column("HJD")]
        public string HJD { get; set; }


        [Column("HouseType")]
        public string HouseType { get; set; }


        [Column("HouseStatus")]
        public string HouseStatus { get; set; }

        [Column("HouseTX")]
        public string HouseTX { get; set; }
        [Column("Area")]
        public Double? Area { get; set; }
        [Column("FeiFArea")]
        public Double? FeiFArea { get; set; }
        [Column("CQZNumber")]
        public string CQZNumber { get; set; }


        #endregion

        #region 扩展操作
     
        #endregion
    }
}