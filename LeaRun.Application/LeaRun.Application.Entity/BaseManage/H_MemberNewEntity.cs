using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-04-28 21:08
    /// 描 述：H_MemberNew
    /// </summary>
    public class H_MemberNewEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// FInterID
        /// </summary>
        /// <returns></returns>
        public string FInterID { get; set; }
        /// <summary>
        /// 村居
        /// </summary>
        /// <returns></returns>
        public string Arear { get; set; }
        /// <summary>
        /// 网格名称
        /// </summary>
        /// <returns></returns>
        public string ArearNumber { get; set; }
        /// <summary>
        /// 坐落详址
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        /// <returns></returns>
        public string HouseType { get; set; }
        /// <summary>
        /// 二维码门牌
        /// </summary>
        /// <returns></returns>
        public string CodeNumber { get; set; }
        /// <summary>
        /// 产权人
        /// </summary>
        /// <returns></returns>
        public string CQRen { get; set; }
        /// <summary>
        /// 居住人
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Sex { get; set; }
        /// <summary>
        /// 居住类型
        /// </summary>
        /// <returns></returns>
        public string JunType { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <returns></returns>
        public string CardNumber { get; set; }
        /// <summary>
        /// 社保编号
        /// </summary>
        /// <returns></returns>
        public string SheBaoNumber { get; set; }
        /// <summary>
        /// 居住号
        /// </summary>
        /// <returns></returns>
        public string JuZhuNumber { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 居住地
        /// </summary>
        /// <returns></returns>
        public string JuZhuDi { get; set; }
        /// <summary>
        /// 工作地址
        /// </summary>
        /// <returns></returns>
        public string WorkAdress { get; set; }
        /// <summary>
        /// 与户主关系
        /// </summary>
        /// <returns></returns>
        public string HuGuanX { get; set; }
        /// <summary>
        /// 户籍地
        /// </summary>
        /// <returns></returns>
        public string HJD { get; set; }
        /// <summary>
        /// 人员类型
        /// </summary>
        /// <returns></returns>
        public string RenType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Note { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        /// <returns></returns>
        public string CreateUser { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
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