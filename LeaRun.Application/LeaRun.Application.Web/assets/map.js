/**
* T.D3Overlay借助D3.js强大的可视化功能，扩展天地图已有的覆盖物类 T.Overlay，
* 使天地图表达的可视化信息，不仅仅只有地理数据展示，也可以结合更丰富的图形(柱图，饼图)来描述、展现数据。
* 注：chrome、safari、IE9及以上浏览器。
*/

T.D3Overlay = T.Overlay.extend({
    initialize: function (init, redraw, options) {
        this.uid = new Date().getTime();
        this.init = init;
        this.redraw = redraw;
        if (options)
            this.options = options;
        d3.select("head")
            .append("style").attr("type", "text/css")

    },
    /**
     * 地图缩放触发的函数
     * @private
     */
    _zoomChange: function () {
        if (!this.redraw)
            this.init(this.selection, this.transform);
        else
            this.redraw(this.selection, this.transform);
    },
    onAdd: function (map) {
        this.map = map;
        var self = this;
        //增加svg容器
        this._svg = new T.SVG();
        map.addLayer(this._svg);
        //根节点
        this._rootGroup = d3.select(this._svg._rootGroup).classed("d3-overlay", true);
        this.selection = this._rootGroup;
        //一些转换参数
        this.transform = {
            //坐标转容器像素坐标。
            LngLatToD3Point: function (a, b) {
                var _lnglat = a instanceof T.LngLat ? a : new T.LngLat(a, b);
                var point = self.map.lngLatToLayerPoint(_lnglat);
                this.stream.point(point.x, point.y);
            },
            //换算一米转多少像素
            unitsPerMeter: function () {
                return 256 * Math.pow(2, map.getZoom()) / 40075017
            },
            map: self.map,
            layer: self

        };
        this.transform.pathFromGeojson =
            d3.geo.path().projection(d3.geo.transform({
                point: this.transform.LngLatToD3Point
            }));
        //D3绘制
        this.init(this.selection, this.transform);
        //用于确定坐标的
        if (this.redraw)
            this.redraw(this.selection, this.transform);

        map.addEventListener("zoomend", this._zoomChange, this);


    },
    onRemove: function (map) {
        map.removeEventListener("zoomend", this._zoomChange, this);
        this._rootGroup.remove();
        map.removeOverLay(this._svg)
    },
    /**
     * 图层移动到最上层
     * @returns {T.D3Overlay}
     */
    bringToFront: function () {
        if (this._svg && this._svg._rootGroup) {
            var el = this._svg._rootGroup.parentNode;
            el.parentNode.appendChild(el);

        }
        return this;
    },
    /**
     * 图层移动到最底层。
     * @returns {T.D3Overlay}
     */
    bringToBack: function () {
        if (this._svg && this._svg._rootGroup) {
            var el = this._svg._rootGroup.parentNode;
            var parent = el.parentNode;
            parent.insertBefore(el, parent.firstChild);

        }
        return this;
    },
});
// @TODO 地图初始化
$("head").append('<style type="text/css">.area { width: 100%; height: 782px; position: relative; } .area--layer { word-wrap: break-word; position: absolute; bottom: 12px; right: 12px; z-index: 500; background: #fff; border-radius: 3px; padding: 8px 0 7px; background: #fff; border-radius: 3px; line-height: 18px; } .area--layer a { float: left; height: 18px; padding: 0 12px; font-size: 12px; border-left: 1px #dbdee2 dashed; vertical-align: middle; cursor: pointer; overflow: visible; color: #555 !important; } .area--layer a:first-child { border-left: 0; } .area--layer a:hover { opacity: .6; }</style>')
var mapEl = document.getElementById('area');
var $mapEl = $(mapEl);
$mapEl.html('<div class="area--full"></div> <div class="area--layer"> <a map-click=\'{ "fn": "changeMapType", "type": 0 }\'>卫星地图</a><a map-click=\'{ "fn": "showMapArea", "type": 0 }\'>显示区域</a> </div>').addClass("area");
var map = new T.Map(mapEl, {
    zoom: 12,
    center: new T.LngLat(121.21164, 31.57707),
    minZoom: 9,
  //  maxZoom: 19,
});

// 卫星图
var imageURL = "http://t0.tianditu.gov.cn/img_w/wmts?" +
    "SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=img&STYLE=default&TILEMATRIXSET=w&FORMAT=tiles" +
    "&TILEMATRIX={z}&TILEROW={y}&TILECOL={x}&tk=0a36d511144d97a52b7071bf141218e9";
//创建自定义图层对象
var lay = new T.TileLayer(imageURL, { minZoom: 1, maxZoom: 18 });

// 太仓区域 geojson
var countries = geoJSON.features;
var countriesOverlay = new T.D3Overlay(overLayColor('geojson'), overLayRedraw('geojson'));
// 绑定按钮事件
var mapFn = {
    // @TODO 地图点击事件
    changeMapType(data) {
        // 0 默认地图 / 1 卫星地图 
        data.type = +!data.type;
        if (data.type) {
            map.addLayer(lay);
            this.innerText = "默认地图";
        } else {
            map.removeLayer(lay);
            this.innerText = "卫星地图";
        }
        this.setAttribute('map-click', JSON.stringify(data))
    },
    // @TODO 地图区域点击
    showMapArea(data) {
        // 0 关闭区域 / 1 显示区域 
        data.type = +!data.type;
        if (data.type) {
            map.addOverLay(countriesOverlay)
            this.innerText = "关闭区域";
        } else {
            map.removeOverLay(countriesOverlay);
            this.innerText = "显示区域";
        }
        this.setAttribute('map-click', JSON.stringify(data))
    },
    // 搜索地点
    getPoint(value, success, error) {
        new T.Geocoder().getPoint(value, function (data) {
            if (data.getStatus() === 0) {
                success && success(data.getLocationPoint())
            } else {
                error && error(data)
            }

        })
    }
}

// 绑定事件
$mapEl.find("a").on("click", function (e) {
    var that = $(this), data = JSON.parse(this.getAttribute('map-click')), fn = mapFn[data.fn];
    if (typeof fn === "function") { fn.call(this, data) }
    return false
});
$mapEl.find(".area--full").on("click", function () {
    var that = $(this), style = that.attr("style") || "", oldStyle = that.attr("data-style");
    // console.log(oldStyle === undefined)
    if (oldStyle === undefined) {
        that.attr("data-style", style);
        $mapEl.css({
            position: "fixed",
            right: 0,
            top: 0,
            bottom: 0,
            left: 0,
            height: "auto",
            zIndex: 2000,
        });
        // map.panTo(new T.LngLat(121.163, 31.583));
    } else {
        //$mapEl.removeAttr("style");
        $mapEl.attr("style", oldStyle);
        that.removeAttr("data-style", style);
    }
    map.checkResize();
})

// 方法
function gcolor(num) {
    var colorList = ['#f8dcce', '#f6b68a', '#f4895d', '#f4895d', '#812f17'];
    var index = 1;
    if (num > 1000) {
        index = 5;
    } else if (num <= 9) {
        index = 1;
    } else if (num <= 99) {
        index = 2;
    } else if (num <= 499) {
        index = 3;
    } else if (num <= 1000) {
        index = 4;
    }
    return colorList[index - 1]
}
function overLayColor(type) {
    return function (sel, transform) {
        var upd = sel.selectAll('path.' + type).data(countries);
        upd.enter()
            .append('path')
            .attr("class", type)
            .attr('stroke', '#444')
            .attr('fill', function (d, i) {
                return d3.hsl(Math.random() * 360, 1, 0.83)
                // return gcolor(Math.random() * 499)
            })
            .attr('fill-opacity', '0.1')
    }
}
function overLayRedraw(type) {
    return function (sel, transform) {
        sel.selectAll('path.' + type).each(
            function (d, i) {
                d3.select(this).attr('d', transform.pathFromGeojson)
            }
        )
    }
}
// 隔离区域
// var marker = new T.Marker(new T.LngLat(121.209343, 31.616514), {
//     title: "维也纳三好酒店",
//     zIndexOffset: 999,
//     icon: new T.Icon({
//         iconUrl: "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/PjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+PHN2ZyB0PSIxNTgwOTEzNDE2MjgzIiBjbGFzcz0iaWNvbiIgdmlld0JveD0iMCAwIDEwMjQgMTAyNCIgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHAtaWQ9IjY0MzMiIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iMzIiIGhlaWdodD0iMzIiPjxkZWZzPjxzdHlsZSB0eXBlPSJ0ZXh0L2NzcyI+PC9zdHlsZT48L2RlZnM+PHBhdGggZD0iTTUxNi41IDUzMC42bS00MjguOSAwYTQyOC45IDQyOC45IDAgMSAwIDg1Ny44IDAgNDI4LjkgNDI4LjkgMCAxIDAtODU3LjggMFoiIGZpbGw9IiNFNjEyMTEiIHAtaWQ9IjY0MzQiPjwvcGF0aD48cGF0aCBkPSJNNTE2LjUgNTMwLjZtLTM2Ny44IDBhMzY3LjggMzY3LjggMCAxIDAgNzM1LjYgMCAzNjcuOCAzNjcuOCAwIDEgMC03MzUuNiAwWiIgZmlsbD0iI0ZGRkZGRiIgcC1pZD0iNjQzNSI+PC9wYXRoPjxwYXRoIGQ9Ik01MTYuNSA1MzAuNm0tMzI0LjQgMGEzMjQuNCAzMjQuNCAwIDEgMCA2NDguOCAwIDMyNC40IDMyNC40IDAgMSAwLTY0OC44IDBaIiBmaWxsPSIjRTYxMjExIiBwLWlkPSI2NDM2Ij48L3BhdGg+PHBhdGggZD0iTTcxNS42IDU4OC42SDU3NC41djE0MS4xSDQ1OC42VjU4OC42SDMxNy41VjQ3Mi43aDE0MS4xVjMzMS42aDExNS45djE0MS4xaDE0MS4xeiIgZmlsbD0iI0ZGRkZGRiIgcC1pZD0iNjQzNyI+PC9wYXRoPjwvc3ZnPg==",
//         iconSize: new T.Point(32, 32),
//         // iconAnchor: new T.Point(10, 25)
//     })
// })
// var label = new T.Label({
//     text: "镇级集中医学观察点",
//     position: new T.LngLat(121.209343, 31.616514),
//     offset: new T.Point(-75, -30),
// });
// label.setZindex(999);

// map.addOverLay(marker);
// map.addOverLay(label);

