// @TODO API 列表
function obj2arr(obj) {
    let arr = [];
    if(typeof obj !== "object")return [];
    if (obj.length === undefined) { arr.push(obj) } else { arr = obj }
    return arr || []
}
//var COLORS = ["yellow", "blue", "green", "red"];
var COLORS = ["#FFA631", "#1780fb", "#21A675", "#ED5736"];
/**
 * @TODO: 接口列表
 */
var $api = function () {
    function $post(opts) {
        opts.data = opts.data || {};
        return $.get("https://mobile.tcfuqiao.com/WebService.asmx/" + opts.url, opts.data, function (xml) {
            var data = new X2JS().xml2json(xml);
            opts.success && opts.success(data);
            opts.complete && opts.complete(data);
        }, 'xml').error(function (err) {
            opts.error ? opts.error(err) : nui.toast('数据加载失败');
            opts.complete && opts.complete(err);
        });
    }
    return {
        // 请求住房信息
        getCount(success) {
            return $post({
                url: "getCount",
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfAllCount.AllCount));
                }
            });
        },
        // 请求住房信息
        getCount2(success) {
            return $post({
                url: "getCount2",
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfAllCount.AllCount));
                }
            });
        },
        // 柱状图信息
        getCountList(success) {
            return $post({
                url: "getCountList",
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfAllCount.AllCount));
                }
            });
        },
        // 查看居民房列表 
        getXianQin(data, success) {
            return $post({
                url: "getXianQin",
                data: data,
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfXianxi.Xianxi));
                }
            });
        },
        // 查看居民村列表 
        getZhuTu(data, success) {
            return $post({
                url: "getZhuTu",
                data: data,
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfAllCount.AllCount));
                }
            });
        },
        // 查看居民村列表 
        getMapList(data, success) {
            return $post({
                url: "getMapList",
                data: data,
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfMap.Map));
                }
            });
        },
        // 读取锚点信息 
        getXianxi(data, success) {
            return $post({
                url: "getXianxi",
                data: data,
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfXianxi.Xianxi));
                }
            });
        },
        // 读取锚点信息 
        getXianxiList(data, success) {
            return $post({
                url: "getXianxiList",
                data: data,
                success: function (data) {
                    success && success(obj2arr(data.ArrayOfXianxi.Xianxi));
                }
            });
        },

    }
}()

// @TODO 柱状图
var BAR_CHART = {
    chart: '',
    typeList: [], // 区分数据的类型字段,
    type: '', // 当前选择的类型
    setServerItem: function (data, name) {
        return {
            name: name,
            data: data,
            type: 'bar',
            barMaxWidth:30,
            label: { normal: { show: true, position: 'top', color: "#212121" } }
        }
    },
    gd: function (name) {
        return BAR_CHART.seldata.map(function (item) {
            return item[name]
        })
    },
    /**
     * @TODO: 影藏鼠标悬浮
     * @param {*} xAxisData 
     * @returns 
     */
    option: function (xAxisData) {
        return {
            title: false,
            tooltip: {
                show:false,
                trigger: 'axis'
            },
            legend: {
                show: false
            },
            grid: {
                top: 20,
                left: 20,
                right: 20,
                bottom: 6,
                containLabel: true
            },
            toolbox: false,
            // color: ["#c8c8c8", "rgb(237,125,49)", "rgb(165,165,165)", "rgb(255,192,0)"],
            // color: ["#f78207", "#F55253", "#178B50", "#888"],
            color: COLORS,
            xAxis: {
                type: 'category',
                data: xAxisData,
                axisLabel: {
                    interval: 0,    //强制文字产生间隔
                    rotate: 45,     //文字逆时针旋转45°
                    textStyle: {    //文字样式
                        color: "black",
                        fontFamily: 'Microsoft YaHei'
                    }
                },

            },
            yAxis: {
                type: 'value',
                splitLine: { lineStyle: { color: "#e2e2e2" } },
                axisLine: { show: false },
                axisTick: { show: false },
            },
            series: [
                {
                    name: '昨日人数',
                    type: 'bar',
                    label: { normal: { show: true, position: 'top', color: "#212121" } },

                },
                {
                    name: '今日人数',
                    type: 'bar',
                    label: { normal: { show: true, position: 'top', color: "#212121" } },

                }
            ]
        }
    },
    refreshData: function () {
        var gd = BAR_CHART.gd;
        var option = BAR_CHART.option(gd("Arear"));//option || BAR_CHART.chart.getOption();
        option.series[0] = BAR_CHART.setServerItem(gd("Qty"), '总数');
        option.series[1] = BAR_CHART.setServerItem(gd("QYQty"), '签约数');
        option.series[2] = BAR_CHART.setServerItem(gd("WCQty"), '完成数');
        option.series[3] = BAR_CHART.setServerItem(gd("NoQty"), '未签约数');
        BAR_CHART.chart.setOption(option);
    },
    refreshSubData: function (data, chart) {
        // console.log(data)
        var gd = function (name) { return data.map(function (item) { return item[name] }) };
        var option = BAR_CHART.option(gd("Arear"));
        option.series[0] = BAR_CHART.setServerItem(gd("Qty"), '总数');
        option.series[1] = BAR_CHART.setServerItem(gd("QYQty"), '签约数');
        option.series[2] = BAR_CHART.setServerItem(gd("WCQty"), '完成数');
        option.series[3] = BAR_CHART.setServerItem(gd("NoQty"), '未签约数');
        chart.setOption(option);
    },
    render: function (data) {
        BAR_CHART.typeList = [];
        data.map(function (item) {
            let Type = item.Type;
            ~BAR_CHART.typeList.indexOf(Type) || BAR_CHART.typeList.push(Type);
            BAR_CHART.type || (BAR_CHART.type = Type)
        })
        BAR_CHART.seldata = [];
        data.map(function (item) {
            let Type = item.Type;
            if (Type === BAR_CHART.type) BAR_CHART.seldata.push(item);
        })
        var navtpl = '';
        BAR_CHART.typeList.map(function (name) {
            navtpl += '<a class="nui-btn ' + (BAR_CHART.type === name ? 'is-active' : 'nui-btn-default') + '">' + name + '</a>'
        })
        $('.bar--nav').html(navtpl).find('a').on("click", function () {
            BAR_CHART.type = this.innerText;
            BAR_CHART.render(data);
        })
        // 如果已有数据则直接更新数据
        if (BAR_CHART.chart) {
            return BAR_CHART.refreshData()
        }
        // 基于准备好的dom，初始化echarts实例
        BAR_CHART.chart = echarts.init(document.getElementById('bar'));
        // 点击事件
        BAR_CHART.chart.on('click', "series", function (ev) {
            var Name = BAR_CHART.type;
            var Arear = ev.name;
            $api.getZhuTu({ Name: Name, Arear: Arear }, function (data) {
                // BAR_CHART.renderSub(data);
                nui.open({
                    content: '',
                    shadow: false,
                    title: Arear + '/' + Name,
                    width: ["80%", "70%"],
                    //full: true,
                    offset: ["10%"],
                    fixed: true,
                    shadeClose: true,
                    success: function () {
                        var chart = echarts.init(this.querySelector('.nui-open-bd'));
                        chart.setOption(BAR_CHART.option());
                        BAR_CHART.refreshSubData(data, chart);

                    }
                })
            })
        });
        // 使用刚指定的配置项和数据显示图表。
        BAR_CHART.refreshData();
    }
}
//@TODO 饼图
var PIE_CHART = {
    pies: [], // 存储多个饼图
    // color: ["#f78207", "#F55253", "#178B50", "#888"],
    color: COLORS,
    render: function (datas) {
        // var names = ["总数", "签约数", "完成数", " 未签约数"]
        var names = ["人员总数", "常住人员", "老宅人员", " 租住人员"]
        //刷新数据
        function refreshData(data, index) {
            var option = {
                title: false,
                tooltip: { trigger: 'axis' },
                legend: { show: false },
                toolbox: false,
                color: PIE_CHART.color,
                series: [{
                    type: 'pie',
                    selectedMode: false,
                    radius: [0, "36%"],
                    label: {
                        position: 'inner',
                        fontSize: 12,
                        color: '#fff',
                        position: 'center',
                        formatter: '{a|{c}}',
                        rich: {
                            a: {
                                fontSize: 15,
                                color: '#fff',
                                align: 'center',
                            }
                        }
                    },
                    data: []
                },
                {
                    type: 'pie',
                    selectedMode: false,//'single',
                    label: {
                        position: 'inner',
                        fontSize: 13,
                        color: '#fff',
                        formatter: '{c}',
                    },
                    type: 'pie',
                    radius: ["40%", "80%"],
                    funnelAlign: 'left',
                    data: []
                }]
            }
            option.series[0].data = [
                { value: data.Qty, name: names[0] },
            ]
            option.series[1].data = [
                { value: data.QYQty, name: names[1] },
                { value: data.WCQty, name: names[2] },
                { value: data.NoQty, name: names[3] },
            ];
            PIE_CHART.pies[index].setOption(option);
        }
        $(".pie--chart").each(function (index) {
            var that = $(this);
            var data = datas[index];
            // 读取数据库类型名称
            // that.parent().find(".chart--title").text(data.Type);
            if (!data) return;
            if (PIE_CHART.pies[index]) { return refreshData(data, index) }
            var html = "";
            PIE_CHART.color.map(function (item, index) {
                html += '<div><p>' + names[index] + '</p><cite  style=\'background:' + item + '\'></cite></div>'
            })
            $(".pie--legend").html(html)
            PIE_CHART.pies[index] = echarts.init(this);
            PIE_CHART.pies[index].on("click",function(e){
                if(e.seriesIndex ===0){
                    $(".now--data h2").eq(index).trigger("click")
                }
                if(e.seriesIndex ===1){
                    $(".now--data li").eq(index).find("span").eq(e.dataIndex).trigger("click")
                }
                console.log(index,e.seriesIndex,e.dataIndex)
                //dataIndex
            })
            refreshData(data, index);
        })
    }
}


