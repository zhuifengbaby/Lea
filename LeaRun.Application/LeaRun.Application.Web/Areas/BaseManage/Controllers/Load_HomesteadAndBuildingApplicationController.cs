using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：XY
    /// 日 期：2023-04-15 14:52
    /// 描 述：H_MemberNew
    /// </summary>
    public class Load_HomesteadAndBuildingApplicationController : MvcControllerBase
    {
        private Load_HomesteadAndBuildingApplicationBLL load_homesteadandbuildingapplicationbll = new Load_HomesteadAndBuildingApplicationBLL();
        private Load_HomesteadExamineApproveBLL load_homesteadexamineapprovebll = new Load_HomesteadExamineApproveBLL();
        public ActionResult Load_HomesteadAndBuildingApplicationIndex()
        {
            return View();
        }

        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Load_HomesteadAndBuildingApplicationIndexNewForm()
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
            var data = load_homesteadandbuildingapplicationbll.GetPageList(pagination, queryJson);
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
            var data = load_homesteadandbuildingapplicationbll.GetList(queryJson);
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
            var data = load_homesteadandbuildingapplicationbll.GetEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, Load_HomesteadAndBuildingApplicationEntity entity)
        {
            load_homesteadandbuildingapplicationbll.SaveFormADD(keyValue, entity);
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
            load_homesteadandbuildingapplicationbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 申报数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly] 
        public ActionResult SaveDataToApprove(string idNumber, Load_HomesteadExamineApproveEntity entity)
        {
            load_homesteadexamineapprovebll.SaveFormADD(idNumber, entity);
            return Success("申报成功。");
        }

        [HttpPost]
        public ActionResult upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && file.ContentType.StartsWith("image/"))
            {
                // 获取文件名
                var fileName = Path.GetFileName(file.FileName);
                // 获取保存路径
                var savePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                // 将文件保存到本地
                file.SaveAs(savePath);
                // 返回上传成功的响应
                return Json(new { success = true });
            }
            // 返回上传失败的响应
            return Json(new { success = false });
        }
        #endregion
    }
}