using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using LeaRun.Application.Code;
using System;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_HouseNew
    /// </summary>
    public class H_HouseNewController : MvcControllerBase
    {
        private H_HouseNewBLL H_HouseNewbll = new H_HouseNewBLL();

        private H_HouseBLL H_Housebll = new H_HouseBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseNewIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult H_HouseNewIndex2()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseNewForm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult H_HouseNewFormADD()
        {
            return View();
        }
        #endregion

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
            var data = H_HouseNewbll.GetPageList(pagination, queryJson);
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
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = H_HouseNewbll.GetEntity(keyValue);
            var childData = H_HouseNewbll.GetDetails(data.AllAddress);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// 获取子表详细信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = H_HouseNewbll.GetDetails(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
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
            H_HouseNewbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="strEntity">实体对象</param>
        /// <param name="strChildEntitys">子表对象集</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            var entity = strEntity.ToObject<H_HouseNewEntity>();
            entity.CreateName = OperatorProvider.Provider.Current().Account;
            entity.CreateDate = DateTime.Now;
            List<H_RenInfoEntity> childEntitys = strChildEntitys.ToList<H_RenInfoEntity>();
            H_HouseNewbll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm(string keyValue)
        {
            H_HouseNewEntity rne = H_HouseNewbll.GetEntity(keyValue);
            H_HouseEntity entity = new H_HouseEntity();
            entity.Address = rne.Address;
            entity.AllAddress = rne.AllAddress;
            entity.Arear = rne.Arear;
            entity.ArearNumber = rne.ArearNumber;
            entity.AA = rne.AA;
            entity.CodeNumber = rne.CodeNumber;
            entity.CQRen = rne.CQRen;
            entity.HouseType = rne.HouseType;
            entity.HH = rne.HH;
            entity.IsDeleted = "正常";
            H_Housebll.SaveFormADD("", entity);
            rne.Status = "已审核";
            rne.ShenName = OperatorProvider.Provider.Current().Account;
            rne.ShenDate = DateTime.Now;
            H_HouseNewbll.SaveFormADD(keyValue, rne);
            return Success("审核成功。");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFormADD(string keyValue, string strEntity)
        {
            var entity = strEntity.ToObject<H_HouseNewEntity>();
            entity.AllAddress = entity.Arear + entity.Address;
            entity.Status = "未审核";
            entity.CreateDate = DateTime.Now;
            entity.CreateName = OperatorProvider.Provider.Current().Account;
            H_HouseNewbll.SaveFormADD(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
