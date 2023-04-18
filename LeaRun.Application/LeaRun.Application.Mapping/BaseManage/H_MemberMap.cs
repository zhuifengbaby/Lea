using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-04-28 19:54
    /// 描 述：H_Member
    /// </summary>
    public class H_MemberMap : EntityTypeConfiguration<H_MemberEntity>
    {
        public H_MemberMap()
        {
            #region 表、主键
            //表
            this.ToTable("H_Member");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
