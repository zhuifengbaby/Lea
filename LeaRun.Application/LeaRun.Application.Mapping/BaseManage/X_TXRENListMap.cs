using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-10-30 20:53
    /// 描 述：X_TXRENList
    /// </summary>
    public class X_TXRENListMap : EntityTypeConfiguration<X_TXRENListEntity>
    {
        public X_TXRENListMap()
        {
            #region 表、主键
            //表
            this.ToTable("X_TXRENList");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
