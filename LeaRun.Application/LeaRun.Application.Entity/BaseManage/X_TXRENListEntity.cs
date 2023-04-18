using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-10-30 20:53
    /// 描 述：X_TXRENList
    /// </summary>
    public class X_TXRENListEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? ID { get; set; }
        /// <summary>
        /// 村社区
        /// </summary>
        /// <returns></returns>
        public string Arear { get; set; }
        /// <summary>
        /// 户主姓名
        /// </summary>
        /// <returns></returns>
        public string HuName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string TXStatus { get; set; }
        /// <summary>
        /// 退休适龄人员姓名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        public string Age { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <returns></returns>
        public string SFZNumber { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        /// <returns></returns>
        public string HJAddress { get; set; }
        /// <summary>
        /// 收入证明
        /// </summary>
        /// <returns></returns>
        public string TXYLJUrl { get; set; }
        /// <summary>
        /// 退休养老金
        /// </summary>
        /// <returns></returns>
        public string TXYLJ { get; set; }
        /// <summary>
        /// 确认时间
        /// </summary>
        /// <returns></returns>
        public DateTime? TXQDate { get; set; }
        /// <summary>
        /// FID
        /// </summary>
        /// <returns></returns>
        public string FID { get; set; }
        /// <summary>
        /// 相关证明
        /// </summary>
        /// <returns></returns>
        public string TXUrl { get; set; }
        /// <summary>
        /// 救助类别
        /// </summary>
        /// <returns></returns>
        public string JZTyoe { get; set; }
        /// <summary>
        /// 归档日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CreateDate = DateTime.Now;
                                }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = int.Parse(keyValue);
                                            }
        #endregion
    }
}