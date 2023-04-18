using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManageH_HouseHisEntity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_HouseHis
    /// </summary>
    public class H_HouseHisMap : EntityTypeConfiguration<H_HouseHisEntity>
    {
        public H_HouseHisMap()
        {
            #region 表、主键
            //表
            this.ToTable("H_HouseHis");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
