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
    public class H_RenInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string Id { get; set; }
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
        /// 居住人姓名
        /// </summary>
        /// <returns></returns>
        [Column("JZRENNAME")]
        public string JZRenName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Column("SEX")]
        public string Sex { get; set; }
        /// <summary>
        /// 居住人员类别
        /// </summary>
        /// <returns></returns>
        [Column("JZRENTYPE")]
        public string JZRenType { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <returns></returns>
        [Column("IDCARD")]
        public string IDCard { get; set; }
        /// <summary>
        /// 居住证号码
        /// </summary>
        /// <returns></returns>
        [Column("JZNUMBER")]
        public string JZNumber { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string Phone { get; set; }
        /// <summary>
        /// 实际居住地址
        /// </summary>
        /// <returns></returns>
        [Column("SJJZADDRESS")]
        public string SJJZAddress { get; set; }
        /// <summary>
        /// 户籍信息
        /// </summary>
        /// <returns></returns>
        [Column("HJINFO")]
        public string HJInfo { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        /// <returns></returns>
        [Column("ZHIYE")]
        public string ZhiYe { get; set; }
        /// <summary>
        /// 工作所在地
        /// </summary>
        /// <returns></returns>
        [Column("WORDADDRESS")]
        public string WordAddress { get; set; }
        /// <summary>
        /// 重点人员
        /// </summary>
        /// <returns></returns>
        [Column("IMPREN")]
        public string ImpRen { get; set; }
        /// <summary>
        /// 具体情况
        /// </summary>
        /// <returns></returns>
        [Column("JTQINGKUANG")]
        public string JTQingKuang { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("NOTE")]
        public string Note { get; set; }
        /// <summary>
        /// AllAddress
        /// </summary>
        /// <returns></returns>
        [Column("ALLADDRESS")]
        public string AllAddress { get; set; }

        [Column("Phone2")]
        public string Phone2 { get; set; }


        [Column("DangYuan")]
        public string DangYuan { get; set; }

        [Column("YiMiao")]
        public string YiMiao { get; set; }

        [Column("IsDeleted")]
        public string IsDeleted { get; set; }

        [Column("DeletedNote")]
        public string DeletedNote { get; set; }

        [Column("DeleteDate")]
        public DateTime DeleteDate { get; set; }
        [Column("DeleteName")]
        public string DeleteName { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
        }
        #endregion
    }
}