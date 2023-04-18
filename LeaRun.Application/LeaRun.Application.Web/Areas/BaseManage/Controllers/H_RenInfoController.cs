using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System;
using LeaRun.Application.Code;
using System.Data;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-03 18:04
    /// 描 述：H_RenInfo
    /// </summary>
    public class H_RenInfoController : MvcControllerBase
    {
        private H_RenInfoBLL h_reninfobll = new H_RenInfoBLL();
        private H_HouseBLL h_housebll = new H_HouseBLL();
        private H_RenInfoHisBLL h_reninfohisbll = new H_RenInfoHisBLL();
        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_RenInfoIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult H_RenInfoIndex2()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_RenInfoForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult H_RenInfoIndexYC()
        {
            return View();
        }
        [HttpGet]
        public ActionResult H_RenInfoIndexCF()
        {
            return View();
        }
        [HttpGet]
        public ActionResult H_RenInfoDel()
        {
            return View();
        }
         [HttpGet]
        public ActionResult H_RenInfoZhu()
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
            var data = h_reninfobll.GetPageList(pagination, queryJson);
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
        public ActionResult GetPageListJsonCF(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = h_reninfobll.GetPageListCF(pagination, queryJson);
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
        public ActionResult GetPageListJson3(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = h_reninfobll.GetPageList3(pagination, queryJson);
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
        public ActionResult GetPageListJson2(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = h_reninfobll.GetPageList2(pagination,queryJson);
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
            var data = h_reninfobll.GetList(queryJson);
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
            var data = h_reninfobll.GetEntity(keyValue);
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
        public ActionResult RemoveForm(string keyValue, string Reson)
        {
            var entity = h_reninfobll.GetEntity(keyValue);
            entity.IsDeleted = "删除待审核";
            entity.DeletedNote = Reson;
            entity.DeleteDate = DateTime.Now;
            entity.DeleteName = OperatorProvider.Provider.Current().Account;
            h_reninfobll.SaveForm(keyValue, entity);
            return Success("删除成功。");

            //H_RenInfoEntity rne = h_reninfobll.GetEntity(keyValue);
            //H_RenInfoHisEntity entity = new H_RenInfoHisEntity();
            //entity.Address = rne.Address;
            //entity.AllAddress = rne.AllAddress;
            //entity.Arear = rne.Arear;
            //entity.ArearNumber = rne.ArearNumber;
            //entity.CodeNumber = rne.CodeNumber;
            //entity.CQRen = rne.CQRen;
            //entity.HJInfo = rne.HJInfo;
            //entity.HouseType = rne.HouseType;
            //entity.IDCard = rne.IDCard;
            //entity.ImpRen = rne.ImpRen;
            //entity.JTQingKuang = rne.JTQingKuang;
            //entity.JZNumber = rne.JZNumber;
            //entity.JZRenName = rne.JZRenName;
            //entity.JZRenType = rne.JZRenType;
            //entity.Note = rne.Note;
            //entity.Phone = rne.Phone;
            //entity.Phone2 = rne.Phone2;
            //entity.Sex = rne.Sex;
            //entity.SJJZAddress = rne.SJJZAddress;
            //entity.WordAddress = rne.WordAddress;
            //entity.ZhiYe = rne.ZhiYe;
            //entity.CreateName = OperatorProvider.Provider.Current().Account;
            //entity.CreateDate = DateTime.Now;
            //entity.Status = "删除";
            //entity.ShenName = Reson;
            //h_reninfohisbll.SaveForm("", entity);
            //h_reninfobll.RemoveForm(keyValue);
            //return Success("删除成功。");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ZXForm(string keyValue, string Reson)
        {
            var entity = h_reninfobll.GetEntity(keyValue);
            entity.IsDeleted = "删除待审核";
            entity.DeletedNote = Reson;
            entity.DeleteDate = DateTime.Now;
            entity.DeleteName = OperatorProvider.Provider.Current().Account;
            h_reninfobll.SaveForm(keyValue, entity);
            return Success("删除成功。");

            //H_RenInfoEntity rne = h_reninfobll.GetEntity(keyValue);


            //var entity = h_reninfobll.GetEntity(keyValue);
            //entity.IsDeleted = "注销待审核";
            //entity.DeletedNote = Reson;
            //h_reninfobll.SaveForm(keyValue, entity);
            //return Success("注销成功。");
            //H_RenInfoEntity rne = h_reninfobll.GetEntity(keyValue);
            //H_RenInfoHisEntity entity = new H_RenInfoHisEntity();
            //entity.Address = rne.Address;
            //entity.AllAddress = rne.AllAddress;
            //entity.Arear = rne.Arear;
            //entity.ArearNumber = rne.ArearNumber;
            //entity.CodeNumber = rne.CodeNumber;
            //entity.CQRen = rne.CQRen;
            //entity.HJInfo = rne.HJInfo;
            //entity.HouseType = rne.HouseType;
            //entity.IDCard = rne.IDCard;
            //entity.ImpRen = rne.ImpRen;
            //entity.JTQingKuang = rne.JTQingKuang;
            //entity.JZNumber = rne.JZNumber;
            //entity.JZRenName = rne.JZRenName;
            //entity.JZRenType = rne.JZRenType;
            //entity.Note = rne.Note;
            //entity.Phone = rne.Phone;
            //entity.Phone2 = rne.Phone2;
            //entity.Sex = rne.Sex;
            //entity.SJJZAddress = rne.SJJZAddress;
            //entity.WordAddress = rne.WordAddress;
            //entity.ZhiYe = rne.ZhiYe;
            //entity.CreateName = OperatorProvider.Provider.Current().Account;
            //entity.CreateDate = DateTime.Now;
            //entity.Status = "注销";
            //entity.ShenName = Reson;
            //h_reninfohisbll.SaveForm("", entity);
            //h_reninfobll.RemoveForm(keyValue);
            //return Success("注销成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, H_RenInfoEntity entity)
        {
            if (entity.JZRenType == "老宅" && string.IsNullOrEmpty(entity.SJJZAddress))
            {
                return Error("老宅人员必须填写具体居住地址！");
            }
            else
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    H_RenInfoEntity rne = new H_RenInfoEntity();
                    rne = h_reninfobll.GetEntity(keyValue);
                    H_RenInfoHisEntity entity2 = new H_RenInfoHisEntity();
                    if (NullToString(rne.Address).Replace("&nbsp;", "") != NullToString(entity.Address).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 地址 ";
                        //entity2.ShenName += " 地址" + NullToString(rne.Address).Replace("&nbsp;", "") + "—" + NullToString(entity.Address).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.Arear).Replace("&nbsp;", "") != NullToString(entity.Arear).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 村社区 ";
                        //entity2.ShenName += " 村社区" + NullToString(rne.Arear).Replace("&nbsp;", "") + "—" + NullToString(entity.Arear).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.ArearNumber).Replace("&nbsp;", "") != NullToString(entity.ArearNumber).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 网格编号 ";
                        //entity2.ShenName +=  " 网格编号" + NullToString(rne.ArearNumber).Replace("&nbsp;", "") + "—" + NullToString(entity.ArearNumber).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.CodeNumber).Replace("&nbsp;", "") != NullToString(entity.CodeNumber).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 二维码门牌 ";
                        //entity2.ShenName += " 二维码门牌" + NullToString(rne.CodeNumber).Replace("&nbsp;", "") + "—" + NullToString(entity.CodeNumber).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.CQRen).Replace("&nbsp;", "") != NullToString(entity.CQRen).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 产权人 ";
                        //entity2.ShenName +=  " 产权人" + NullToString(rne.CQRen).Replace("&nbsp;", "") + "—" + NullToString(entity.CQRen).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.HJInfo).Replace("&nbsp;", "") != NullToString(entity.HJInfo).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 户籍信息 ";
                        //entity2.ShenName +=  " 户籍信息" + NullToString(rne.HJInfo).Replace("&nbsp;", "") + "—" + NullToString(entity.HJInfo).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.HouseType).Replace("&nbsp;", "") != NullToString(entity.HouseType).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 房屋类型 ";
                        //entity2.ShenName +=  " 房屋类型" + NullToString(rne.HouseType).Replace("&nbsp;", "") + "—" + NullToString(entity.HouseType).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.IDCard).Replace("&nbsp;", "") != NullToString(entity.IDCard).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 身份证 ";
                        //entity2.ShenName +=  " 身份证" + NullToString(rne.IDCard).Replace("&nbsp;", "") + "—" + NullToString(entity.IDCard).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.ImpRen).Replace("&nbsp;", "") != NullToString(entity.ImpRen).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 重点人员 ";
                        //entity2.ShenName +=  " 重点人员" + NullToString(rne.ImpRen).Replace("&nbsp;", "") + "—" + NullToString(entity.ImpRen).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.JTQingKuang).Replace("&nbsp;", "") != NullToString(entity.JTQingKuang).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 家庭情况 ";
                        //entity2.ShenName +=  " 家庭情况" + NullToString(rne.JTQingKuang).Replace("&nbsp;", "") + "—" + NullToString(entity.JTQingKuang).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.JZNumber).Replace("&nbsp;", "") != NullToString(entity.JZNumber).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 居住证 ";
                        //entity2.ShenName +=  " 居住证" + NullToString(rne.JZNumber).Replace("&nbsp;", "") + "—" + NullToString(entity.JZNumber).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.JZRenName).Replace("&nbsp;", "") != NullToString(entity.JZRenName).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 姓名 ";
                        //entity2.ShenName +=  " 姓名" + NullToString(rne.JZRenName).Replace("&nbsp;", "") + "—" + NullToString(entity.JZRenName).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.JZRenType).Replace("&nbsp;", "") != NullToString(entity.JZRenType).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 居住类型 ";
                        //entity2.ShenName +=  " 居住类型" + NullToString(rne.JZRenType).Replace("&nbsp;", "") + "—" + NullToString(entity.JZRenType).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.Note).Replace("&nbsp;", "") != NullToString(entity.Note).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 备注 ";
                        //entity2.ShenName +=  " 备注" + NullToString(rne.Note).Replace("&nbsp;", "") + "—" + NullToString(entity.Note).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.Phone).Replace("&nbsp;", "") != NullToString(entity.Phone).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 电话 ";
                        //entity2.ShenName +=  " 电话" + NullToString(rne.Phone).Replace("&nbsp;", "") + "—" + NullToString(entity.Phone).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.Phone2).Replace("&nbsp;", "") != NullToString(entity.Phone2).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 电话 ";
                        //entity2.ShenName +=  " 电话" + NullToString(rne.Phone2).Replace("&nbsp;", "") + "—" + NullToString(entity.Phone2).Replace("&nbsp;", "") + ' ';
                    }              
                    if (NullToString(rne.Sex).Replace("&nbsp;", "") != NullToString(entity.Sex).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 性别 ";
                        //entity2.ShenName +=  " 性别" + NullToString(rne.Sex).Replace("&nbsp;", "") + "—" + NullToString(entity.Sex).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.SJJZAddress).Replace("&nbsp;", "") != NullToString(entity.SJJZAddress).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 实际居住地址 ";
                        //entity2.ShenName +=  " 实际居住地址" + NullToString(rne.SJJZAddress).Replace("&nbsp;", "") + "—" + NullToString(entity.SJJZAddress).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.WordAddress).Replace("&nbsp;", "") != NullToString(entity.WordAddress).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 工作地址 ";
                        //entity2.ShenName +=  " 工作地址" + NullToString(rne.WordAddress).Replace("&nbsp;", "") + "—" + NullToString(entity.WordAddress).Replace("&nbsp;", "") + ' ';
                    }
                    if (NullToString(rne.ZhiYe).Replace("&nbsp;", "") != NullToString(entity.ZhiYe).Replace("&nbsp;", ""))
                    {
                        entity2.ShenName += " 职业 ";
                        //entity2.ShenName += " 职业" + NullToString(rne.ZhiYe).Replace("&nbsp;", "") + "—" + NullToString(entity.ZhiYe).Replace("&nbsp;", "") + ' ';
                    }
                    entity2.Address = NullToString(rne.Address).Replace("&nbsp;", "");
                    entity2.AllAddress = NullToString(rne.AllAddress).Replace("&nbsp;", "");
                    entity2.Arear = NullToString(rne.Arear).Replace("&nbsp;", "");
                    entity2.ArearNumber = NullToString(rne.ArearNumber).Replace("&nbsp;", "");
                    entity2.CodeNumber = NullToString(rne.CodeNumber).Replace("&nbsp;", "");
                    entity2.CQRen = NullToString(rne.CQRen).Replace("&nbsp;", "");
                    entity2.HJInfo = NullToString(rne.HJInfo).Replace("&nbsp;", "");
                    entity2.HouseType = NullToString(rne.HouseType).Replace("&nbsp;", "");
                    entity2.IDCard = NullToString(rne.IDCard).Replace("&nbsp;", "");
                    entity2.ImpRen = NullToString(rne.ImpRen).Replace("&nbsp;", "");
                    entity2.JTQingKuang = NullToString(rne.JTQingKuang).Replace("&nbsp;", "");
                    entity2.JZNumber = NullToString(rne.JZNumber).Replace("&nbsp;", "");
                    entity2.JZRenName = NullToString(rne.JZRenName).Replace("&nbsp;", "");
                    entity2.JZRenType = NullToString(rne.JZRenType).Replace("&nbsp;", "");
                    entity2.Note = NullToString(rne.Note).Replace("&nbsp;", "");
                    entity2.Phone = NullToString(rne.Phone).Replace("&nbsp;", "");
                    entity2.Phone2 = NullToString(rne.Phone2).Replace("&nbsp;", "");
                    entity2.Sex = NullToString(rne.Sex).Replace("&nbsp;", "");
                    entity2.SJJZAddress = NullToString(rne.SJJZAddress).Replace("&nbsp;", "");
                    entity2.WordAddress = NullToString(rne.WordAddress).Replace("&nbsp;", "");
                    entity2.ZhiYe = NullToString(rne.ZhiYe).Replace("&nbsp;", "");
                    entity2.CreateName = OperatorProvider.Provider.Current().Account;
                    entity2.CreateDate = DateTime.Now;
                    
                    entity2.Status = "修改";
                    h_reninfohisbll.SaveForm("", entity2);
                }
                entity.DeleteDate = DateTime.Now;
                h_reninfobll.SaveForm(keyValue, entity);
                return Success("操作成功。");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm1(string keyValue, string Reson)
        {
            var rne = h_reninfobll.GetEntity(keyValue);
            var IsDeleted = rne.IsDeleted.ToString();
          
                IsDeleted = "删除";
          
            var DeletedNote = rne.DeletedNote.ToString();
            //H_RenInfoEntity rne = h_reninfobll.GetEntity(keyValue);
            H_RenInfoHisEntity entity = new H_RenInfoHisEntity();
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
            entity.CreateName = rne.DeleteName;
            entity.CreateDate = rne.DeleteDate;
            entity.Status = IsDeleted;
            entity.ShenName = OperatorProvider.Provider.Current().Account;
            entity.ShenDate = DateTime.Now;
            entity.DeletedNote = rne.DeletedNote;
            h_reninfohisbll.SaveForm("", entity);
            h_reninfobll.RemoveForm(keyValue);
            return Success("成功。");
        
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm2(string keyValue, string Reson)
        {
            var entity = h_reninfobll.GetEntity(keyValue);
            entity.IsDeleted = "正常";
            entity.DeletedNote = "";
            h_reninfobll.SaveForm(keyValue, entity);
            return Success("审核成功。");

        }
        #endregion
        public void ExportToExcel(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string sql = @" select  Arear as '村社区',ArearNumber as '网格号',AllAddress as '详细地址',HouseType as '房屋类型',
JZRenName as '姓名',Sex as '性别',JZRenType as '居住类型',IDCard as '身份证',JZNumber as '居住号',
Phone as '电话',SJJZAddress as '实际居住地',HJInfo as '户籍地',ZhiYe as '职业',WordAddress as '工作地',
ImpRen as '重点人员',JTQingKuang as '具体情况',Note as '备注' from H_RenInfo where 1=1";
            if (!queryParam["Arear"].IsEmpty())
            {
                string role = queryParam["Arear"].ToString();
                if (role == "经发局")
                {
                }
                else
                {
                    string txt_Arear = queryParam["Arear"].ToString();
                    sql = sql + " and arear='" + txt_Arear + "' ";
                }
            }
            if (!queryParam["ArearNumber"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["ArearNumber"].ToString();
                sql = sql + " and ArearNumber='" + txt_ArearNumber + "' ";
            }
            if (!queryParam["Address"].IsEmpty())
            {
                string txt_Address = queryParam["Address"].ToString();
                sql = sql + " and AllAddress like '%" + txt_Address + "%' ";
            }
            if (!queryParam["Phone"].IsEmpty())
            {
                string Phone = queryParam["Phone"].ToString();
                sql = sql + " and Phone='" + Phone + "' ";
            }
            if (!queryParam["JTQingKuang"].IsEmpty())
            {
                string JTQingKuang = queryParam["JTQingKuang"].ToString();
          
                sql = sql + " and JTQingKuang='" + JTQingKuang + "' ";
            }

            if (!queryParam["HouseType"].IsEmpty())
            {
                string txt_HouseType = queryParam["HouseType"].ToString();
                sql = sql + " and HouseType='" + txt_HouseType + "' ";
            }
            if (!queryParam["CodeNumber"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["CodeNumber"].ToString();
                sql = sql + " and CodeNumber='" + txt_CodeNumber + "' ";
            }
            if (!queryParam["CQRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["CQRen"].ToString();
                sql = sql + " and CQRen='" + txt_CQRen + "' ";
            }
            if (!queryParam["JZRenName"].IsEmpty())
            {
                string txt_Arear = queryParam["JZRenName"].ToString();
                sql = sql + " and JZRenName='" + txt_Arear + "' ";
            }
            if (!queryParam["IDCard"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["IDCard"].ToString();
                sql = sql + " and IDCard='" + txt_ArearNumber + "' ";
             
            }
            if (!queryParam["SJJZAddress"].IsEmpty())
            {
                string txt_Address = queryParam["SJJZAddress"].ToString();
                sql = sql + " and SJJZAddress='" + txt_Address + "' ";

            }
            if (!queryParam["HJInfo"].IsEmpty())
            {
                string txt_HouseType = queryParam["HJInfo"].ToString();
                sql = sql + " and HJInfo='" + txt_HouseType + "' ";

            }
            if (!queryParam["ZhiYe"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["ZhiYe"].ToString();
                sql = sql + " and ZhiYe='" + txt_CodeNumber + "' ";

            }
            if (!queryParam["ImpRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["ImpRen"].ToString();
                sql = sql + " and ImpRen='" + txt_CQRen + "' ";

            }
            if (!queryParam["JZRenType"].IsEmpty())
            {
                string txt_CQRen = queryParam["JZRenType"].ToString();
                sql = sql + " and JZRenType='" + txt_CQRen + "' ";

            }
            if (!queryParam["DangYuan"].IsEmpty())
            {
                string DangYuan = queryParam["DangYuan"].ToString();
                sql = sql + " and DangYuan='" + DangYuan + "' ";
            }
            if (!queryParam["YiMiao"].IsEmpty())
            {
                string YiMiao = queryParam["YiMiao"].ToString();

                sql = sql + " and YiMiao='" + YiMiao + "' ";
            }
            if (!queryParam["role"].IsEmpty())
            {
                string role = queryParam["role"].ToString();
                if (role == "经发局")
                {
           
                    sql = sql + " and ID like '%YYYYQY%' ";
                }
            }
            //var data = projectDS.GetProjectMessage(11);
            DataTable data = new DataTable();
            var data1 = h_housebll.getlist1(sql);

            ExcelHelper.ExportByWeb(data1, String.Empty, "人员列表.xlsx");

            //return Success("导出成功");
        }
    }
}
