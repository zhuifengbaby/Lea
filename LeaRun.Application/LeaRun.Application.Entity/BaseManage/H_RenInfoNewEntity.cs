using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-14 20:42
    /// 描 述：H_RenInfoNew
    /// </summary>
    public class H_RenInfoNewEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
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
        /// 房屋性质
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
        /// 居住人姓名
        /// </summary>
        /// <returns></returns>
        public string JZRenName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Sex { get; set; }
        /// <summary>
        /// 居住人员类别
        /// </summary>
        /// <returns></returns>
        public string JZRenType { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <returns></returns>
        public string IDCard { get; set; }
        /// <summary>
        /// 居住证号码
        /// </summary>
        /// <returns></returns>
        public string JZNumber { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 实际居住地址
        /// </summary>
        /// <returns></returns>
        public string SJJZAddress { get; set; }
        /// <summary>
        /// 户籍信息
        /// </summary>
        /// <returns></returns>
        public string HJInfo { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        /// <returns></returns>
        public string ZhiYe { get; set; }
        /// <summary>
        /// 工作所在地
        /// </summary>
        /// <returns></returns>
        public string WordAddress { get; set; }
        /// <summary>
        /// 重点人员
        /// </summary>
        /// <returns></returns>
        public string ImpRen { get; set; }
        /// <summary>
        /// 具体情况
        /// </summary>
        /// <returns></returns>
        public string JTQingKuang { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Note { get; set; }
        /// <summary>
        /// AllAddress
        /// </summary>
        /// <returns></returns>
        public string AllAddress { get; set; }
        /// <summary>
        /// 创建类型
        /// </summary>
        /// <returns></returns>
        public string CreateType { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string CreateName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        /// <returns></returns>
        public string ShenName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ShenDate { get; set; }
        public string Phone2 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
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