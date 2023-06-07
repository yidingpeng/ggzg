/*
* 在引入该JS文件之前，必须先引入jquery.js, layer.js(弹出框)
* @Author:Leon 李明达
*/

var leonhelper = leonhelper || {};

if (!$.browser) {
    $.browser = {};
}

$.extend(leonhelper, {
    getCookies: function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
    },
    setCookies: function (name, value, time) {
        var strsec = this.getsec(time);
        var exp = new Date();
        exp.setTime(exp.getTime() + strsec * 1);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + "; path=/";
    },
    delCookies: function (name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = this.getCookies(name);
        if (cval != null) {
            document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + "; path=/";
        }
    },
    getsec: function (str) {
        var str1 = str.substring(1, str.length) * 1;
        var str2 = str.substring(0, 1);
        if (str2 == "s") {
            return str1 * 1000;
        }
        else if (str2 == "h") {
            return str1 * 60 * 60 * 1000;
        }
        else if (str2 == "d") {
            return str1 * 24 * 60 * 60 * 1000;
        }
    },
    loading: function () {
        var mileSeconds = 20000;
        if (arguments[0] == 1) {
            mileSeconds = 30000;
        }
        //loading层 
        this.pageCache.loadLayerId = layer.load(0, {
            shade: [0.1, '#fff'], //0.5透明度的白色背景
            time: mileSeconds
        });
    },
    ajaxRequest: function (options) {
        layer.closeAll();
        this.loading();
        var base = this;
        $.ajax({
            url: options.url,
            data: options.data,
            async: typeof options.isAsync != "undefined" ? options.isAsync : true,
            dataType: 'json',
            type: 'POST',
            timeout: 45000,
            success: function (result) {
                layer.closeAll();
                if (options.successCallback && typeof options.successCallback == 'function') {
                    options.successCallback(result);
                }
            },
            error: function (xhr, msg, ex) {
                layer.closeAll();
                if (options.failCallback && typeof options.failCallback == 'function') {
                    options.failCallback();
                }
                base.simpleAlert('操作失败，可能是网络不通，请稍后再试！', 2);
            }
        });
    },
    simpleAlert: function (msg, icon, callback) {
        //layer.closeAll();
        layer.msg(msg, {
            icon: icon,
            time: 2000,
            shade: [0.1, '#FFF'],
            scrollbar: false,
            offset: 200
        }, function () {
            if (callback && typeof callback == 'function') {
                callback();
            }
            //layer.closeAll();
        });
    },
    simpleConfirm: function (content, yescallback, nocallback) {
        //layer.closeAll();
        layer.open({
            content: content,
            title: '消息',
            btn: ['确认', '取消'],
            shadeClose: false,
            yes: function () {
                if (yescallback && typeof yescallback == 'function') {
                    yescallback();
                }
            }, no: function () {
                if (nocallback && typeof nocallback == 'function') {
                    nocallback();
                }
            }
        });
    },
    pageCache: {},
    checkAll: function (x) {
        if ($(x).is(':checked')) {
            $(":checkbox").each(function (index, item) {
                item.checked = true;
            });
        } else {
            $(":checkbox").each(function (index, item) {
                item.checked = false;
            });
        }
    },
    setDataTable: function (obj) {
        obj.DataTable({
            bDestroy: true,
            searching: false,
            bLengthChange: false,
            aoColumnDefs: [{
                bSortable: false,
                aTargets: [0]
            }],
            aaSorting: [[1, "desc"]],
            bPaginate: true,
            bInfo: true,
            iDisplayLength: 10,
            drawCallback: function () {
                $(":checkbox[name='check']").prop('checked', false);
                $(":checkbox[name='check_all']").prop('checked', false);
            }
        });
    },
    eventAutoComplete: function (options) {
        options.obj.autocomplete(options.urlOrData, {
            multiple: false,
            max: typeof options.max != "undefined" ? options.max : 10,
            minChars: 0,
            width: typeof options.inputwidth != "undefined" ? options.inputwidth : 0,
            scrollHeight: typeof options.scrollHeight != "undefined" ? options.scrollHeight : 200,
            autoFill: false,
            matchCase: false,
            matchSubset: false,
            cacheLength: 1,
            mustMatch: typeof options.mustMatch != "undefined" ? options.mustMatch : true,
            matchContains: true,
            formatItem: function (row, i, max) {
                return row.DItem;
            },
            formatMatch: function (row, i, max) {
                return row.DResult;
            },
            formatResult: function (row) {
                return row.DResult;
            },
            flushCache: function () {
                return this.trigger("flushCache");
            }
        }).result(function (event, data, formatted) {
            if (options.setfunc && typeof options.setfunc == 'function') {
                options.setfunc(data);
            }
        }).unResult(function (event) {
            if (options.clearfunc && typeof options.clearfunc == 'function') {
                options.clearfunc();
            }
        });
    },
    eventAutoCompleteByUrl: function (opt) {
        opt.obj.autocomplete(opt.urlOrData, {
            onBegin: function (options) {
                if (opt.onBegin && typeof opt.onBegin == 'function') {
                    opt.onBegin(options);
                }
                return options;
            },
            multiple: false,
            max: typeof opt.max != "undefined" ? opt.max : 10,
            minChars: 0,
            width: opt.inputwidth ? opt.inputwidth : 0,
            scrollHeight: 200,
            autoFill: false,
            matchCase: false,
            matchSubset: false,
            cacheLength: 1,
            mustMatch: typeof opt.mustMatch != "undefined" ? opt.mustMatch : true,
            matchContains: true,
            parse: function (data) {
                if (data != "") {
                    var result = JSON.parse(data);
                    return $.map(result, function (row) {
                        return {
                            data: row,
                            value: row.DResult,
                            result: row.DResult
                        }
                    });
                }
            },
            formatItem: function (row, i, max) {
                return row.DItem;
            },
            formatMatch: function (row, i, max) {
                return row.DResult;
            },
            formatResult: function (row) {
                return row.DResult;
            },
            flushCache: function () {
                return this.trigger("flushCache");
            }
        }).result(function (event, data, formatted) {
            if (opt.setfunc && typeof opt.setfunc == 'function') {
                opt.setfunc(data);
            }
        }).unResult(function (event) {
            if (opt.clearfunc && typeof opt.clearfunc == 'function') {
                opt.clearfunc();
            }
        });
    },
    removeScriptTag: function (str) {
        if (str) {
            var scriptReg = /\<\/?script[^\>]*\>/g;
            return str.replace(scriptReg, "");
        }
        return "";
    },
    getYYMMDD: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy/MM/dd");
        }
        return "";
    },
   
    getYYMMDDHHMMSS: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy/MM/dd hh:mm:ss");
        }
        return "";
    },
    StringToDate: function (str) {
        if (str && str.length > 2) {
            return new Date(str).format('yyyy/MM/dd');
        }
        return new Date('1900/1/1').format('yyyy/MM/dd');
    },
    SafeToString: function (str) {
        if (str == null || str == "") {
            return "";
        }
        return str;
    },
    isNullOrEmpty: function (str, name) {

        if (str == null || str == "") {
            return "";
        }
        var reg = new RegExp(";", "g");
        if (name == "") {

            return str.replace(reg, "\n").trim() + "\n";
        } else {
            return name + ":" + str.replace(reg, "\n").trim() + "\n";
        }

    },
    loadDataTableAJAX: function (option) {
        $(option.Obj).DataTable({
            bDestroy: true,
            searching: false,
            bLengthChange: false,
            bSort: false,
            bInfo: false, //页脚信息
            bPaginate: false,
            //iDisplayLength: 10,
            processing: false,
            serverSide: true,
            sAjaxSource: option.AjaxUrl + "&" + new Date().getTime(),
            fnServerData: function (sSource, aoData, fnCallback) {
                $.ajax({
                    "type": 'post',
                    "url": sSource,
                    "dataType": "json",
                    "data": {
                        aoData: JSON.stringify(aoData)
                    },
                    "success": function (resp) {
                        fnCallback(resp);
                    }
                });
            },
            fnServerParams: function (aoData) {
                if (option && typeof option.Params != "undefined") {
                    for (var i in option.Params) {
                        aoData.push({ "name": i, "value": option.Params[i] });
                    }
                }
            },
            "aoColumns": option.Columns
        });
    },
    loadDataTableAJAXLIST: function (option) {
        $(option.Obj).DataTable({
            bDestroy: true,
            searching: false,
            bLengthChange: false,
            aoColumnDefs: [{
                bSortable: false,
                aTargets: typeof option.aTargets != "undefined" ? option.aTargets : [0]           //对序号为1列的列不进行排序,如果多行不需要排序的话，可使用 aTargets: [ 0 , 1 , 2 ] ，用逗号分开，列序号以0开始
            }],
            aaSorting: [[3, "asc"]],    //如果是第一行不排序的话，需要加这个，默认从第二行开始排序
            bPaginate: true,
            iDisplayLength: 10,
            language: {
                "sProcessing": "处理中...",
                "sLengthMenu": "显示 _MENU_ 项结果",
                "sZeroRecords": "没有匹配结果",
                "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
                "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
                "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
                "sInfoPostFix": "",
                "sSearch": "搜索:",
                "sUrl": "",
                "sEmptyTable": "表中数据为空",
                "sLoadingRecords": "载入中...",
                "sInfoThousands": ",",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "上一页",
                    "sNext": "下一页",
                    "sLast": "末页"
                }
            },
            processing: false,
            serverSide: true,
            sAjaxSource: option.AjaxUrl + "&" + new Date().getTime(),
            fnServerData: function (sSource, aoData, fnCallback) {
                $.ajax({
                    "type": 'post',
                    "url": sSource,
                    "dataType": "json",
                    "data": {
                        aoData: JSON.stringify(aoData)
                    },
                    "success": function (resp) {
                        fnCallback(resp);
                    }
                });
            },
            fnServerParams: function (aoData) {
                if (option && typeof option.Params != "undefined") {
                    for (var i in option.Params) {
                        aoData.push({ "name": i, "value": option.Params[i] });
                    }
                }
            },
            "aoColumns": option.Columns
        });
    },
    toYYYYMMDD: function (d1) {
        d1 = $.trim(d1);
        if (!d1.IsDateTime())
            return "";
        return this.getYYMMDD('/Date(' + new Date(d1).getTime() + ')/');
    }
});

Date.prototype.format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S": this.getMilliseconds()
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

String.prototype.IsInt = function () {
    var regEx = /^\d+$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};

//String.prototype.IsDecimal = function () {
//    var regEx = /^\d+(\.\d{1,2})?$/g;
//    if (regEx.test(this)) {
//        return true;
//    } else {
//        return false;
//    }
//};

String.prototype.IsDecimal2 = function () {
    var regEx = /^(\-)?\d+(\.\d{1,2})?$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};

String.prototype.IsDecimal4 = function () {
    var regEx = /^\d+(\.\d{1,4})?$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};
String.prototype.IsQuantity = function () {
    var regEx = /^\-?\d+(\.\d{1,4})?$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};

String.prototype.IsDateTime = function () {
    var regEx = /^\d{4}\/\d{1,2}\/\d{1,2}$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};
String.prototype.IsDateTimeyyyymd = function () {
    var regEx = /^(\d{4}\/\d\/\d{1,2}|\d{4}\/\d{1,2}\/\d)$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};

String.prototype.IsDateTimeMMMYY = function () {
    var regEx = /^(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-(\d{2}|\d{4})$/g;
    if (regEx.test(this)) {
        return true;
    } else {
        return false;
    }
};

String.prototype.IsEmpty = function () {
    return this.length == 0;
};

Array.prototype.insert = function (index, item) {
    this.splice(index, 0, item);
};

function addThousands(num) {
    var num = (num || 0).toString(), result = '';
    var index = num.indexOf('.');
    if (index > -1) {
        result = num.slice(index);
        num = num.slice(0, index);
    }
    while (num.length > 3) {
        result = ',' + num.slice(-3) + result;
        num = num.slice(0, num.length - 3);
    }
    if (num) { result = num + result; }
    return result;
}
function removeThousands(str) {
    if (str.length == 0)
        return "";
    return str.replace(/,/g, '');
}