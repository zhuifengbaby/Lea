using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.IO;
using LeaRun.Application.Code;
using System.Linq;
using System;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-19 19:44
    /// 描 述：H_HouseMain
    /// </summary>
    public class H_HouseMainController : MvcControllerBase
    {
        private H_HouseMainBLL h_housemainbll = new H_HouseMainBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseMainIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseMainForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
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
            var data = h_housemainbll.GetPageList(pagination, queryJson);
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

        [HttpGet]
        public ActionResult GetPageListJsonCom(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = h_housemainbll.GetPageListJsonCom(pagination, queryJson);
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
            
            var data = h_housemainbll.GetEntity(keyValue);
            var childData = h_housemainbll.GetDetails(keyValue);
            var childData2 = h_housemainbll.GetDetails2(keyValue);
            var childData4 = h_housemainbll.GetDetails4(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData,
                childEntity2 = childData2,
                childEntity4 = childData4
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
            var data = h_housemainbll.GetDetails(keyValue);
            return ToJsonResult(data);
        }

        [HttpGet]
        public ActionResult GetDetailsJson2(string keyValue)
        {
            var data = h_housemainbll.GetDetails2(keyValue);
            return ToJsonResult(data);
        }

        [HttpGet]
        public ActionResult GetPageListJson3(Pagination pagination, string queryJson)
        {
            var data = h_housemainbll.GetDetails3();
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
            h_housemainbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strChildEntitys, string strChildEntitys2,string strChildEntitys3, string fname)
        {
         
            var entity = strEntity.ToObject<H_HouseMainEntity>();
            entity.Url = fname;
            List<H_MemberEntity> childEntitys = strChildEntitys.ToList<H_MemberEntity>();
            List<H_ZhuMemberEntity> childEntitys2 = strChildEntitys2.ToList<H_ZhuMemberEntity>();
            List<H_FHouseEntity> childEntitys3 = strChildEntitys3.ToList<H_FHouseEntity>();
            h_housemainbll.SaveForm(keyValue, entity, childEntitys, childEntitys2, childEntitys3);
            return Success("操作成功。");
        }
        #endregion
        //文件上传 
        public ActionResult UploadFile(string keyValue)
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }
            string name = DateTime.Now.ToString("yyMMddHHmmssfff") + files[0].FileName;
            string FileEextension = Path.GetExtension(files[0].FileName);
            string UserId = OperatorProvider.Provider.Current().UserId;
            string virtualPath = string.Format("/Content/Redimages/{0}", name);
            string fullFileName = Server.MapPath("~" + virtualPath);
            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);
            return Success(name);
        }

        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var data = h_housemainbll.GetComList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.ComName.Contains(keyword), "ID");
            }
            var treeList = new List<TreeEntity>();
            foreach (H_ComEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.ID) == 0 ? false : true;
                tree.id = item.ID;
                tree.text = item.ComName;
                tree.value = item.ID;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }



    }
}
