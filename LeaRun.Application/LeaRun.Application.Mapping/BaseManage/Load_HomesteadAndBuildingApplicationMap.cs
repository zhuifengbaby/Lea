﻿using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-05-04 13:25
    /// 描 述：Load_HomesteadAndBuildingApplication
    /// </summary>
    public class Load_HomesteadAndBuildingApplicationMap : EntityTypeConfiguration<Load_HomesteadAndBuildingApplicationEntity>
    {
        public Load_HomesteadAndBuildingApplicationMap()
        {
            #region 表、主键
            //表
            this.ToTable("Load_HomesteadAndBuildingApplication");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
