function request(paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}
function readOnly() {
    if (request('readOnly') == 1) {
        $(".frmbottom").hide();
        //$("form *").attr("disabled", "disabled");
    }
}
function onchanges(str) {
    if (!/^\d{1,10}(\.\d{1,2})?$/.test(str)) {
        showErrorMsg('输入错误')
    }
}
function check(c) {

    var r = /^[+-]?[1-9]?[0-9]*\.[0-9]*$/;

    return r.test(c);

}
function doubleKeypress(val, num) {
    var e = window.event;
    var code = e.charCode || e.keyCode;
    //只能输入数字与小数点
    if ((code < 48 || code > 57) && code != 46) {
        e.keyCode = 0;
    }
    //只能输入一个小数点
    if ((val.indexOf(".") != -1 && code == 46)) {
        e.keyCode = 0;
    }
    if (num == 0 && code == 46) {
        e.keyCode = 0;
    }
    //小数点后只能有两位数
    if (val.indexOf(".") != -1 && val.substring(val.indexOf("."), val.length).length > num) {
        e.keyCode = 0;
    }
}

function ParseDate(obj) {
    if (obj != null) {
        if (obj.indexOf('1900-1-1') != -1 || obj.indexOf('1900-01-01') != -1) {
            return "";
        }
        var index = obj.indexOf('T');
        var date = obj.substr(0, index).replace('T', ' ').replace('+', ' ');
        return date;
    }
}

function ParseDateTime(obj) {
    if (obj != null) {
        if (obj.indexOf('1900-1-1') != -1 || obj.indexOf('1900-01-01') != -1) {
            return "";
        }
        return obj.replace('T', ' ').replace('+', ' ');
    }
}
function ParseDateTimeMin(obj) {
    if (obj != null) {
        if (obj.indexOf('1900-1-1') != -1 || obj.indexOf('1900-01-01') != -1) {
            return "";
        }
        return obj.replace('T', ' ').replace('+', ' ').substring(0, 16);
    }
}
function newGuid() {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "-";
    }
    return guid;
}

function Current_iframeID() {
    var tabs_container = top.$("#tabs_container");
    return "tabs_iframe_" + tabs_container.find('.selected').attr('id').substr(5);
}

function Tabchange(id) {
    $('.ScrollBar').find('.tabPanel').hide(); $('.ScrollBar').find("#" + id).show();
}
document.onkeydown = function (e) {
    if (!e) e = window.event;
    if ((e.keyCode || e.which) == 13) {
        var btnSearch = document.getElementById("btnSearch");
        if (btnSearch != null) { btnSearch.focus(); btnSearch.click(); }
    }
}

function Shieldkeydown() {
    $("*").keydown(function (e) { e = window.event || e || e.which; if (e.keyCode == 112 || e.keyCode == 113 || e.keyCode == 114 || e.keyCode == 115 || e.keyCode == 116 || e.keyCode == 117 || e.keyCode == 118 || e.keyCode == 119 || e.keyCode == 120 || e.keyCode == 121 || e.keyCode == 122 || e.keyCode == 123) { e.keyCode = 0; return false; } })
}

//$(document).ready(function () {
//    $('.aspNetHidden').hide();
//    //document.onselectstart = function () { return false; }
//    //$(document).bind("contextmenu", function () { return false; });
//    //Shieldkeydown(); 
//    publicobjcss(); Loading(false); GetTabClick();
//})

function ToggleCode(obj, codeurl) {
    $("#txtCode").val("");
    $("#" + obj).attr("src", codeurl + "?time=" + Math.random());
}

function windowload() {
    $("#grid_paging").pqGrid("refreshDataAndView");
    GetRowIndex = -1;
}

function rePage() {
    Loading(true);
    window.location.href = window.location.href.replace('#', '');
    return false;
}

function Replace() {
    Loading(true);
    window.location.reload();
    return false;
}

function bntback() {
    window.history.back(-1);
    Loading(true);
}

function Urlhref(url) {
    Loading(true);
    window.location.href = url;
    return false;
}

//显示进度条 bool
function Loading(bool) {
    if (bool) {
        top.$("#loading").show();
    }
    else {
        setInterval(loadinghide, 900);
    }
}

//关闭进度条
function loadinghide() {
    if (top.document.getElementById("loading") != null) {
        top.$("#loading").hide();
    }
}

function showTopMsg(msg, time, type) {
    MsgTips(time, msg, 300, type);
}

function BeautifulGreetings() {
    var now = new Date(); var hour = now.getHours(); if (hour < 3) { return ("夜深了,早点休息吧！") }
    else if (hour < 9) { return ("早上好！") }
    else if (hour < 12) { return ("上午好！") }
    else if (hour < 14) { return ("中午好！") }
    else if (hour < 18) { return ("下午好！") }
    else if (hour < 23) { return ("晚上好！") }
    else { return ("夜深了,早点休息吧！") }
}

function showTipsMsg(msg, time, type) {
    if (type == 4) {
        top.showTopMsg(msg, time, 'success');
    }
    else if (type == 5) {
        top.showTopMsg(msg, time, 'error');
    }
    else if (type == 3) {
        top.showTopMsg(msg, time, 'warning');
    }
}

function showSuccessMsg(msg) {
    showTopMsg(msg, 2000, 'success');
}

function showErrorMsg(msg) {
    showTopMsg(msg, 2000, 'error');
}

function showFaceMsg(msg) {
    top.art.dialog({ id: 'faceId', title: '温馨提醒', content: msg, icon: 'face-smile', time: 10, background: '#000', opacity: 0.1, lock: true, okVal: '关闭', ok: true });
}

function showWarningMsg(msg) {
    top.art.dialog({ id: 'warningId', title: '系统提示', content: msg, icon: 'warning', time: 10, background: '#000', opacity: 0.1, lock: true, okVal: '关闭', ok: true });
}

function showConfirmMsg(msg, callBack) {
    top.art.dialog({ id: 'confirmId', title: '系统提示', content: msg, icon: 'warning', background: '#000000', opacity: 0.1, lock: true, button: [{ name: '确定', callback: function () { callBack(true); }, focus: true }, { name: '取消', callback: function () { this.close(); return false; } }] });
}

function showNotice(_id, _title, _width, content, time) {
    top.art.dialog.notice({ id: _id, title: _title, width: _width, content: content, icon: 'face-smile', time: time });
}


function openDialog(url, _id, _title, _width, _height, left, top, closeCallBack) {
    if (arguments.length > 7) {
        art.dialog.open(url, { id: _id, title: _title, width: _width, height: _height, left: left + '%', top: top + '%', background: '#000000', opacity: 0.1, lock: true, resize: false, close: closeCallBack }, false);
    }
    else {
        art.dialog.open(url, { id: _id, title: _title, width: _width, height: _height, left: left + '%', top: top + '%', background: '#000000', opacity: 0.1, lock: true, resize: false, close: function () { } }, false);
    }
}

function FillopenDialog(url, _id, _title) {
    art.dialog.open(url, { id: _id, title: _title, width: '100%', height: '100%', background: '#000000', opacity: 0.1, lock: true, resize: false, close: function () { } }, false);
}

function PageSourceReload() {
    var win = art.dialog.open.origin; //来源页面
    win.ListGrid();
    art.dialog.close();
}

function OpenClose() {
    art.dialog.close();
}
function IsEditdata(id) {
    var isOK = true; if (id == undefined || id == "") { isOK = false; showTipsMsg(OperationMsg.NoSelected, 4000, 3); } else if (id.toString().split(",").length > 1) { isOK = false; showTipsMsg(OperationMsg.OnlySelectedOne, 4000, 3); }
    return isOK;
}
function IsDelData(id) {
    var isOK = true; if (id == undefined || id == "") { isOK = false; showTipsMsg(OperationMsg.NoSelected, 4000, 3); }
    return isOK;
}
function IsChecked(id) {
    var isOK = true; if (id == undefined || id == "") { isOK = false; showTipsMsg(OperationMsg.NoSelected, 4000, 3); }
    return isOK;
}

function IsNullOrEmpty(str) {
    var isOK = true; if (str == undefined || str == "") { isOK = false; }
    return isOK;
}

function delConfig(url, parm, count) {
    DeleteConfig(url, parm, OperationMsg.DeleteConfirmMsg, count);
}

//修改，增加回调函数的方式
function DeleteConfig(url, parm, Msg, count) {
    if (count == undefined) { count = 1; }
    showConfirmMsg(
        Msg,
        function (r) {
            if (r) {
                getAjax(
                            url,
                            parm,
                            function (rs) {
                                showTipsMsg("成功删除 " + count + " 笔记录。", 2000, 4);
                                ListGrid();
                            }
                    );
            }
        }
    );
}

function IsExist_Data(url, parm) {
    var num = 0;
    getAjax(
        url,
        parm,
        function (rs) { num = parseInt(rs); }
    );
    return num;
}

//Ajax的调用
function getAjax(url, parm, callBack) {
    $.ajax({ type: 'post', dataType: "text", url: url, data: parm, cache: false, async: false, success: function (msg) { callBack(msg); }
    });
}


//以post方式返回和传入Json字符串的方式进行Ajax的调用  order by lk
function postJsonAjax(url, jsonData, callBack) {
    $.ajax({ type: 'post', dataType: "json", url: url, data: jsonData, cache: false, async: false, success: function (msg) { callBack(msg); }
    });
}

function CheckDataValid(id) {
    if (!JudgeValidate(id)) { return false; } else { return true; }
}

function GetQuery(key) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("="); if (ar[0] == key) { return ar[1]; }
    }
    return "";
}
function changeURLPar(destiny, par, par_value) {
    var pattern = par + '=([^&]*)'; var replaceText = par + '=' + par_value; if (destiny.match(pattern)) { var tmp = '/\\' + par + '=[^&]*/'; tmp = destiny.replace(eval(tmp), replaceText); return (tmp); }
    else {
        if (destiny.match('[\?]')) { return destiny + '&' + replaceText; }
        else { return destiny + '?' + replaceText; }
    }
    return destiny + '\n' + par + '\n' + par_value;
}
function Keypress(obj) { $("#" + obj).bind("contextmenu", function () { return false; }); $("#" + obj).css('ime-mode', 'disabled'); $("#" + obj).keypress(function (e) { if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) { return false; } }); }
function IsNumberbox(obj) {
    $("#" + obj).bind("contextmenu", function () { return false; }); $("#" + obj).css('ime-mode', 'disabled'); $("#" + obj).bind("keydown", function (e) {
        var key = window.event ? e.keyCode : e.which; if (isFullStop(key)) { return $(this).val().indexOf('.') < 0; }
        return (isSpecialKey(key)) || ((isNumber(key) && !e.shiftKey));
    }); function isNumber(key) { return key >= 48 && key <= 57 }
    function isSpecialKey(key) { return key == 8 || key == 46 || (key >= 37 && key <= 40) || key == 35 || key == 36 || key == 9 || key == 13 }
    function isFullStop(key) { return key == 190 || key == 110; }
}

function CheckboxValue() {
    var reVal = '';
    $('[type = checkbox]').each(function ()
    {
        if ($(this).attr("checked"))
        {
            reVal += $(this).val() + ",";
        }
    });
    reVal = reVal.substr(0, reVal.length - 1);
    return reVal;
}

function divresize(element, height) {
    resizeU(); $(window).resize(resizeU); function resizeU() {
        $(element).css("height", ($(window).height() || window.screen.height) - height);
    }
}

function GetTabClick() { $(".tab_list_top div").click(function () { $(".tab_list_top div").removeClass("actived"); $(this).addClass("actived"); }) }
function iframeresize(height) {
    if (height == undefined) { height = 0; }
    resizeU(); $(window).resize(resizeU); function resizeU() { var iframeMain = $(window).height() || window.screen.height; $("#iframeMainContent").height(iframeMain - height); }
}
function divresize_From(height) { resizeU(); $(window).resize(resizeU); function resizeU() { $(".div-body-From").width($(window).width() - 3); $(".div-body-From").css("height", $(window).height() - height); } }
function dndexampleCss() { $(".example tbody tr").click(function () { $(this).removeClass("tdhover"); $('.example tr').removeClass("selected"); $(this).addClass("selected"); }).hover(function () { if (!$(this).hasClass('selected')) { $(this).addClass("tdhover"); } }, function () { $(this).removeClass("tdhover"); }); }
function publicobjcss() {
    dndexampleCss(); $(".l-btn").hover(function () { $(this).addClass("l-btnhover"); $(this).find('span').addClass("l-btn-lefthover"); }, function () { $(this).removeClass("l-btnhover"); $(this).find('span').removeClass("l-btn-lefthover"); }); $(".tools_bar .tools_btn").hover(function () { if ($(this).attr('disabled') != 'disabled') { $(this).addClass("tools_btn-hover"); $(this).find('span').addClass("tools_btn-hover"); } }, function () { $(this).removeClass("tools_btn-hover"); $(this).find('span').removeClass("tools_btn-hover"); }); $(".panelcheck").click(function () { if (!$(this).hasClass('checkbuttonOk')) { $(this).attr('class', 'checkbuttonOk panelcheck'); $(this).find('.triangleNo').attr('class', 'triangleOk'); } else { $(this).attr('class', 'checkbuttonNo panelcheck'); $(this).find('.triangleOk').attr('class', 'triangleNo'); } })
    $(".sub-menu div").click(function () {
        $('.sub-menu div').removeClass("selected")
        $(this).addClass("selected");
    }).hover(function () { $(this).addClass("navHover"); }, function () { $(this).removeClass("navHover"); }); $('.layout-header-toggle').click(function () { window.parent.iframeleftHide(); })
    $('.layout-collapse-left-toggle').click(function () { $('.layout-collapse-left').hide(); $('.iframeleft').show(); })
    $('.layout-collapse-left').click(function () { $('.layout-collapse-left').hide(); $('.iframeleft').show(); })
}
function iframeleftHide() { $('.layout-collapse-left').show(); $('.iframeleft').hide(); }
function treeAttrCss() { $(".black").treeview({ control: "#treecontrol", persist: "cookie", cookieId: "treeview-gray" }); treeCss(); }
function treeCss() { $(".strTree li div").css("cursor", "pointer"); $(".strTree li div").click(function () { $(".strTree li div").removeClass("collapsableselected"); $(this).addClass("collapsableselected"); }).hover(function () { $(this).addClass("collapsablehover"); }, function () { $(".strTree li div").removeClass("collapsablehover"); }); }
var CheckAllLinestatus = 0; function CheckAllLine() { if (CheckAllLinestatus == 0) { CheckAllLinestatus = 1; $("#checkAllOff").attr('title', '反选'); $("#checkAllOff").attr('id', 'checkAllOn'); $("#dnd-example :checkbox").attr("checked", true); } else { CheckAllLinestatus = 0; $("#checkAllOn").attr('title', '全选'); $("#checkAllOn").attr('id', 'checkAllOff'); $("#dnd-example :checkbox").attr("checked", false); } }
function ckbValueObj(e) {
    var item_id = ''; var arry = new Array(); arry = e.split('-'); for (var i = 0; i < arry.length - 1; i++) { item_id += arry[i] + '-'; }
    item_id = item_id.substr(0, item_id.length - 1); if (item_id != "") { $("#" + item_id).attr("checked", true); ckbValueObj(item_id); }
}
function FormatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, ''); if (isNaN(num))
        num = "0"; sign = (num == (num = Math.abs(num))); num = Math.floor(num * 100 + 0.50000000001); cents = num % 100; num = Math.floor(num / 100).toString(); if (cents < 10)
        cents = "0" + cents; for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + '' +
num.substring(num.length - (4 * i + 3)); return (((sign) ? '' : '-') + num + '.' + cents);
}
function GetStrToDate(strDate) { var date = eval('new Date(' + strDate.replace(/\d+(?=-[^-]+$)/, function (a) { return parseInt(a, 10) - 1; }).match(/\d+/g) + ')'); return date; }
function DateAdd(sdate, days) { var a = new Date(sdate); a = a.valueOf(); a = a + days * 24 * 60 * 60 * 1000; a = new Date(a); return a; }
function formatDate(date) {
    var myyear = date.getFullYear(); var mymonth = date.getMonth() + 1; var myweekday = date.getDate(); if (mymonth < 10) { mymonth = "0" + mymonth; }
    if (myweekday < 10) { myweekday = "0" + myweekday; }
    return (myyear + "-" + mymonth + "-" + myweekday);
}
Date.prototype.pattern = function (fmt) {
    var o = { "M+": this.getMonth() + 1, "d+": this.getDate(), "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, "H+": this.getHours(), "m+": this.getMinutes(), "s+": this.getSeconds(), "q+": Math.floor((this.getMonth() + 3) / 3), "S": this.getMilliseconds() }; var week = { "0": "/u65e5", "1": "/u4e00", "2": "/u4e8c", "3": "/u4e09", "4": "/u56db", "5": "/u4e94", "6": "/u516d" }; if (/(y+)/.test(fmt)) { fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length)); }
    if (/(E+)/.test(fmt)) { fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + week[this.getDay() + ""]); }
    for (var k in o) { if (new RegExp("(" + k + ")").test(fmt)) { fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length))); } }
    return fmt;
}
function Quickseldate(type, BeginControID, EndControID) {
    var begintime, endtime; if (type == "week") { endtime = getWeekEndDate(); begintime = getWeekStartDate(endtime); } else if (type == "month") { endtime = getMonthEndDate(); begintime = getMonthStartDate(endtime); } else if (type == "quarter") { begintime = getQuarterStartDate(); endtime = getQuarterEndDate(); }
    $("#" + BeginControID).val(begintime); $("#" + EndControID).val(endtime);
}
var now = new Date(); var nowDayOfWeek = now.getDay(); var nowDay = now.getDate(); var nowMonth = now.getMonth(); var nowYear = now.getYear(); nowYear += (nowYear < 2000) ? 1900 : 0; function getMonthDays(myMonth) { var monthStartDate = new Date(nowYear, myMonth, 1); var monthEndDate = new Date(nowYear, myMonth + 1, 1); var days = (monthEndDate - monthStartDate) / (1000 * 60 * 60 * 24); return days; }
function getQuarterStartMonth() {
    var quarterStartMonth = 0; if (nowMonth < 3) { quarterStartMonth = 0; }
    if (2 < nowMonth && nowMonth < 6) { quarterStartMonth = 3; }
    if (5 < nowMonth && nowMonth < 9) { quarterStartMonth = 6; }
    if (nowMonth > 8) { quarterStartMonth = 9; }
    return quarterStartMonth;
}
function getWeekStartDate() { var weekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek); return weekStartDate.pattern("yyyy-MM-dd") + " 00:00"; }
function getWeekEndDate() { var weekEndDate = new Date(nowYear, nowMonth, nowDay + (6 - nowDayOfWeek)); return weekEndDate.pattern("yyyy-MM-dd") + " 23:59"; }
function getMonthStartDate() { var monthStartDate = new Date(nowYear, nowMonth, 1); return monthStartDate.pattern("yyyy-MM-dd") + " 00:00"; }
function getMonthEndDate() { var monthEndDate = new Date(nowYear, nowMonth, getMonthDays(nowMonth)); return monthEndDate.pattern("yyyy-MM-dd") + " 23:59"; }
function getQuarterStartDate() { var quarterStartDate = new Date(nowYear, getQuarterStartMonth(), 1); return quarterStartDate.pattern("yyyy-MM-dd") + " 00:00"; }
function getQuarterEndDate() { var quarterEndMonth = getQuarterStartMonth() + 2; var quarterStartDate = new Date(nowYear, quarterEndMonth, getMonthDays(quarterEndMonth)); return quarterStartDate.pattern("yyyy-MM-dd") + " 23:59"; }
function FixedTableHeader(gv, scrollHeight, scrollWidth) { var gvn = $(gv).clone(true).removeAttr("id"); $(gvn).find("tr:not(:first)").remove(); $(gv).before(gvn); $(gv).find("tr:first").remove(); $(gv).wrap("<div id='FixedTable' style='width:" + scrollWidth + "px;height:" + scrollHeight + "px;overflow-y: auto; overflow-x: hidden; padding: 0;margin: 0;'></div>"); }
//(function (menu) {
//    jQuery.fn.contextmenu = function (options) {
//        var defaults = { offsetX: 2, offsetY: 2, items: [], action: $.noop() }; var opt = menu.extend(true, defaults, options); function create(e) {
//            var m = menu('<ul class="simple-contextmenu"></ul>').appendTo(document.body); menu.each(opt.items, function (i, item) {
//                if (item) {
//                    if (item.type == "split") { menu("<div class='m-split'></div>").appendTo(m); return; }
//                    var row = menu('<li><a href="javascript:void(0)"><span></span></a></li>').appendTo(m); item.icon ? menu('<img src="' + item.icon + '">').insertBefore(row.find('span')) : ''; item.text ? row.find('span').text(item.text) : ''; if (item.action) { row.find('a').click(function () { item.action(e.target); }); }
//                }
//            }); return m;
//        }
//        this.live('contextmenu', function (e) {
//            var m = create(e).show(); var left = e.pageX + opt.offsetX, top = e.pageY + opt.offsetY, p = { wh: menu(window).height(), ww: menu(window).width(), mh: m.height(), mw: m.width() }
//            top = (top + p.mh) >= p.wh ? (top -= p.mh) : top; left = (left + p.mw) >= p.ww ? (left -= p.mw) : left; m.css({ zIndex: 10000, left: left, top: top }); $(document.body).live('contextmenu click', function () { m.remove(); }); return false;
//        }); return this;
//    }
//})(jQuery);
var GetRowIndex = -1;
function PQLoadGrid(obj_ID, url, colM, sort, PageSize, topVisible) {
    GetRowIndex = -1;
    var dataModel = { location: "remote", sorting: "remote", paging: "remote", dataType: "JSON", method: "GET", curPage: 1, rPP: PageSize, sortIndx: 0, sortDir: "up", rPPOptions: [20, 30, 40, 50, 100, 500, 1000],
        getUrl: function () {
            var orderField = (this.sortIndx == "0") ? "" : this.sortIndx;
            var sortDir = (this.sortDir == "up") ? "desc" : "asc";
            if (this.curPage == 0) { this.curPage = 1; }
            return { url: url, data: "pqGrid_PageIndex=" + this.curPage + "&pqGrid_PageSize=" +
this.rPP + "&pqGrid_OrderField=" + orderField + "&pqGrid_OrderType=" + sortDir + "&pqGrid_Sort=" + escape(sort)
            };
        },
        getData: function (dataJSON) {
            if (dataJSON.success != undefined && dataJSON.success == false) { //超时了
                if (dataJSON.status == AjaxResultStatus.LoginTimeout) {
                    openDialog("/login.aspx?loginType=1", "reLogin", "重新登录", 800, 600, 50, 50);
                    return false;
                }
            }
            else {
                if (dataJSON == null && dataJSON.totalRecords <= 0) { showTipsMsg(OperationMsg.NoSearchData, 5000, 5); }
                return { curPage: dataJSON.curPage, totalRecords: dataJSON.totalRecords, data: dataJSON.data };
            }
        }
    }
    if (!IsNullOrEmpty(topVisible)) { topVisible = false; }
    $(obj_ID).pqGrid({ dataModel: dataModel, colModel: colM, editable: false, topVisible: topVisible, oddRowsHighlight: false, columnBorders: true, freezeCols: 0, rowSelect: function (evt, ui) { GetRowIndex = ui.rowIndxPage; } });
    pqGridResize(obj_ID, -52, -4);
}
function SumPQLoadGrid(obj_ID, url, colM, sort, PageSize, topVisible) {
    GetRowIndex = -1;
    var dataModel = { location: "remote", summaryData: "0", sorting: "remote", paging: "remote", async: false, dataType: "JSON", method: "GET", curPage: 1, rPP: PageSize, sortIndx: 0, sortDir: "up", rPPOptions: [20, 30, 40, 50, 100, 500, 1000],
        getUrl: function () {
            var orderField = (this.sortIndx == "0") ? "" : this.sortIndx;
            var sortDir = (this.sortDir == "up") ? "desc" : "asc";
            if (this.curPage == 0) { this.curPage = 1; }
            return { url: url, data: "pqGrid_PageIndex=" + this.curPage + "&pqGrid_PageSize=" +
this.rPP + "&pqGrid_OrderField=" + orderField + "&pqGrid_OrderType=" + sortDir + "&pqGrid_Sort=" + escape(sort)
            };
        },
        getData: function (dataJSON) {
            if (dataJSON.success != undefined && dataJSON.success == false) { //超时了
                if (dataJSON.status == AjaxResultStatus.LoginTimeout) {
                    openDialog("/login.aspx?loginType=1", "reLogin", "重新登录", 800, 600, 50, 50);
                    return false;
                }
            }
            else {
                if (dataJSON == null && dataJSON.totalRecords <= 0) { showTipsMsg(OperationMsg.NoSearchData, 5000, 5); }
                else {
                    var nums = dataJSON.summaryData.split(",");
                    var str = "合计：有价值的设备数目为" + nums[0] + ",设备总价值为" + nums[1];

                    $(".pq-grid-summary").html(str);
                }
                return { curPage: dataJSON.curPage, totalRecords: dataJSON.totalRecords, data: dataJSON.data, summaryData: dataJSON.summaryData };
            }

        } 
    }
    var obj = { dataModel: dataModel, colModel: colM, editable: false, topVisible: topVisible, oddRowsHighlight: false, columnBorders: true, freezeCols: 0, rowSelect: function (evt, ui) { GetRowIndex = ui.rowIndxPage; } };
    obj.render = function (evt, ui) {
        $summary = $("<div class='pq-grid-summary'>合计:</div>")
        .prependTo($(".pq-grid-bottom", this));
    }
    obj.cellSave = function (ui) {
        obj.refresh();
    }
    if (!IsNullOrEmpty(topVisible)) { topVisible = false; }
    $(obj_ID).pqGrid(obj);
    pqGridResize(obj_ID, -52, -4);

}
//设置表格的高度和宽度
function pqGridResize(obj, lose_height, lose_width) {
    var grid_height = $(window).height() + lose_height;
    var grid_width = $(window).width() + lose_width;
    var grid1 = $(obj).pqGrid({ width: grid_width, height: grid_height });
}

function pqGridResizefixed(obj, lose_height, lose_width) {
    var grid_width = $(window).width() + lose_width;
    var grid1 = $(obj).pqGrid({ width: grid_width, height: lose_height });
}
function GetPqGridRowValues(obj_ID, rowCode) {
    alert(GetRowIndexs);
    if (GetRowIndexs.length > 0) {
        var DM = $(obj_ID).pqGrid("option", "dataModel");
        var data = DM.data;
        var datas = new Array();
        for (var i = 0; i < GetRowIndexs.length; i++) {
            datas.append(data[GetRowIndexs[i]][rowCode]);
        }
        return datas;
    }
    else {
        return null;
    }
}
function GetPqGridRowValue(obj_ID, rowCode) {
    if (GetRowIndex != -1) {
        var DM = $(obj_ID).pqGrid("option", "dataModel");
        var data = DM.data;
        return data[GetRowIndex][rowCode];
    }
    else {
        return null;
    }
}

var IndetableRow_autocomplete = 0;
var scrollTopheight = 0;
function autocomplete(Objkey, width, height, data, callBack) {
    if ($('#' + Objkey).attr('readonly') == 'readonly') { return false; }
    if ($('#' + Objkey).attr('disabled') == 'disabled') { return false; }
    IndetableRow_autocomplete = 0; scrollTopheight = 0; var X = $("#" + Objkey).offset().top; var Y = $("#" + Objkey).offset().left; $("#div_gridshow").html(""); if ($("#div_gridshow").attr("id") == undefined) { $('body').append('<div id="div_gridshow" style="overflow: auto;z-index: 1000;border: 1px solid #A8A8A8;border-top: 0px solid #A8A8A8;width:' + width + ';height:' + height + ';position: absolute; background-color: #fff; display: none;"></div>'); } else { $("#div_gridshow").height(height); $("#div_gridshow").width(width); }
    var sbhtml = '<table class="tableobj">'; if (data != "") { sbhtml += '<tbody>' + data + '</tbody>'; } else { sbhtml += '<tbody><tr><td style="color:red;text-align:center;width:' + width + ';">没有找到您要的相关数据！</td></tr></tbody>'; }
    sbhtml += '</table>'; $("#div_gridshow").html(sbhtml); $("#div_gridshow").css("left", Y).css("top", X + 25).show(); if (data != "") { $("#div_gridshow").find('tbody tr').each(function (r) { if (r == 0) { $(this).addClass('selected'); } }); }
    $("#div_gridshow").find('tbody tr').click(function () {
        var value = ""; $(this).find('td').each(function (i) { value += $(this).text() + "≌"; }); if ($('#' + Objkey).attr('readonly') == 'readonly') { return false; }
        if ($('#' + Objkey).attr('disabled') == 'disabled') { return false; }
        callBack(value); $("#div_gridshow").hide();
    }); $("#div_gridshow").find('tbody tr').hover(function () { $(this).addClass("selected"); }, function () { $(this).removeClass("selected"); }); document.onclick = function (e) { var e = e ? e : window.event; var tar = e.srcElement || e.target; if (tar.id != 'div_gridshow') { if ($(tar).attr("id") == 'div_gridshow' || $(tar).attr("id") == Objkey) { $("#div_gridshow").show(); } else { $("#div_gridshow").hide(); } } }
}
function autocompletekeydown(Objkey, callBack) {
    $("#" + Objkey).keydown(function (e) {
        switch (e.keyCode) {
            case 38: if (IndetableRow_autocomplete > 0) {
                    IndetableRow_autocomplete--
                    $("#div_gridshow").find('tbody tr').removeClass('selected'); $("#div_gridshow").find('tbody tr').each(function (r) { if (r == IndetableRow_autocomplete) { scrollTopheight -= 22; $("#div_gridshow").scrollTop(scrollTopheight); $(this).addClass('selected'); } });
                }
                break; case 40: var tindex = $("#div_gridshow").find('tbody tr').length - 1; if (IndetableRow_autocomplete < tindex) { IndetableRow_autocomplete++; $("#div_gridshow").find('tbody tr').removeClass('selected'); $("#div_gridshow").find('tbody tr').each(function (r) { if (r == IndetableRow_autocomplete) { scrollTopheight += 22; $("#div_gridshow").scrollTop(scrollTopheight); $(this).addClass('selected'); } }); }
                break; case 13: var value = ""; $("#div_gridshow").find('tbody tr').each(function (r) { if (r == IndetableRow_autocomplete) { $(this).find('td').each(function (i) { value += $(this).text() + "≌"; }); } }); if ($('#' + Objkey).attr('readonly') == 'readonly') { return false; }
                if ($('#' + Objkey).attr('disabled') == 'disabled') { return false; }
                callBack(value); $("#div_gridshow").hide(); break; default: break;
        }
    })
}
function combotree(Objkey, width, height, data) {
    $("#" + Objkey).bind("contextmenu", function () { return false; }); $("#" + Objkey).css('ime-mode', 'disabled'); $("#" + Objkey).keypress(function (e) { return false; }); if ($('#' + Objkey).attr('readonly') == 'readonly') { return false; }
    if ($('#' + Objkey).attr('disabled') == 'disabled') { return false; }
    var X = $("#" + Objkey).offset().top; var Y = $("#" + Objkey).offset().left; $("#div_treeshow").html(""); if ($("#div_treeshow").attr("id") == undefined) { $('body').append('<div id="div_treeshow" style="overflow: auto;border: 1px solid #A8A8A8;width:' + width + ';height:' + height + ';position: absolute; background-color: #fff; display: none;"></div>'); } else { $("#div_treeshow").height(height); $("#div_treeshow").width(width); }
    var sbhtml = ''; if (data != "") { sbhtml += '<ul class="black strTree">' + data + '</ul>'; } else { sbhtml += '<ul class="black strTree"><li><div><span style="color:red;">暂无数据</span></div></li></ul>'; }
    sbhtml += '</table>'; $("#div_treeshow").html(sbhtml); $("#div_treeshow").css("left", Y).css("top", X + 23).show(); $("#div_treeshow").css("z-index", "1000"); document.onclick = function (e) { var e = e ? e : window.event; var tar = e.srcElement || e.target; if (tar.id != 'div_treeshow') { if ($(tar).attr("id") == 'ParentName') { $("#div_treeshow").show(); } else { $("#div_treeshow").hide(); } } }
    treeAttrCss();
}
function MsgTips(timeOut, msg, speed, type) { $(".tip_container").remove(); var bid = parseInt(Math.random() * 100000); $("body").prepend('<div id="tip_container' + bid + '" class="container tip_container"><div id="tip' + bid + '" class="mtip"><span id="tsc' + bid + '"></span></div></div>'); var $this = $(this); var $tip_container = $("#tip_container" + bid); var $tip = $("#tip" + bid); var $tipSpan = $("#tsc" + bid); clearTimeout(window.timer); $tip.attr("class", type).addClass("mtip"); $tipSpan.html(msg); $tip_container.slideDown(speed); window.timer = setTimeout(function () { $tip_container.slideUp(speed); $(".tip_container").remove(); }, timeOut); $tip_container.live("mouseover", function () { clearTimeout(window.timer); }); $tip_container.live("mouseout", function () { window.timer = setTimeout(function () { $tip_container.slideUp(speed); $(".tip_container").remove(); }, timeOut); }); $("#tip_container" + bid).css("left", ($(window).width() - $("#tip_container" + bid).width()) / 2); }
function TipToMouse(_title, e) { var top = e.offset().top - 5; var left = e.offset().left + e.width(); $("body").prepend("<div class='tooltipdi'><span><b></b><em></em>" + _title + "</span></div>"); $(".tooltipdi").css({ "top": top + "px", "left": left + "px" }).show(); var _width = $(".tooltipdi").width(); $(".tooltipdi").width(_width - 5); $(e).blur(function () { $(".tooltipdi").remove(); }) }
function suolve(str) {
    var sub_length = 15; var temp1 = str.replace(/[^\x00-\xff]/g, "**"); var temp2 = temp1.substring(0, sub_length); var x_length = temp2.split("\*").length - 1; var hanzi_num = x_length / 2; sub_length = sub_length - hanzi_num; var res = str.substring(0, sub_length); if (sub_length < str.length) { var end = res + "…"; } else { var end = res; }
    return end;
}
function moveTop(id) {
    var selId = id; var selObj = document.getElementById(selId); if (selObj.options.length == 0 || selObj.options[0].selected) { return false; }
    var count = selObj.options.length - 1; for (var i = selObj.options.length - 1; i >= 0; i--) { var op = selObj.options[count]; if (op.selected) { selObj.remove(count); selObj.options.add(op, 0); } else { count--; continue; } }
}
function moveBottom(id) {
    var selId = id; var selObj = document.getElementById(selId); if (selObj.options.length == 0 || selObj.options[selObj.options.length - 1].selected) { return false; }
    var count = 0; for (var i = 0; i < selObj.options.length; i++) { var op = selObj.options[count]; if (op.selected) { selObj.remove(count); selObj.options.add(op); } else { count++; continue; } }
}
function moveUp(id) {
    var selId = id; var selObj = document.getElementById(selId); if (selObj.options.length == 0 || selObj.options[0].selected) { return false; }
    for (var i = 0; i < selObj.options.length; i++) { var op = selObj.options[i]; if (op.selected) { selObj.remove(i); selObj.options.add(op, i - 1); } else { continue; } }
}
function moveDown(id) {
    var selId = id; var selObj = document.getElementById(selId); if (selObj.options.length == 0 || selObj.options[selObj.options.length - 1].selected) { return false; }
    for (var i = selObj.options.length - 1; i >= 0; i--) { var op = selObj.options[i]; if (op.selected) { selObj.remove(i); selObj.options.add(op, i + 1); } else { continue; } }
}
function selAll(id) {
    var selId = id; var selObj = document.getElementById(selId); if (typeof selObj == "undefined" || selObj == null || selObj == false) { return false; }
    for (var i = 0; i < selObj.options.length; i++) { selObj.options[i].selected = true; }
}
function moveSelOp(selFromId, selToId) { var selFromObj = document.getElementById(selFromId); var selToObj = document.getElementById(selToId); for (var i = 0; i < selFromObj.options.length; i++) { var selFromField = selFromObj.options[i]; if (!selFromField.selected) { continue; } else { var selToField = document.createElement("OPTION"); selToField.text = selFromField.text; selToField.value = selFromField.value; selToObj.options.add(selToField); selFromObj.removeChild(selFromField); i--; } } }
//添加一个tab页面 
//tabid 
function AddTabMenu(tabid, url, name, Isclose, IsReplace) {
    SetSystemId(tabid);
    if (url == "" || url == "#") { url = "/ErrorPage/404.aspx"; }
    var tabs_container = top.$("#tabs_container");
    var ContentPannel = top.$("#ContentPannel");
    if (IsReplace == 'true') { top.RemoveDiv(tabid); }
    if (top.document.getElementById("tabs_" + tabid) == null) {
        Loading(true); tabs_container.find('div').removeClass('selected'); ContentPannel.find('iframe').hide(); if (Isclose != 'false') { tabs_container.append("<div id=\"tabs_" + tabid + "\" class=\"selected\"><a class=\"tab\">" + name + "</a><a onclick=\"RemoveDiv('" + tabid + "')\" class=\"close\" title=\"关闭当前窗口\"></a></div>"); tabs_container.find('#tabs_' + tabid).find('.tab').attr("onclick", "javascript:AddTabMenu('" + tabid + "','" + url + "','" + name + "','true');"); tabs_container.find('#tabs_' + tabid).attr("Is_Win_close", "true"); } else { tabs_container.append("<div id=\"tabs_" + tabid + "\" class=\"selected\" onclick=\"javascript:AddTabMenu('" + tabid + "','" + url + "','" + name + "','false')\"><a class=\"tab\">" + name + "</a></div>"); }
        ContentPannel.append("<iframe id=\"tabs_iframe_" + tabid + "\" name=\"tabs_iframe_" + tabid + "\" height=\"100%\" width=\"100%\" src=\"" + url + "\" frameBorder=\"0\"></iframe>");
    }
    else { tabs_container.find('div').removeClass('selected'); ContentPannel.find('iframe').hide(); tabs_container.find('#tabs_' + tabid).addClass('selected'); top.document.getElementById("tabs_iframe_" + tabid).style.display = 'block'; }
}
function All_CloseTabMenu() { top.$("#div_tab").find("[Is_Win_close=true]").each(function () { RemoveDiv($(this).attr('id')) }); }
function ThisCloseTab() { var tabs_container = top.$("#tabs_container"); top.RemoveDiv(tabs_container.find('.selected').attr('id').substr(5)); }
function RemoveDiv(obj) { var tabs_container = top.$("#tabs_container"); var ContentPannel = top.$("#ContentPannel"); tabs_container.find("#tabs_" + obj).remove(); ContentPannel.find("#tabs_iframe_" + obj).remove(); var tablist = tabs_container.find('div'); var pannellist = ContentPannel.find('iframe'); if (tablist.length > 0) { tablist[tablist.length - 1].className = 'selected'; pannellist[tablist.length - 1].style.display = 'block'; } }

function SetSystemId(MenuId) {
    getAjax("/Frame/Frame.ashx", "action=SetSystemId&SystemId=" + MenuId, function (data) { })
}

function IsNull(str) {
    return (Trim(str) == "") ? false : true;
}

function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

function replaceHTML(str) {
    str = str.replace(/<[^>].*?>/g, "");
    str = str.replace(/&nbsp;/g, "");
    return str;
}

function HTMLDecode(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

//全选取消按钮函数，调用样式如：WZQ
function checkAll(chkobj) {
    if ($(chkobj).find("span i").text() == "全选") {
        $(chkobj).find("span i").text("取消");
        var ids = document.getElementsByName("ids");
        for (var i = 0; i < ids.length; i++) {
            ids[i].checked = true;
        }
        $("#checkEnable").removeClass("fa fa-check-square-o").addClass("fa fa-square-o");
    } else {
        $(chkobj).find("span i").text("全选");
        var ids = document.getElementsByName("ids");
        for (var i = 0; i < ids.length; i++) {
            ids[i].checked = false;
        }
        $("#checkEnable").removeClass("fa fa-square-o").addClass("fa fa-check-square-o");
    }
}

//获取复选框选中的值 WZQ
function GetckbValue() {

    var ids = $("input[name='ids']");
    var check_val = '';
    $.each(ids, function (index, item) {

        if ($(item).is(":checked")) {

            check_val += $(item).val() + ','
        }    
    });
    
    check_val = check_val.substr(0, check_val.length - 1);
    return check_val;
};



//Bootstrap iCheck控件样式 全选js
$('.checkall').iCheck({
    checkboxClass: 'icheckbox_flat-blue',  // 注意square和blue的对应关系
    radioClass: 'iradio_flat-blue'
});


//Enable iCheck plugin for checkboxes 单选
//iCheck for checkbox and radio inputs
$('.mailbox-messages input[type="checkbox"]').iCheck({
    checkboxClass: 'icheckbox_flat-blue',
    radioClass: 'iradio_flat-blue'
});

//Enable check and uncheck all functionality 全选
$(".checkbox-toggle").click(function () {
    var clicks = $(this).data('clicks');
    if (clicks) {
        //Uncheck all checkboxes
        $(".checkall").iCheck("uncheck");

        //<i class="far fa-square"></i> 取消勾选
        //<i class="far fa-check-square"></i>勾选
        //$(".fa", this).removeClass("fa-check-square-o").addClass('fa-square-o');
        $(".far", this).removeClass("fa-check-square").addClass('fa-square');
    } else {
        //Check all checkboxes
        $(".checkall").iCheck("check");
        //$(".fa", this).removeClass("fa-square-o").addClass('fa-check-square-o');
        $(".far", this).removeClass("fa-square").addClass('fa-check-square');
    }
    $(this).data("clicks", !clicks);
});


//扩展bootstrap-table 跳转功能的方法 2020-05-05
function toPage() {
    var pageNum = $("#pageNum").val();
    //if (Number(pageNum) <0)
    if (pageNum) {
        $('#tbMainList').bootstrapTable('selectPage', parseInt(pageNum));
    }
}