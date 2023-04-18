using LeaRun.Application.Busines;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Cache
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.29 9:56
    /// 描 述：数据字典缓存
    /// </summary>
    public class DataItemCache
    {
        private DataItemDetailBLL busines = new DataItemDetailBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<DataItemModel>>(busines.cacheKey);
            if (cacheList == null)
            {
                var data = busines.GetDataItemList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        public IEnumerable<DataItemModel> GetDataItemListAllAddress()
        {

            var data = busines.GetDataItemListAllAddress();

            return data;

        }


        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList(string EnCode)
        {
            if (EnCode == "HouseType")
            {
                return this.GetDataItemList().Where(t => t.EnCode == EnCode && t.ItemName !="其他类型房屋");
            } else if (EnCode=="Arear2")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "丁泾村"||t.ItemName=="六尺社区"));
            }
            else if (EnCode == "Arear3")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "浮桥村" || t.ItemName == "浮桥社区"));
            }
            else if (EnCode == "Arear4")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "浪港村" || t.ItemName == "时思村"));
            }
            else if (EnCode == "Arear5")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "时思社区" || t.ItemName == "陆公社区"));
            }
            else if (EnCode == "Arear6")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "浮桥村" || t.ItemName == "七丫村"
                    || t.ItemName == "浮桥社区" || t.ItemName == "浮南社区" || t.ItemName == "建红社区" || t.ItemName == "六尺社区" ||
                    t.ItemName == "和平花园社区" || t.ItemName == "新城花园社区" || t.ItemName == "戚浦社区" || t.ItemName == "陆公社区"));
            }
            else if (EnCode == "Arear7")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "方桥村" || t.ItemName == "时思村" ||
                    t.ItemName == "浪港村" || t.ItemName == "绿化村" || t.ItemName == "三市村" || t.ItemName == "九曲社区" || 
                    t.ItemName == "时思社区" || t.ItemName == "老闸社区"));
            }
            else if (EnCode == "Arear8")
            {
                return this.GetDataItemList().Where(t => t.EnCode == "Arear" && (t.ItemName == "茜泾村" ||
                    t.ItemName == "马北村" || t.ItemName == "新邵村" || t.ItemName == "丁泾村" || t.ItemName == "牌楼社区" || 
                    t.ItemName == "茜泾社区" || t.ItemName == "新港花苑社区")
                    );
            }
            else
            {
                return this.GetDataItemList().Where(t => t.EnCode == EnCode);
            }
        }

        public IEnumerable<DataItemModel> GetDataItemList2(string EnCode,string Arear)
        {

            return this.GetDataItemList().Where(t => t.EnCode == EnCode && t.ItemName.Contains(Arear));
            
        }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetSubDataItemList(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode);
            string ItemDetailId = data.First(t => t.ItemValue == ItemValue).ItemDetailId;
            return data.Where(t => t.ParentId == ItemDetailId);
        }
        public IEnumerable<DataItemModel> GetSubDataItemListAllAddress(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemListAllAddress().Where(t => t.ItemName.Contains(EnCode));
            //string ItemDetailId = data.First(t => t.ItemValue == ItemValue).ItemDetailId;
            //return data.Where(t => t.ParentId == ItemDetailId);
            return data;
        }



        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode);
            return data.First(t => t.ItemValue == ItemValue).ItemName;
        }
    }
}
