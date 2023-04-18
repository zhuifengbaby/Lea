using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-04-28 21:08
    /// 描 述：H_MemberNew
    /// </summary>
    public class H_MemberNewMap : EntityTypeConfiguration<H_MemberNewEntity>
    {
        public H_MemberNewMap()
        {
            #region 表、主键
            //表
            this.ToTable("H_MemberNew");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
