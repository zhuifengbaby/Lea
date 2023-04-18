using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using LeaRun.Application.Code;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Web;
using System.Text;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Web.Areas.BaseManage.Controllers
{
    public class ExcelHelper
    {
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            IDataFormat format = workbook.CreateDataFormat();
            ICellStyle dateStyle = workbook.CreateCellStyle();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            ICellStyle decimalStyle = workbook.CreateCellStyle();
            decimalStyle.DataFormat = format.GetFormat("N2");

            List<int> theExportCols = new List<int>();

            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式

                    if (!String.IsNullOrEmpty(strHeaderText))
                    {
                        IRow headerRow = sheet.CreateRow(rowIndex);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        //sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();

                        rowIndex++;
                    }

                    #endregion 表头及样式


                    #region 列头及样式

                    {
                        IRow headerRow = sheet.CreateRow(rowIndex);


                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            if (!String.IsNullOrEmpty(column.Caption))
                            {
                                ICell cell = headerRow.CreateCell(theExportCols.Count);
                                cell.SetCellValue(column.Caption);
                                cell.CellStyle = headStyle;
                                theExportCols.Add(column.Ordinal);
                            }
                            //else
                            //{
                            //    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            //}
                        }
                        //headerRow.Dispose();
                        rowIndex++;
                    }

                    #endregion 列头及样式
                }

                #endregion 新建表，填充表头，填充列头，样式


                #region 填充内容

                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int i = 0; i < theExportCols.Count; i++)
                {
                    var column = dtSource.Columns[theExportCols[i]];
                    //}
                    //foreach(DataColumn column in dtSource.Columns)
                    //{
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            if (DateTime.TryParse(drValue, out dateV))
                            {
                                newCell.SetCellValue(dateV);
                                newCell.CellStyle = dateStyle;//格式化显示
                            }
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                        case "System.Single":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            newCell.CellStyle = decimalStyle;
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }

                #endregion 填充内容

                rowIndex++;
            }

            for (int i = 0; i < theExportCols.Count; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }


        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
            curContext.Response.End();
        }


        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }
    }


    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-05-09 20:04
    /// 描 述：H_House
    /// </summary>
    public class H_HouseController : MvcControllerBase
    {
        private H_HouseBLL h_housebll = new H_HouseBLL();
        private H_HouseHisBLL h_househisbll = new H_HouseHisBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult H_HouseIndex2()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult H_HouseForm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult H_HouseFormADD()
        {
            return View();
        }


        [HttpGet]
        public ActionResult H_HouseZhu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult H_HouseDel()
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
            var data = h_housebll.GetPageList(pagination, queryJson);
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
            var data = h_housebll.GetPageList2(pagination, queryJson);
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
            var data = h_housebll.GetEntity(keyValue);
            var childData = h_housebll.GetDetails(data.AllAddress);
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
            var data = h_housebll.GetDetails(keyValue);
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
            //H_HouseHisEntity hh = new H_HouseHisEntity();
            var entity = h_housebll.GetEntity(keyValue);
            //hh.AA = entity.AA;
            //hh.Address = entity.Address;
            //hh.AllAddress = entity.AllAddress;
            //hh.Arear = entity.Arear;
            //hh.ArearNumber = entity.ArearNumber;
            //hh.BB = entity.BB;
            //hh.CC = entity.CC;
            //hh.CodeNumber = entity.CodeNumber;
            //hh.CQRen = entity.CQRen;
            //hh.CreateDate = DateTime.Now;
            //hh.CreateName = OperatorProvider.Provider.Current().Account;
            //hh.DD = entity.DD;
            //hh.EE = entity.EE;
            //hh.FF = entity.FF;
            //hh.HouseType = entity.HouseType;
            //hh.Status = "删除";
            //h_househisbll.SaveFormADD("", hh);
            entity.DeleteDate = DateTime.Now.ToString();
            entity.DeleteName = OperatorProvider.Provider.Current().Account;
            entity.IsDeleted = "删除待审核";
            entity.DeletedNote = Reson;
            h_housebll.SaveFormADD(keyValue, entity);
            //return Success("操作成功。");
            //h_housebll.RemoveForm(keyValue);
            return Success("删除成功。");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ZXForm(string keyValue, string Reson)
        {
            var entity = h_housebll.GetEntity(keyValue);
            entity.IsDeleted = "注销待审核";
            entity.DeletedNote = Reson;
            h_housebll.SaveFormADD(keyValue, entity);
            return Success("注销成功。");

            //H_HouseHisEntity hh = new H_HouseHisEntity();
            //var entity = h_housebll.GetEntity(keyValue);
            //hh.AA = entity.AA;
            //hh.Address = entity.Address;
            //hh.AllAddress = entity.AllAddress;
            //hh.Arear = entity.Arear;
            //hh.ArearNumber = entity.ArearNumber;
            //hh.BB = entity.BB;
            //hh.CC = entity.CC;
            //hh.CodeNumber = entity.CodeNumber;
            //hh.CQRen = entity.CQRen;
            //hh.CreateDate = DateTime.Now;
            //hh.CreateName = OperatorProvider.Provider.Current().Account;
            //hh.DD = entity.DD;
            //hh.EE = entity.EE;
            //hh.FF = entity.FF;
            //hh.HouseType = entity.HouseType;
            //hh.Status = "注销";
            //h_househisbll.SaveFormADD("", hh);
            //h_housebll.RemoveForm(keyValue);
            //return Success("注销。");
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strChildEntitys)
        {
            var entity = strEntity.ToObject<H_HouseEntity>();
            List<H_RenInfoEntity> childEntitys = strChildEntitys.ToList<H_RenInfoEntity>();
            h_housebll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFormADD(string keyValue, string strEntity)
        {
            var entity = strEntity.ToObject<H_HouseEntity>();
            entity.AllAddress = entity.Arear + entity.Address;
            if (!string.IsNullOrEmpty(keyValue))
            {
                H_HouseHisEntity HE = new H_HouseHisEntity();
                H_HouseEntity E = h_housebll.GetEntity(keyValue);
                if (NullToString(E.Address).Replace("&nbsp;", "") != NullToString(entity.Address).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "地址：" + NullToString(E.Address).Replace("&nbsp;", "") + "_" + NullToString(entity.Address).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.Arear).Replace("&nbsp;", "") != NullToString(entity.Arear).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "村社区：" + NullToString(E.Arear).Replace("&nbsp;", "") + "_" + NullToString(entity.Arear).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.ArearNumber).Replace("&nbsp;", "") != NullToString(entity.ArearNumber).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "网格号：" + NullToString(E.ArearNumber).Replace("&nbsp;", "") + "_" + NullToString(entity.ArearNumber).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.CodeNumber).Replace("&nbsp;", "") != NullToString(entity.CodeNumber).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "二维码门牌：" + NullToString(E.CodeNumber).Replace("&nbsp;", "") + "_" + NullToString(entity.CodeNumber).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.CQRen).Replace("&nbsp;", "") != NullToString(entity.CQRen).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "产权人：" + NullToString(E.CQRen).Replace("&nbsp;", "") + "_" + NullToString(entity.CQRen).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.HouseType).Replace("&nbsp;", "") != NullToString(entity.HouseType).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "房屋类型：" + NullToString(E.HouseType).Replace("&nbsp;", "") + "_" + NullToString(entity.HouseType).Replace("&nbsp;", "") + '。';
                }
                if (NullToString(E.HH).Replace("&nbsp;", "") != NullToString(entity.HH).Replace("&nbsp;", ""))
                {
                    HE.ShenName += "房屋状态：" + NullToString(E.HH).Replace("&nbsp;", "") + "_" + NullToString(entity.HH).Replace("&nbsp;", "") + '。';
                }
                HE.Address = NullToString(entity.Address).Replace("&nbsp;", "");
                HE.AllAddress = NullToString(entity.AllAddress).Replace("&nbsp;", "");
                HE.Arear = NullToString(entity.Arear).Replace("&nbsp;", "");
                HE.ArearNumber = NullToString(entity.ArearNumber).Replace("&nbsp;", "");
                HE.CodeNumber = NullToString(entity.CodeNumber).Replace("&nbsp;", "");
                HE.CQRen = NullToString(entity.CQRen).Replace("&nbsp;", "");
                HE.HH = NullToString(entity.HH).Replace("&nbsp;", "");
                HE.HouseType = NullToString(entity.HouseType).Replace("&nbsp;", "");
                HE.AllAddress = NullToString(entity.AllAddress).Replace("&nbsp;", "");
                HE.CreateName = OperatorProvider.Provider.Current().Account;
                HE.CreateDate = DateTime.Now;
                HE.Status = "修改";
                h_househisbll.SaveFormADD("", HE);
            }
            h_housebll.SaveFormADD(keyValue, entity);
            return Success("操作成功。");
        }
        static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm1(string keyValue, string Reson)
        {
            var entity = h_housebll.GetEntity(keyValue);
            var IsDeleted = entity.IsDeleted.ToString();
            IsDeleted = "删除";
            var DeletedNote = entity.DeletedNote.ToString();
            H_HouseHisEntity hh = new H_HouseHisEntity();
            hh.AA = entity.AA;
            hh.Address = entity.Address;
            hh.AllAddress = entity.AllAddress;
            hh.Arear = entity.Arear;
            hh.ArearNumber = entity.ArearNumber;
            hh.BB = entity.BB;
            hh.CC = entity.CC;
            hh.CodeNumber = entity.CodeNumber;
            hh.CQRen = entity.CQRen;
            hh.CreateDate = Convert.ToDateTime(entity.DeleteDate);
            hh.CreateName = entity.DeleteName;
            hh.DD = entity.DD;
            hh.EE = entity.EE;
            hh.FF = entity.FF;
            hh.HouseType = entity.HouseType;
            hh.Status = "删除";
            hh.DeletedNote = DeletedNote;
            hh.ShenDate = DateTime.Now;
            hh.ShenName = OperatorProvider.Provider.Current().Account;
            h_househisbll.SaveFormADD("", hh);
            h_housebll.RemoveForm(keyValue);
            return Success("审核成功。");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult ShenForm2(string keyValue, string Reson)
        {
            var entity = h_housebll.GetEntity(keyValue);
            entity.IsDeleted = "正常";
            entity.DeletedNote = "";
            h_housebll.SaveFormADD(keyValue, entity);
            return Success("审核成功。");

        }
        #endregion

        //[HttpGet]
        ////[ValidateAntiForgeryToken]
        ////[AjaxOnly]
        public void ExportToExcel(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string sql = @" select Arear as '村社区',ArearNumber as '网格号',AllAddress as '详细地址',HouseType as '房屋类型',HH as '房屋状态'
            from H_house where 1=1";
            if (!queryParam["txt_Arear"].IsEmpty())
            {
                string Arear = queryParam["txt_Arear"].ToString();
                sql = sql + " and arear='" + Arear + "' ";
            }
            if (!queryParam["txt_ArearNumber"].IsEmpty())
            {
                string txt_ArearNumber = queryParam["txt_ArearNumber"].ToString();
                sql = sql + " and ArearNumber='" + txt_ArearNumber + "' ";
            }
            if (!queryParam["txt_Address"].IsEmpty())
            {
                string txt_Address = queryParam["txt_Address"].ToString();
                sql = sql + " and AllAddress like '%" + txt_Address + "%' ";
            }
            if (!queryParam["txt_HouseType"].IsEmpty())
            {
                string txt_HouseType = queryParam["txt_HouseType"].ToString();
                sql = sql + " and HouseType='" + txt_HouseType + "' ";
            }
            if (!queryParam["txt_CodeNumber"].IsEmpty())
            {
                string txt_CodeNumber = queryParam["txt_CodeNumber"].ToString();
                sql = sql + " and CodeNumber='" + txt_CodeNumber + "' ";
            }
            if (!queryParam["txt_CQRen"].IsEmpty())
            {
                string txt_CQRen = queryParam["txt_CQRen"].ToString();
                sql = sql + " and CQRen='" + txt_CQRen + "' ";
            }
            if (!queryParam["txt_HouseStatus"].IsEmpty())
            {
                string txt_HouseStatus = queryParam["txt_HouseStatus"].ToString();
                sql = sql + " and HH='" + txt_HouseStatus + "' ";
            }
            //var data = projectDS.GetProjectMessage(11);
            DataTable data = new DataTable();
            var data1 = h_housebll.getlist1(sql);

            ExcelHelper.ExportByWeb(data1, String.Empty, "房屋列表.xlsx");

            //return Success("导出成功");
        }


    }
}
