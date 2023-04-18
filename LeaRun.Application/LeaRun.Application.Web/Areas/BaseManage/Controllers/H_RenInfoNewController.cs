using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using LeaRun.Application.Code;
using System;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-03 18:04
    /// 描 述：H_RenInfoNew
    /// </summary>
    public class H_RenInfoNewController : MvcControllerBase
    {
        private H_RenInfoNewBLL H_RenInfoNewbll = new H_RenInfoNewBLL();
        private H_HouseBLL h_housebll = new H_HouseBLL();
        private H_RenInfoBLL H_RenInfobll = new H_RenInfoBLL();


        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_RenInfoNewIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult H_RenInfoNewIndex2()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_RenInfoNewForm()
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
            var data = H_RenInfoNewbll.GetPageList(pagination, queryJson);
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
            var data = H_RenInfoNewbll.GetList(queryJson);
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
            var data = H_RenInfoNewbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }


        [HttpGet]
        public ActionResult GetListJson2(string queryJson)
        {
            var data = h_housebll.GetList(queryJson);
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
            H_RenInfoNewbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm(string keyValue)
        {
            H_RenInfoNewEntity rne = H_RenInfoNewbll.GetEntity(keyValue);
            H_RenInfoEntity entity = new H_RenInfoEntity();
            entity.Address = rne.Address;
            entity.AllAddress = rne.AllAddress;
            entity.Arear = rne.Arear;
            entity.ArearNumber = rne.ArearNumber;
            entity.CodeNumber = rne.CodeNumber;
            entity.CQRen = rne.CQRen;
            entity.HJInfo = rne.HJInfo;
            entity.HouseType = rne.HouseType;
            entity.IDCard = rne.IDCard;
            entity.ImpRen = rne.ImpRen;
            entity.JTQingKuang = rne.JTQingKuang;
            entity.JZNumber = rne.JZNumber;
            entity.JZRenName = rne.JZRenName;
            entity.JZRenType = rne.JZRenType;
            entity.Note = rne.Note;
            entity.Phone = rne.Phone;
            entity.Phone2 = rne.Phone2;
            entity.Sex = rne.Sex;
            entity.SJJZAddress = rne.SJJZAddress;
            entity.WordAddress = rne.WordAddress;
            entity.ZhiYe = rne.ZhiYe;
            entity.IsDeleted = "正常";
            entity.DeleteDate = DateTime.Now;
            H_RenInfobll.SaveForm("", entity);
            rne.Status = "已审核";
            rne.ShenName = OperatorProvider.Provider.Current().Account;
            rne.ShenDate = DateTime.Now;

            H_RenInfoNewbll.SaveForm(keyValue, rne);
            return Success("审核成功。");
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
        public ActionResult SaveForm(string keyValue, H_RenInfoNewEntity entity)
        {
            if (entity.JZRenType == "老宅" && string.IsNullOrEmpty(entity.SJJZAddress))
            {
                return Error("老宅人员必须填写具体居住地址！");
            }
            else
            {
                entity.Status = "未审核";
                entity.CreateName = OperatorProvider.Provider.Current().Account;
                entity.CreateDate = DateTime.Now;
                H_RenInfoNewbll.SaveForm(keyValue, entity);
                return Success("操作成功。");
            }
        }
        #endregion
    }
}
