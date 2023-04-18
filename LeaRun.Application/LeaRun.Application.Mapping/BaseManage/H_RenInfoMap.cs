using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_House
    /// </summary>
    public class H_RenInfoMap : EntityTypeConfiguration<H_RenInfoEntity>
    {
        public H_RenInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("H_RenInfo");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
