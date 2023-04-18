$.fn.Tab = function (options) {
    var cfg = {
        items: [],
        width: 500,
        height: 500,
        tabcontentWidth: 498,
        tabWidth: 100,
        tabHeight: 32,
        tabScroll: true,
        tabScrollWidth: 19,
        tabClass: 'tab',
        tabContentClass: 'tab-div-content',
        tabClassOn: 'on',
        tabClassOff: 'off',
        tabClassClose: 'tab_close',
        tabClassInner: 'inner',
        tabClassInnerLeft: 'innerLeft',
        tabClassInnerMiddle: 'innerMiddle',
        tabClassInnerRight: 'innerRight',
        tabClassText: 'text',
        tabClassScrollLeft: 'scroll-left',
        tabClassScrollRight: 'scroll-right',
        tabClassDiv: 'tab-div',
        addEvent: null,
        currentEvent: null
    };
    //默认显示第一个li
    var displayLINum = 0;
    $.extend(cfg, options);
    //判断是不是有隐藏的tab
    var tW = cfg.tabWidth * cfg.items.length;
    cfg.tabScroll ? tW -= cfg.tabScrollWidth * 2 : null;
    //tabDiv,该div是自动增加的
    var tab = $('<div />').attr('id', 'jquery_tab_div').height(cfg.tabHeight).addClass(cfg.tabClass).append('<ul />');
    //tab target content
    var tabContent = $('<div />').attr('id', 'jquery_tab_div_content').width(cfg.tabcontentWidth).height(cfg.height - cfg.tabHeight).addClass(cfg.tabContentClass);
    var ccW = (cfg.items.length * cfg.tabWidth) - cfg.width;
    var tabH = '';
    //增加一个tab下的li得模板
    var tabTemplate = '';
    tabTemplate = '<table class="' + cfg.tabClassInner + '"  id="{0}" data-value="{3}" border="0" cellpadding="0" cellspacing="0"><tr>' + '<td class="' + cfg.tabClassInnerLeft + '"></td>'
			+ '<td class="' + cfg.tabClassInnerMiddle + '"><span class="' + cfg.tabClassText + '"><i class="fa {2}"></i>&nbsp;{1}</span></td>' + '<td class="' + cfg.tabClassInnerMiddle + '"><div class="' + cfg.tabClassClose + ' ' + cfg.tabClassClose + '_noselected"></div></td>' + '<td class="' + cfg.tabClassInnerRight + '"></td>'
			+ '</tr></table>';
    var scrollTab = function (o, flag) {
        //当前的left
        var displayWidth = Number(tab.css('left').replace('px', ''));
        !displayWidth ? displayWidth = 0 : null;
        //显示第几个LI
        var displayNum = 0;
        var DW = 0;
        var left = 0;
        if (flag && displayWidth == 0) {
            return;
        }
        if (flag) {
            displayLINum--;
            left = displayWidth + tab.find('li').eq(displayLINum).width();
            left > 0 ? left = 0 : null;
        } else {
            var _rigth = $(".tab ul").width() - parseInt(tab.offset().left) * -1 - cfg.tabcontentWidth - 82;
            var _step = tab.find('li').eq(displayLINum).width();
            if (_rigth > 0) {
                if (_rigth < _step) {
                    _step = _rigth;
                }
            } else {
                return;
            }
            left = displayWidth - _step;
            displayLINum++;
        }
        if (left == 0) {
            tab.animate({ 'left': parseInt(-19) });
        } else {
            tab.animate({ 'left': parseInt(left) });
        }
    }
    function removeTab(item) {
        tab.find("#" + item.id).parents('li').remove();
        tabContent.find('#iframe' + item.id).remove();
    }
    function addTab(item) {
        if (item == null) {
            return false;
        }
        if (item.replace == true) {
            removeTab(item);
        }
        if (tab.find("#" + item.id).length == 0) {
            Loading(true);
            var innerString = tabTemplate.replace("{0}", item.id).replace("{1}", item.title).replace("{2}", item.icon).replace("{3}", item.dataValue);
            var liObj = $('<li class="off"></li>');
            liObj.append(innerString).appendTo(tab.find('ul')).find('table td:eq(1)').click(function () {
                liObj.Contextmenu();
                //判断当前是不是处于激活状态
                if (liObj.hasClass(cfg.tabClassOn)) return;

                var activeLi = liObj.parent().find('li.' + cfg.tabClassOn);
                activeLi.removeClass().addClass(cfg.tabClassOff);

                $(this).next().find('div').removeClass().addClass(cfg.tabClassClose);
                liObj.removeClass().addClass(cfg.tabClassOn);

                tabContent.find('iframe').hide().removeClass(cfg.tabClassOn);
                tabContent.find('#iframe' + liObj.find('table').attr('id')).show().addClass(cfg.tabClassOn);
                cfg.currentEvent(liObj.find('.inner').attr('data-value'));
            })
            if (item.url) {
                var $iframe = $("<iframe class=\"LRADMS_iframe\" id=\"iframe" + item.id + "\" height=\"100%\" width=\"100%\" src=\"" + item.url + "\" frameBorder=\"0\"></iframe>")
                tabContent.append($iframe);
                $iframe.load(function () {
                    window.setTimeout(function () {
                        Loading(false);
                    }, 200);
                });
            }
            if (item.closed) {
                liObj.find('td:eq(2)').find('div').click(function () {
                    var li_index = tab.find('li').length;
                    removeTab(item);
                    tab.find('li:eq(' + (li_index - 2) + ')').find('table td:eq(1)').trigger("click");
                }).hover(function () {
                    if (liObj.hasClass(cfg.tabClassOn)) return;
                    $(this).removeClass().addClass(cfg.tabClassClose);
                }, function () {
                    if (liObj.hasClass(cfg.tabClassOn)) return;
                    $(this).addClass(cfg.tabClassClose + '_noselected');
                });
            }
            else {
                liObj.find('td:eq(2)').html('');
            }
            tab.find('li:eq(' + (tab.find('li').length - 1) + ')').find('table td:eq(1)').trigger("click");
            cfg.addEvent(item);
        } else {
            tab.find('li').removeClass('on').addClass('off');
            tab.find("#" + item.id).parent().removeClass('off').addClass('on');
            tabContent.find('iframe').hide().removeClass('on');
            tabContent.find('#iframe' + item.id).show().addClass('on');
        }
    }
    function newTab(item) {
        if ($(".tab ul>li").length >= 10) {
            dialogAlert("为保证系统效率,只允许同时运行10个功能窗口,请关闭一些窗口后重试！", 0)
            return false;
        }
        if (item.moduleIdCookie == true) {
            top.$.cookie('currentmoduleId', item.id, { path: "/" });
            item.dataValue = item.id;
        }
        else {
            item.dataValue = top.$.cookie('currentmoduleId');
        }
        addTab(item);
        var nW = $(".tab ul").width() - 4;
        if (nW > cfg.width) {
            if (!cfg.tabScroll) {
                cfg.tabScroll = true;
                scrollLeft = $('<div class="' + cfg.tabClassScrollLeft + '"><i></i></div>').click(function () {
                    scrollTab(scrollLeft, true);
                });
                srcollRight = $('<div class="' + cfg.tabClassScrollRight + '"><i></i></div>').click(function () {
                    scrollTab(srcollRight, false);
                });
                cW -= cfg.tabScrollWidth * 2;
                tabContenter.width(cW);
                scrollLeft.insertBefore(tabContenter);
                srcollRight.insertBefore(tabContenter);
            }
            var _left = cfg.width - nW;
            tab.animate({ 'left': _left - 43 });
            displaylicount = tab.find('li').length;
        }
    }
    $.each(cfg.items, function (i, item) {
        addTab(item);
    });
    var scrollLeft, srcollRight;
    if (cfg.tabScroll) {
        scrollLeft = $('<div class="' + cfg.tabClassScrollLeft + '"><i></i></div>').click(function () {
            scrollTab($(this), true);
        });
        srcollRight = $('<div class="' + cfg.tabClassScrollRight + '"><i></i></div>').click(function () {
            scrollTab($(this), false);
        });
        cfg.width -= cfg.tabScrollWidth * 2;
    }
    var container = $('<div />').css({
        'position': 'relative',
        'width': cfg.width,
        'height': cfg.tabHeight
    }).append(scrollLeft).append(srcollRight).addClass(cfg.tabClassDiv);
    var tabContenter = $('<div />').css({
        'width': cfg.width,
        'height': cfg.tabHeight,
        'float': 'left'
    }).append(tab);
    var obj = $(this).append(tabH).append(container.append(tabContenter)).append(tabContent);
    $(window).resize(function () {
        cfg.width = $(window).width() - 100;
        cfg.height = $(window).height() - 56;
        cfg.tabcontentWidth = $(window).width() - 80;
        container.width(cfg.width);
        tabContent.width(cfg.tabcontentWidth).height(cfg.height - cfg.tabHeight);
    });
    //点击第一
    tab.find('li:first td:eq(1)').click();
    return obj.extend({ 'addTab': addTab, 'newTab': newTab });
};
//初始化导航
var tablist;
loadnav = function () {
    var url;
    if (Arear == '镇联动中心') {
        Arear = '镇集成指挥中心',
        url = '/Index.html?Arear=' + Arear + '&water=' + water;

    } else if (Arear == "丁泾村,六尺社区") {
        url = '/indexSub.html?Arear=丁泾村&ArearOptions=丁泾村,六尺社区&water=' + water;
    }
    else if (Arear == "浮桥村,浮桥社区") {
        url = '/indexSub.html?Arear=浮桥村&ArearOptions=浮桥村,浮桥社区&water=' + water;
    } else if (Arear == "浪港村,时思村") {
        url = '/indexSub.html?Arear=浪港村&ArearOptions=浪港村,时思村&water=' + water;
    } else if (Arear == "时思社区,陆公社区") {
        url = '/indexSub.html?Arear=时思社区&ArearOptions=时思社区,陆公社区&water=' + water;
    } else if (Arear == "港区派出所") {
        url = '/indexSub.html?Arear=浮桥村&ArearOptions=浮桥村,七丫村,浮桥社区,浮南社区,建红社区,六尺社区,和平花园社区,新城花园社区,戚浦社区,陆公社区&water=' + water;
    } else if (Arear == "金浪派出所")
    { url = '/indexSub.html?Arear=方桥村&ArearOptions=方桥村,时思村,浪港村,绿化村,三市村,九曲社区,时思社区,老闸社区&water=' + water; }
    else if (Arear == "浏家港派出所")
    { url = '/indexSub.html?Arear=茜泾村&ArearOptions=茜泾村,马北村,新邵村,丁泾村,牌楼社区,茜泾社区,新港花苑社区&water=' + water; }
    else {
        url = '/indexSub.html?' + 'Arear=' + Arear + '&water=' + water;
    }
    alert(url);
    var navJson = {};
    tablist = $("#tab_list_add").Tab({
        items: [
            { id: 'desktop', title: '欢迎首页', closed: false, icon: 'fa fa fa-desktop', url: contentPath + url },
        ],
        tabScroll: false,
        width: $(window).width() - 100,
        height: $(window).height() - 56,
        tabcontentWidth: $(window).width() - 80,
        addEvent: function (item) {
            if (item.closed && item.isNoLog != true) {
                $.ajax({
                    url: contentPath + "/Home/VisitModule",
                    data: { moduleId: item.id, moduleName: item.title, moduleUrl: item.url },
                    type: "post",
                    dataType: "text"
                });
            }
        },
        currentEvent: function (moduleId) {
            top.$.cookie('currentmoduleId', moduleId, { path: "/" });
        }
    });
    $("#GoToHome").click(function () { tablist.newTab({ id: "desktop", title: "欢迎首页", closed: !1, icon: "fa fa fa-desktop", url: contentPath + "/Index.html" }) });
    $("#Voice").click(function () {
        tablist.newTab({ id: "Voice", title: "通知公共", closed: true, icon: "fa fa-volume-up", url: contentPath + "/PublicInfoManage/Notice/Index" });
    });
    //个人中心
    $("#UserSetting").click(function () {
        tablist.newTab({ id: "UserSetting", title: "个人中心", closed: true, icon: "fa fa fa-user", url: contentPath + "/PersonCenter/Index" });
    });
    //动态加载导航菜单
    var _html = "";
    var index = 0;
    $.each(authorizeMenuData, function (i) {
        var row = authorizeMenuData[i];
        if (row.ParentId == '0') {
            index++;
            _html += '<li class="item">';
            _html += '    <a id=' + row.ModuleId + '  href="javascript:void(0);" class="main-nav">';
            _html += '        <div class="main-nav-icon"><i class="fa ' + row.Icon + '"></i></div>';
            _html += '        <div class="main-nav-text">' + row.FullName + '</div>';
            _html += '        <span class="arrow"></span>';
            _html += '    </a>';
            _html += getsubnav(row.ModuleId);
            _html += '</li>';
            navJson[row.ModuleId] = row;
        }
    });
    $("#nav").append(_html);
    $('#nav li a').click(function () {
        var id = $(this).attr('id');
        var data = navJson[id];
        if (data.Target == "iframe") {
            tablist.newTab({ moduleIdCookie: true, id: id, title: data.FullName, closed: true, icon: data.Icon, url: contentPath + data.UrlAddress });
        }
    })
    $("#nav li.item").hover(function (e) {
        var $sub = $(this).find('.sub-nav-wrap');
        var length = $sub.find('.sub-nav').find('li').length;
        if (length > 0) {
            $(this).addClass('on');
            $sub.show();
            var sub_top = $sub.offset().top + $sub.height();
            var body_height = $(window).height();
            if (sub_top > body_height) {
                $sub.css('bottom', '0px');
            }
        }
    }, function (e) {
        $(this).removeClass('on');
        $(this).find('.sub-nav-wrap').hide();
    });
    $("#nav li.sub").hover(function (e) {
        var $ul = $(this).find('ul');
        $ul.show();
        var top = $(this).find('ul').offset().top;
        var height = $ul.height();
        var wheight = $(window).height();
        if (top + height > wheight) {
            $ul.css('top', parseInt('-' + (height - 11))).css('left', '130px')
        } else {
            $ul.css('top', '0px').css('left', '130px');
        }
    }, function (e) {
        $(this).find('ul').hide();
        $(this).find('ul').css('top', '0px');
    });
    //导航二菜单
    function getsubnav(moduleId) {
        var _html = '<div class="sub-nav-wrap">';
        _html += '<ul class="sub-nav">';
        $.each(authorizeMenuData, function (i) {
            var row = authorizeMenuData[i];
            if (row.ParentId == moduleId) {
                if (isbelowmenu(row.ModuleId) == 0) {
                    _html += '<li><a id=' + row.ModuleId + '><i class="fa ' + row.Icon + '"></i>' + row.FullName + '</a></li>';
                } else {
                    _html += '<li class="sub" title=' + (row.Description == null ? "" : row.Description) + '><a id=' + row.ModuleId + '><i class="fa ' + row.Icon + '"></i>' + row.FullName + '</a>';
                    _html += getchildnav(row.ModuleId);
                    _html += '</li>'; //sub
                }
                navJson[row.ModuleId] = row;
            }
        });
        _html += '</ul>';
        _html += '</div>';
        return _html;
    }
    //导航三菜单
    function getchildnav(moduleId) {
        var _html = '<div class="sub-child"><ul>';
        $.each(authorizeMenuData, function (i) {
            var row = authorizeMenuData[i];
            if (row.ParentId == moduleId) {
                _html += '<li title=' + (row.Description == null ? "" : row.Description) + '><a id=' + row.ModuleId + '><i class="fa ' + row.Icon + '"></i>' + row.FullName + '</a></li>';
                navJson[row.ModuleId] = row;
            }
        });
        _html += '</ul></div>';
        return _html;
    }
    //判断是否有子节点
    function isbelowmenu(moduleId) {
        var count = 0;
        $.each(authorizeMenuData, function (i) {
            if (authorizeMenuData[i].ParentId == moduleId) {
                count++;
                return false;
            }
        });
        return count;
    }
}
//安全退出
function IndexOut() {
    dialogConfirm("注：您确定要安全退出本次登录吗？", function (r) {
        if (r) {
            Loading(true, "正在安全退出...");
            window.setTimeout(function () {
                $.ajax({
                    url: contentPath + "/Login/OutLogin",
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        window.location.href = contentPath + "/Login/Index";
                    }
                });
            }, 500);
        }
    });
}
//移除Tab
$.removeTab = function (type) {
    var Id = tabiframeId();
    var $tab = $(".tab-div");
    var $tabContent = $(".tab-div-content");
    switch (type) {
        case "reloadCurrent":
            $.currentIframe().reload();
            break;
        case "closeCurrent":
            remove(Id);
            break;
        case "closeAll":
            $tab.find("div.tab_close").each(function () {
                var id = $(this).parents('.inner').attr('id');
                remove(id);
            });
            break;
        case "closeOther":
            $tab.find("div.tab_close").each(function () {
                var id = $(this).parents('.inner').attr('id');
                if (Id != id) {
                    remove(id);
                }
            });
            break;
        default:
            break;
    }
    function remove(id) {
        var li_index = $tab.find('li').length;
        $tab.find("#" + id).parents('li').remove();
        $tabContent.find('#iframe' + id).remove();
        $tab.find('li:eq(' + (li_index - 2) + ')').find('table td:eq(1)').trigger("click");
    }
}



function watermark(settings) {
    //默认设置
    var defaultSettings = {
        watermark_txt: "text",
        watermark_x: 20, //水印起始位置x轴坐标
        watermark_y: 20, //水印起始位置Y轴坐标
        watermark_rows: 20, //水印行数
        watermark_cols: 20, //水印列数
        watermark_x_space: 100, //水印x轴间隔
        watermark_y_space: 50, //水印y轴间隔
        watermark_color: '#aaa', //水印字体颜色
        watermark_alpha: 0.4, //水印透明度
        watermark_fontsize: '15px', //水印字体大小
        watermark_font: '微软雅黑', //水印字体
        watermark_width: 210, //水印宽度
        watermark_height: 80, //水印长度
        watermark_angle: 20 //水印倾斜度数
    };
    if (arguments.length === 1 && typeof arguments[0] === "object") {
        var src = arguments[0] || {};
        for (key in src) {
            if (src[key] && defaultSettings[key] && src[key] === defaultSettings[key]) continue;
            else if (src[key]) defaultSettings[key] = src[key];
        }
    }
    var oTemp = document.createDocumentFragment();
    //获取页面最大宽度
    var page_width = Math.max(document.body.scrollWidth, document.body.clientWidth);
    var cutWidth = page_width * 0.0150;
    var page_width = page_width - cutWidth;
    //获取页面最大高度
    var page_height = Math.max(document.body.scrollHeight, document.body.clientHeight) + 450;
    page_height = Math.max(page_height, window.innerHeight - 30);
    //如果将水印列数设置为0，或水印列数设置过大，超过页面最大宽度，则重新计算水印列数和水印x轴间隔
    if (defaultSettings.watermark_cols == 0 || (parseInt(defaultSettings.watermark_x + defaultSettings.watermark_width * defaultSettings.watermark_cols + defaultSettings.watermark_x_space * (defaultSettings.watermark_cols - 1)) > page_width)) {
        defaultSettings.watermark_cols = parseInt((page_width - defaultSettings.watermark_x + defaultSettings.watermark_x_space) / (defaultSettings.watermark_width + defaultSettings.watermark_x_space));
        defaultSettings.watermark_x_space = parseInt((page_width - defaultSettings.watermark_x - defaultSettings.watermark_width * defaultSettings.watermark_cols) / (defaultSettings.watermark_cols - 1));
    }
    //如果将水印行数设置为0，或水印行数设置过大，超过页面最大长度，则重新计算水印行数和水印y轴间隔
    if (defaultSettings.watermark_rows == 0 || (parseInt(defaultSettings.watermark_y + defaultSettings.watermark_height * defaultSettings.watermark_rows + defaultSettings.watermark_y_space * (defaultSettings.watermark_rows - 1)) > page_height)) {
        defaultSettings.watermark_rows = parseInt((defaultSettings.watermark_y_space + page_height - defaultSettings.watermark_y) / (defaultSettings.watermark_height + defaultSettings.watermark_y_space));
        defaultSettings.watermark_y_space = parseInt(((page_height - defaultSettings.watermark_y) - defaultSettings.watermark_height * defaultSettings.watermark_rows) / (defaultSettings.watermark_rows - 1));
    }
    var x;
    var y;
    for (var i = 0; i < defaultSettings.watermark_rows; i++) {
        y = defaultSettings.watermark_y + (defaultSettings.watermark_y_space + defaultSettings.watermark_height) * i;
        for (var j = 0; j < defaultSettings.watermark_cols; j++) {
            x = defaultSettings.watermark_x + (defaultSettings.watermark_width + defaultSettings.watermark_x_space) * j;
            var mask_div = document.createElement('div');
            mask_div.id = 'mask_div' + i + j;
            mask_div.className = 'mask_div';
            mask_div.appendChild(document.createTextNode(defaultSettings.watermark_txt));
            //设置水印div倾斜显示
            mask_div.style.webkitTransform = "rotate(-" + defaultSettings.watermark_angle + "deg)";
            mask_div.style.MozTransform = "rotate(-" + defaultSettings.watermark_angle + "deg)";
            mask_div.style.msTransform = "rotate(-" + defaultSettings.watermark_angle + "deg)";
            mask_div.style.OTransform = "rotate(-" + defaultSettings.watermark_angle + "deg)";
            mask_div.style.transform = "rotate(-" + defaultSettings.watermark_angle + "deg)";
            mask_div.style.visibility = "";
            mask_div.style.position = "absolute";
            mask_div.style.left = x + 'px';
            mask_div.style.top = y + 'px';
            mask_div.style.overflow = "hidden";
            mask_div.style.zIndex = "9999";
            //让水印不遮挡页面的点击事件
            mask_div.style.pointerEvents = 'none';
            mask_div.style.opacity = defaultSettings.watermark_alpha;
            mask_div.style.fontSize = defaultSettings.watermark_fontsize;
            mask_div.style.fontFamily = defaultSettings.watermark_font;
            mask_div.style.color = defaultSettings.watermark_color;
            mask_div.style.textAlign = "center";
            mask_div.style.width = defaultSettings.watermark_width + 'px';
            mask_div.style.height = defaultSettings.watermark_height + 'px';
            mask_div.style.display = "block";
            oTemp.appendChild(mask_div);
        };
    };
    document.body.appendChild(oTemp);
}

function getNow() {
    var d = new Date();
    var year = d.getFullYear();
    var month = change(d.getMonth() + 1);
    var day = change(d.getDate());
    var hour = change(d.getHours());
    var minute = change(d.getMinutes());
    var second = change(d.getSeconds());

    function change(t) {
        if (t < 10) {
            return "0" + t;
        } else {
            return t;
        }
    }
    var time = year + '年' + month + '月' + day + '日 ' + hour + '时' + minute + '分' + second + '秒';
    return time;
}
