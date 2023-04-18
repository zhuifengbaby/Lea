﻿using LeaRun.Application.Busines.BaseManage;
using LeaRun.Application.Entity.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using LeaRun.Util.WebControl.HomeEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    public class Load_AuxiliaryRoomCommitmentController : MvcControllerBase
    {
        private Load_AuxiliaryRoomCommitmentBLL load_axiliaryroomcommitmentBLBLL = new Load_AuxiliaryRoomCommitmentBLL(); 
        // GET: BaseManage/Load_AuxiliaryRoomCommitment
        public ActionResult AuxiliaryRoomCommitmentIndex()
        {
            return View();
        }
        public ActionResult AuxiliaryRoomCommitmentNewForm()
        {
            return View();
        }
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = load_axiliaryroomcommitmentBLBLL.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = load_axiliaryroomcommitmentBLBLL.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = load_axiliaryroomcommitmentBLBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, Load_AuxiliaryRoomCommitmentEntity entity)
        {
            entity.ApproveStatus = DeclarationStatus.ToBeDeclared.ToString();
            load_axiliaryroomcommitmentBLBLL.SaveFormADD(keyValue, entity);
            return Success("操作成功。");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            load_axiliaryroomcommitmentBLBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        #endregion
    }
}