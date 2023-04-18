//@api: https://developers.arcgis.com/javascript/3/jsapi/map-amd.html
/* <link rel="stylesheet" href="https://js.arcgis.com/3.40/esri/css/esri.css" />
<script src="https://js.arcgis.com/3.40/init.js"></script>
<script src="assets/terraformer.js"></script>
<script src="assets/terraformer-arcgis-parser.js"></script> */

!function (w) {
    function init(config) {
        require(["esri/map", "esri/layers/WebTiledLayer", "./assets/geojsonlayer.js", "dojo/domReady!"], function (Map, WebTiledLayer, GeoJsonLayer) {
            // 请求私有数据 
            // Add the layer
            function addGeoJsonLayer(url) {
                // Create the layer
                var geoJsonLayer = new GeoJsonLayer({ url: url });
                // Zoom to layer
                geoJsonLayer.on("update-end", function (e) { map.setExtent(e.target.extent.expand(1.2)); });
                // Add to map
                map.addLayer(geoJsonLayer);
                return geoJsonLayer
            }
            // 正文开始
            var map = new Map(config.el, { zoom: 12, minZoom: 10, logo: false, slider: false });
            // 关闭双击缩放
            map.disableDoubleClickZoom();
            // 加载天地图地图
            function loadTianDiTuLayer(map) {
                //  地图坐标标识
                var tileInfo = new esri.layers.TileInfo({
                    "rows": 256,
                    "cols": 256,
                    "compressionQuality": 0,
                    "origin": {
                        "x": -180,
                        "y": 90
                    },
                    "spatialReference": {
                        "wkid": 4326
                    },
                    "lods": [
                        {
                            "level": 2,
                            "resolution": 0.3515625,
                            "scale": 147748796.52937502
                        },

                        {
                            "level": 3,
                            "resolution": 0.17578125,
                            "scale": 73874398.264687508
                        },

                        {
                            "level": 4,
                            "resolution": 0.087890625,
                            "scale": 36937199.132343754
                        },

                        {
                            "level": 5,
                            "resolution": 0.0439453125,
                            "scale": 18468599.566171877
                        },

                        {
                            "level": 6,
                            "resolution": 0.02197265625,
                            "scale": 9234299.7830859385
                        },

                        {
                            "level": 7,
                            "resolution": 0.010986328125,
                            "scale": 4617149.8915429693
                        },

                        {
                            "level": 8,
                            "resolution": 0.0054931640625,
                            "scale": 2308574.9457714846
                        },

                        {
                            "level": 9,
                            "resolution": 0.00274658203125,
                            "scale": 1154287.4728857423
                        },

                        {
                            "level": 10,
                            "resolution": 0.001373291015625,
                            "scale": 577143.73644287116
                        },

                        {
                            "level": 11,
                            "resolution": 0.0006866455078125,
                            "scale": 288571.86822143558
                        },

                        {
                            "level": 12,
                            "resolution": 0.00034332275390625,
                            "scale": 144285.93411071779
                        },

                        {
                            "level": 13,
                            "resolution": 0.000171661376953125,
                            "scale": 72142.967055358895
                        },

                        {
                            "level": 14,
                            "resolution": 8.58306884765625e-005,
                            "scale": 36071.483527679447
                        },

                        {
                            "level": 15,
                            "resolution": 4.291534423828125e-005,
                            "scale": 18035.741763839724
                        },

                        {
                            "level": 16,
                            "resolution": 2.1457672119140625e-005,
                            "scale": 9017.8708819198619
                        },

                        {
                            "level": 17,
                            "resolution": 1.0728836059570313e-005,
                            "scale": 4508.9354409599309
                        },

                        {
                            "level": 18,
                            "resolution": 5.3644180297851563e-006,
                            "scale": 2254.4677204799655
                        }
                    ]
                })
                var baseMap = new WebTiledLayer("http://\${subDomain}.tianditu.com/DataServer?T=vec_c&X=\${col}&Y=\${row}&L=\${level}&tk=0a36d511144d97a52b7071bf141218e9", {
                    "copyright": "",
                    "id": "Tianditu",
                    opacity: 1,
                    "subDomains": ["t0", "t1", "t2"],
                    tileInfo: tileInfo

                });
                var baseMapMarker = new WebTiledLayer("http://\${subDomain}.tianditu.com/DataServer?T=cva_c&X=\${col}&Y=\${row}&L=\${level}&tk=0a36d511144d97a52b7071bf141218e9", {
                    "copyright": "",
                    "id": "Tianditu2",
                    opacity: 1,
                    "subDomains": ["t0", "t1", "t2"],
                    "tileInfo": tileInfo
                });
                map.addLayer(baseMap);
                map.addLayer(baseMapMarker);
            };
            /**
             *  @TODO: 添加卫星图图层 ArcGISTiledMapServiceLayer
             *  var geoqtiledUrl = "http://map.geoq.cn/arcgis/rest/services/ChinaOnlineStreetPurplishBlue/MapServer";
             *  var geoqTiledLayer = new esri.layers.ArcGISTiledMapServiceLayer(geoqtiledUrl);
             *  map.addLayer(geoqTiledLayer); 
             */
            var SYSTEM_TOKEN = sessionStorage.getItem("SYSTEM_TOKEN");
            var SYSTEM_TOKEN_EXPIRES = sessionStorage.getItem("SYSTEM_TOKEN_EXPIRES");
            var SYSTEM_TOKEN_INDEX = 1;
            var SYSTEM_TC_WXT;
            function loadTaiCangMapSync(loadCallback) {
                if (SYSTEM_TC_WXT) return loadCallback(SYSTEM_TC_WXT);
                var expiration = 60; // token的有效时间，单位是分钟
                function getToken(callback) {
                    var tokenServerUrl = "http://58.211.58.103:8080/RemoteTokenServer"
                    var username = 'fuqiao';  // 用户名
                    var password = 'fq123456';  // 密码
                    var hostname = location.hostname === "localhost" ? "localhost" : config.domain;
                    var clientid = 'ref.' + hostname;  // 有2种认证方式，referrer和ip，web页面适合使用referrer方式。生产环境中，需要把localhost替换为生产环境的域名
                    $.ajax({
                        url: tokenServerUrl,
                        jsonp: "callback",
                        dataType: "jsonp",
                        data: {
                            request: "getToken",
                            username: username,
                            password: password,
                            clientid: clientid,
                            expiration: expiration,
                            format: "json"
                        },
                        timeout: 10000,
                        success: function (data) {
                            SYSTEM_TOKEN = data.token;
                            SYSTEM_TOKEN_EXPIRES = data.expires;
                            sessionStorage.setItem("SYSTEM_TOKEN", SYSTEM_TOKEN);
                            sessionStorage.setItem("SYSTEM_TOKEN_EXPIRES", SYSTEM_TOKEN_EXPIRES);
                            SYSTEM_TOKEN_INDEX = 1;
                            callback(data.token);
                        },
                        error: function (jqXHR, textStatus) {
                            getToken(callback);
                            if (typeof shaonq === "object") shaonq.showLoading("尝试认证第" + SYSTEM_TOKEN_INDEX + "次");
                            SYSTEM_TOKEN_INDEX++;
                        }
                    })
                }
                if (SYSTEM_TOKEN && SYSTEM_TOKEN_EXPIRES > +new Date()) {
                    // console.log("cache skip token: " + SYSTEM_TOKEN);
                    var layerUrl = 'http://58.211.58.103:8080/OneMapServer/rest/services/tcyx_new/MapServer' + '?token=' + SYSTEM_TOKEN;
                    var layer = new esri.layers.ArcGISTiledMapServiceLayer(layerUrl);
                    map.addLayer(layer);
                    SYSTEM_TC_WXT = layer;
                    loadCallback && loadCallback(layer)
                } else {
                    getToken(function () {
                        loadTaiCangMapSync(loadCallback)
                    });
                }
            }
            // 默认没有地图需添加一次动态地图,系统才能正确的转换识别4490坐标
            loadTaiCangMapSync(function (layer) {
                layer.hide(), SYSTEM_TC_WXT = null;// 取消第一次的缓存
            });
            // 生成一个坐标 CGCS2000（WKID=4490）
            function addPoint(lng, lat, wkid) {
                return new esri.geometry.Point(+lng, +lat, new esri.SpatialReference({ wkid: wkid || 4490 }))
            }
            // 模拟高得地图 Marker
            function addMarker(opts) {
                opts = opts || {};
                var position = opts.position;
                var icon = opts.icon;
                var point = addPoint(position[0], position[1], opts.wkid);
                var graphic = new esri.Graphic(point);
                // 扩展一个 extData 字段
                graphic.extData = opts.extData || {};
                if (icon) changeMarkerIcon(graphic, icon)
                return graphic
            }

            // 修改  
            function changeMarkerIcon(marker, url, width, height) {
                if (!(marker && url)) throw "changeMarkerIcon param Error"
                switch (url) {
                    case "red":
                        url = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABkAAAApCAYAAADAk4LOAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ppVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDE0IDc5LjE1MTQ4MSwgMjAxMy8wMy8xMy0xMjowOToxNSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDpDODY5NzgyOUU5QkIxMUU1ODREMEFBRkZGMjU5QzgwRiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo0MDUwOTJCMjg3QzIxMUVBOEIzNTk1N0U5NzYwNDY1OSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo0MDUwOTJCMTg3QzIxMUVBOEIzNTk1N0U5NzYwNDY1OSIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjliNWU4M2UyLWRkYjYtMDc0MS1iMTI5LTVkZmM4NzQyOTA3NyIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpDODY5NzgyOUU5QkIxMUU1ODREMEFBRkZGMjU5QzgwRiIvPiA8L3JkZjpEZXNj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';
                        break;
                    case "green":
                        url = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABkAAAApCAYAAADAk4LOAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ppVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDE0IDc5LjE1MTQ4MSwgMjAxMy8wMy8xMy0xMjowOToxNSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDpDODY5NzgyOUU5QkIxMUU1ODREMEFBRkZGMjU5QzgwRiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDozREY3QzZEMTg3QzIxMUVBQjM4QUI5RjJGMjYxOUY5NCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDozREY3QzZEMDg3QzIxMUVBQjM4QUI5RjJGMjYxOUY5NCIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjliNWU4M2UyLWRkYjYtMDc0MS1iMTI5LTVkZmM4NzQyOTA3NyIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpDODY5NzgyOUU5QkIxMUU1ODREMEFBRkZGMjU5QzgwRiIvPiA8L3JkZjpEZXNj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'
                        break;
                    case "blue":
                        url = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABkAAAApCAMAAAD3TXL8AAAAzFBMVEUAAAAOXHs/a68+bKw5bKIQXH0kZIsXX4EqZ5EgY4hDab9Dars+bKk8bKcvaJUnZo0mZY0RXX1Ba7UgYog3a502a5w0apktaJIdYYYbYYUaYIQWX4FYgeT///9WgORMeeFWf+NVfd9OeuJMctBPdtVTe91SfONLcczi6vvV4PiYse9eheS2yPNbguRJeOFRetlOdNOFo+v7/f7b5PnS3vjF0/alu/CIpet2l+ny9f7o7fvf5vrP2/e6zPSsv/KUru6MqOyCoer0+P3z9/3WwhDaAAAAHHRSTlMACOXhxw9pLYVY/vjb1Jp1cRTvU7u4rY1GQDspfdm3VgAAAdBJREFUOMuFkulW4kAQhTsLCIgIuOult6xkIQRFcNeZ93+n6QpyQsac4/ejT1ff3K6qVLNf6fRHrj213VG/0zi3xsPID5RUgR8Nx1YtHLmeAsAlN6vy3KO9cGv75lgIvlvg27c74Y6EkJfZ6/w1K3lI0l2VwzWC2D7MdjxshZFcyjX2AL15mu152mjAG5tyHYVw+3dW82eroZwOO4vA+ZxOnt+T95g2c84R9dnIhy4pXqcLsUjXtC01/BFzA4jMRHEaAghTcmUCgctsxUF1PS5ALB6pPnBls6mU+b2JPgQI8WH297mUU+YYz/w/z9x4HHZeQLzRd6jygPxvAsU56y2hP2eUVgohZEbbT41lj90MwPOXqo1kk1SNveQcgxtmDRXE12pWs/oSUEOL0XXQyaoWEg1zGY3tWILrTfwtxKXmkMfV8C4KGFearOPneJ2k2kTFBQn0Tw1ShHmah0JSEJ1VinUSgOBSSg4iOLFYRddDE6/LiN3wDqGxfXPqNS2nbM/EVocWe8JYbWq3UKYAe4I6S11eozCi7qnupaYfoYKeUxPLLUAU9G6bXA9ADK7ZDy59I/iXPwWaUzWXFq6WWF6xNiZO4ExYK11qshWrd1jxPwdSUHvcogFEAAAAAElFTkSuQmCC'
                        break;
                    default: break;
                }
                var image = new esri.symbol.PictureMarkerSymbol(url, width || 25, height || 41);
                image.setOffset(0, 17.5);//y轴方向向上偏移
                marker.setSymbol(image)
                return image
            }
            var mapUtil = {};
            // @TODO: https://developers.arcgis.com/javascript/3/jsapi/map-amd.html#map1
            mapUtil.map = map;
            mapUtil.addPoint = addPoint;
            mapUtil.addMarker = addMarker;
            mapUtil.changeMarkerIcon = changeMarkerIcon;
            mapUtil.addGeoJsonLayer = addGeoJsonLayer;
            mapUtil.loadTaiCangMapSync = loadTaiCangMapSync;
            mapUtil.centerAndZoom = function (xy, zoom) {
                if (typeof xy === "string") xy = xy.split(',');
                map.centerAndZoom(addPoint(xy[0], xy[1]), zoom || map.getZoom());
            }
            // 在地图加载完毕后开始画图层上面的数据
            map.on("load", function () {
                loadTianDiTuLayer(map)
                // map.centerAndZoom(addPoint(121.20051808655272, 31.604549381333538), 13);
                config.onReady && config.onReady(map, mapUtil);
                // hover
                var MAP_MOUSE_INDEX;
                map.graphics.on("mouse-out", function (ev) {
                    MAP_MOUSE_INDEX && $("#nui-open" + MAP_MOUSE_INDEX).remove();
                })
                map.graphics.on("mouse-drag", function (ev) {
                    MAP_MOUSE_INDEX && $("#nui-open" + MAP_MOUSE_INDEX).remove();
                })
                map.graphics.on("mouse-over", function (ev) {
                    var item = ev.graphic.extData;
                    MAP_MOUSE_INDEX = nui.open({
                        content: nui.tpl('<div style="max-width:320px"><div style="margin-bottom:3px"><span style="font-size: 13px; color: #404040;">{{d.AllAddress}}</span> <span style="margin-left:5px">{{d.HouseType}}</span> <span style="margin-left:5px">{{d.RenAllCount}}人</span></div><div><span>{{d.Name}}</span></div></div>', item),
                        skin: 'layer-tip',
                        type: 4, time: 0,
                        elem: ev.target,
                        width: ["auto", "auto"],
                        title: false
                    });
                })
            })

        });
    }
    w.TcMapUtil = function TcMapUtil(config) {
        if (!(config && config.el)) throw "tcMapUtil config Error";
        new init(config)
    }
}(window)

