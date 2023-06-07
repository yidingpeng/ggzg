
//组件封装
(function ($) {

    window.Ewin = function () {
        var html = '<div id="[Id]" class="modal fade" role="dialog" aria-labelledby="modalLabel">' +
                              '<div class="modal-dialog modal-sm">' +
                                  '<div class="modal-content">' +
                                      '<div class="modal-header">' +
                                          '<h4 class="modal-title" id="modalLabel">[Title]</h4>' +
                                          '<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>' +
                                      '</div>' +
                                      '<div class="modal-body">' +
                                      '<p>[Message]</p>' +
                                      '</div>' +
                                       '<div class="modal-footer">' +
                                    '<button type="button" class="btn btn-default cancel" data-dismiss="modal">[BtnCancel]</button>' +
                                    '<button type="button" class="btn btn-primary ok" data-dismiss="modal">[BtnOk]</button>' +
                                '</div>' +
                                  '</div>' +
                              '</div>' +
                          '</div>';

        //将模态窗强行添加竖向滚动条
        var dialogdHtml = '<div id="[Id]" class="modal fade " role="dialog" aria-labelledby="modalLabel" style = "overflow-y:scroll" >' +
                              //'<div class="modal-dialog " style="margin:50px;">' +
                               '<div class="modal-dialog " style="margin-left:[MarginLeft];">' +
                                  '<div class="modal-content " style="width:[Width];height:[Height];">' +
                                    //'<div class="modal-content container" style="width:[Width];height:[Height];">' +
                                      '<div class="modal-header">' +
                                          '<h5 class="modal-title" id="modalLabel">[Title]</h5>' +
                                          '<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>' +
                                      '</div>' +
                                      '<div class="modal-body">' +
                                      '</div>' +
                                  '</div>' +
                              '</div>' +
                          '</div>';
        var reg = new RegExp("\\[([^\\[\\]]*?)\\]", 'igm');
        var generateId = function () {
            var date = new Date();
            return 'mdl' + date.valueOf();
        }
        var init = function (options) {
            options = $.extend({}, {
                title: "操作提示",
                message: "提示内容",
                btnok: "确定",
                btncl: "取消",
                width: 200,
                auto: false
            }, options || {});
            var modalId = generateId();
            var content = html.replace(reg, function (node, key) {
                return {
                    Id: modalId,
                    Title: options.title,
                    Message: options.message,
                    BtnOk: options.btnok,
                    BtnCancel: options.btncl
                }[key];
            });
            $('body').append(content);
            $('#' + modalId).modal({
                width: options.width,
                height: options.height,
                backdrop: 'static'
            });
            $('#' + modalId).on('hide.bs.modal', function (e) {
                $('body').find('#' + modalId).remove();
            });
            return modalId;
        }

        return {
            alert: function (options) {
                if (typeof options == 'string') {
                    options = {
                        message: options
                    };
                }
                var id = init(options);
                var modal = $('#' + id);
                modal.find('.ok').removeClass('btn-success').addClass('btn-primary');
                modal.find('.cancel').hide();

                return {
                    id: id,
                    on: function (callback) {
                        if (callback && callback instanceof Function) {
                            modal.find('.ok').click(function () { callback(true); });
                        }
                    },
                    hide: function (callback) {
                        if (callback && callback instanceof Function) {
                            modal.on('hide.bs.modal', function (e) {
                                callback(e);
                            });
                        }
                    }
                };
            },
            confirm: function (options) {
                var id = init(options);
                var modal = $('#' + id);
                modal.find('.ok').removeClass('btn-primary').addClass('btn-success');
                modal.find('.cancel').show();
                return {
                    id: id,
                    on: function (callback) {
                        if (callback && callback instanceof Function) {
                            modal.find('.ok').click(function () { callback(true); });
                            modal.find('.cancel').click(function () { callback(false); });
                        }
                    },
                    hide: function (callback) {
                        if (callback && callback instanceof Function) {
                            modal.on('hide.bs.modal', function (e) {
                                callback(e);
                            });
                        }
                    }
                };
            },
            dialog: function (options) {
                options = $.extend({}, {
                    title: 'title',
                    content: '',
                    width: 800,
                    height: 550,
                    onReady: function () { },
                    onShown: function (e) { }
                }, options || {});
                var modalId = generateId();

                var content = dialogdHtml.replace(reg, function (node, key) {
                    return {
                        Id: modalId,
                        Title: options.title,
                        Width: options.width,
                        Height: options.height,
                        MarginLeft: options.marginLeft,
                    }[key];
                });
                $('body').append(content);
                var target = $('#' + modalId);
                target.find('.modal-body').append(options.content);
                if (options.onReady())
                    options.onReady.call(target);
                target.modal({
                    backdrop: 'static',
                    remote: options.remote
                });
                target.on('shown.bs.modal', function (e) {
                    if (options.onReady(e))
                        options.onReady.call(target, e);
                });

                target.on('hide.bs.modal', function (e) {
                    $('body').find(target).remove();
                });

                //$('.modal-dialog').css({
                //    'margin-left': width/2
                //});
            }
        }
    }();
})(jQuery);

//加载运行
$(document).ready(function () {
    $.each($(".program_status"), function (index, status) {
        var obj = $(status);
        obj.html(getIsDisable(obj.html()));
    });

    $('.modal').on('shown.bs.modal', function (e) {
        // 关键代码，如没将modal设置为 block，则$modala_dialog.height() 为零 
        $(this).css('display', 'block');
        var modalHeight = $(window).height() / 2 - $('#youModel .modal-dialog').height() / 2;
        $(this).find('.modal-dialog').css({
            'margin-top': modalHeight
        });
    });
})

//激活日期控件
function actionDatepicker() {

    //$('.datepicker').datepicker({
    //    fontAwesome: 'font-awesome',    //指定
    //    format: "yyyy-mm-dd",
    //    language: "zh-CN",
    //    autoclose: true,                //自动关闭
    //    todayBtn: "linked",             //今日按钮
    //    todayHighlight: true,           //高亮当前日期
    //});

    //将时间控件换位larui
    layui.use('laydate', function () {
        var laydate = layui.laydate;
        //执行一个laydate实例
        laydate.render({
            elem: '.datepicker' //指定元素
            , theme: '#007bff'
            //, calendar: true    //启用假日
        });


    });

}

//展开折叠操作
function collapse(span) {

    var collapse = $(span).parent();
    var tr = $("#" + collapse.attr("href")).parent().parent();

    var level = collapse.attr("data-level");
    var id = collapse.attr("data-id");

    //if ($(span).attr("class") == "glyphicon glyphicon-plus") {

    //    getSubTable(level, id);
    //    tr.show();
    //    $(span).removeClass("glyphicon-plus");
    //    $(span).toggleClass("glyphicon-minus");
    //}
    //else {
    //    tr.hide();
    //    $(span).removeClass("glyphicon-minus");
    //    $(span).toggleClass("glyphicon-plus");
    //}

    //将图标改成向右向下的三角形 2019/05/10
    //if ($(span).attr("class") == "glyphicon glyphicon-triangle-right") {
    //    getSubTable(level, id);
    //    tr.show();
    //    $(span).removeClass("glyphicon-triangle-right");
    //    $(span).toggleClass("glyphicon-triangle-bottom");
    //}
    //else {
    //    tr.hide();
    //    $(span).removeClass("glyphicon-triangle-bottom");
    //    $(span).toggleClass("glyphicon-triangle-right");
    //}

    //由于fontawesome图标插件升级 将图标改成向右向下的三角形 2020/04/30
    if ($(span).attr("class") == "fas fa-caret-right fa-2x text-blue") {
        getSubTable(level, id);
        tr.show();
        $(span).removeClass("fa-caret-right fa-2x text-blue");
        $(span).toggleClass("fa-caret-down fa-2x text-blue");
    }
    else {
        tr.hide();
        $(span).removeClass("fa-caret-down fa-2x text-blue");
        $(span).toggleClass("fa-caret-right fa-2x text-blue");
    }


}

//获取子表数据
function getSubTable(level, id, callback) {

    $.ajax({
        type: "POST",
        url: "/Program/GetSubTable",
        data: "subLevel=" + (parseInt(level) + 1) + "&id=" + id,
        dataType: "json",
        success: function (data) {

            var div = $("#collapse_" + level + "_" + id);
            div.empty();
            showSubTable(div, level, data);

            if (callback != null && callback != undefined) {
                callback();
            }
        },
        error: function (error) {

            ajaxError(error);

        }
    });
}

//显示子表数据
function showSubTable(div, level, data) {

    var tdTemplate = "<td>{{0}}</td>"
    var thTemplate = "<th>{{0}}</th>"
    var trTemplete = "<tr>{{0}}</tr>";
    var theadTemplate = "<thead  style=\"{{1}}\">{{0}}</thead>";
    var tbodyTemplate = "<tbody>{{0}}</tbody>";
    var tableTemplate = "<table class=\"table table-hover table-bordered\">{{0}}</table>";

    var spanTemplate = "<span {{1}}>{{0}}</span>";

    var collapseTemplate = "<a data-toggle=\"collapse\" id=\"{{level}}_{{id}}\" href=\"collapse_{{level}}_{{id}}\" data-id=\"{{id}}\" data-level=\"{{level}}\">{{collapseSpan}}</a>";

    var collapseBodyTemplate = "<tr style=\"display:none\">" +
                                            "<td colspan=\"{{columnNum}}\">" +
                                                "<div id=\"collapse_{{level}}_{{id}}\"  data-id=\"{{id}}\" data-level=\"{{level}}\" class=\"panel-collapse\">" +
                                                "</div>" +
                                            "</td>" +
                                        "</tr>";

    //var buttonTemplate = "<button type=\"button\" class=\"{{1}}\" style=\"margin:2px;{{3}}\" onclick=\"{{2}}\" >{{0}}</button>";
    var buttonTemplate = "<button type=\"button\" class=\"{{1}}\" style=\"width:65px;margin:2px;{{3}}\" onclick=\"{{2}}\" >{{0}}</button>";

    //添加长Button 2020-12-25
    var LongbuttonTemplate = "<button type=\"button\" class=\"{{1}}\" style=\"width:auto;margin:2px;{{3}}\" onclick=\"{{2}}\" >{{0}}</button>";

    //添加 th
    var thItems = buildString(thTemplate, "", "");

    $.each(data.Title, function (index, item) {
        //不显示ID
        if (item.Value !== "ID") {
            thItems += buildString(thTemplate, item.Value);
        }
    });
    //添加操作title
    $.each(data.Opertions, function (index, item) {

        thItems += buildString(thTemplate, item.Key);
    });

    //设置 title 背景色
    var theadBackColor = "background:#1a749a;color:#f3f0f0;";
    switch (data.Level) {
        case 1:
            theadBackColor = "background:#1e84b0;color:#f3f0f0;";
            break;
        case 2:
            theadBackColor = "background:#2294c6;color:#f3f0f0;";
            break;
        case 3:
            theadBackColor = "background:#27a4da;color:#f3f0f0;";
            break;
        case 4:
            theadBackColor = "background:#3dadde;color:#f3f0f0;";
            break;
        default:
    }
    var thead = buildString(theadTemplate, buildString(trTemplete, thItems), theadBackColor);

    var trItems = "";

    $.each(data.Body, function (index, item) {

        var collapseTitle = "";
        //是否有子表数据（显示展开收缩标签）
        var collapseSpan = "";
        if (item.HavSubTable) {

            //collapseSpan = "<span class=\"glyphicon glyphicon-plus\" onclick=\"collapse(this);\" />";
            //将图标改成向右向下的三角形 2019/05/10
            //collapseSpan = "<span class=\"glyphicon glyphicon-triangle-right\" onclick=\"collapse(this);\" />";

            //由于fontawesome图标插件升级 将图标改成向右向下的三角形 2020/04/30
            collapseSpan = "<span class=\"fas fa-caret-right fa-2x text-blue\" onclick=\"collapse(this);\" />";

        }

        collapseTitle = buildString(collapseTemplate, { level: data.Level, id: item["ID"], collapseSpan: collapseSpan });

        var tdItems = buildString(tdTemplate, collapseTitle, "", "");

        $.each(data.Title, function (index, name) {

            var dtVal = "";

            if (item[name.Name] != null) {

                dtVal = item[name.Name].toString();

            }
            else if (item[name.Name] === undefined && level == 2) {

                $.each(item["GJOPCTypes"], function (index, type) {

                    if (type.Code == name.Name) {

                        dtVal = type.Value == null ? "" : type.Value;

                    }
                });
            }

            //是否显示图片
            var imgUrl = getImage(name.Name, item);

            if (imgUrl !== "") {

                dtVal = "<img width=\"60\" height=\"60\" class=\"rounded\" title=\"单击图片可预览大图\" src=\"" + imgUrl + "\" alt=\"图片\" />";

            } else {

                //数据是否需要格式化
                dtVal = format(name, dtVal);
            }
            if (name.Name !== "ID") {

                var alink = "<a href=\"{{0}}\" target=\"_self\">{{1}}</a>";

                switch (name.Name) {

                    //case "GXName":
                    //    dtVal = buildString(alink, "/BaseInfo/EditBaseGongxu/" + item["GXID"], dtVal);
                    //    break;
                    //case "GBName":
                    //    dtVal = buildString(alink, "/BaseInfo/EditBaseGongbu/" + item["GBID"], dtVal);
                    //    break;
                    case "GJName":
                        dtVal = buildString(alink, "/BaseInfo/EditBaseGongju/" + item["GJID"], dtVal);
                        break;
                    case "WLName":
                        //禁用2020-10-27 拼接a链接快捷跳转
                        //dtVal = buildString(alink, "/BaseInfo/EditBaseWuliao/" + item["WLID"], dtVal);
                        break;
                    default:
                }

                tdItems += buildString(tdTemplate, buildString(spanTemplate, dtVal, "columnName=\"" + name.Name + "\" other=\"" + name.Other + "\""));
            }

        });

        //添加操作 
        $.each(data.Opertions, function (index, opertion) {

            var value = "";

            $.each(opertion.Value, function (subIndex, subItem) {
                var display = "";
                if (!subItem.IsShow) {
                    display = "display:none";
                }

                var icoAdd = "<i class=\"fa fa-plus\"></i>";
                //var icoDel = "<i class=\"glyphicon glyphicon-remove\"></i>";
                //由于fontawesome图标插件升级 修改图标 2020/04/30
                var icoDel = "<i class=\"fas fa-times\"></i>";
                var icoEdit = "<i class=\"fa fa-edit\"></i>";

                //var icoUp = "<i class=\"glyphicon glyphicon-arrow-up\"></i>";
                //由于fontawesome图标插件升级 修改图标 2020/04/30
                var icoUp = "<i class=\"fas fa-chevron-up\"></i>";

                //var icoDown = "<i class=\"glyphicon glyphicon-arrow-down\"></i>";
                //由于fontawesome图标插件升级 修改图标 2020/04/30
                var icoDown = "<i class=\"fas fa-chevron-down\"></i>";

                //var icoSave = "<i class=\"glyphicon glyphicon-ok\"></i>";
                //由于fontawesome图标插件升级 修改图标 2020/04/30
                var icoSave = "<i class=\"fas fa-save\"></i>";

                //由于fontawesome图标插件升级 修改图标 2020/04/30
                var icoCancel = "<i class=\"fas fa-reply\"></i>";
                //var icoCancel = "<i class=\"glyphicon glyphicon-remove\"></i>";
                switch (subItem.Name) {
                    case "上移":
                        value += buildString(buttonTemplate, icoUp + subItem.Name, "btn btn-info btn-sm", buildString("orderSet(this,true,'{{0}}','{{1}}')", data.Level.toString(), item["ID"]), display);
                        break;
                    case "下移":
                        value += buildString(buttonTemplate, icoDown + subItem.Name, "btn btn-info btn-sm", buildString("orderSet(this,false,'{{0}}','{{1}}')", data.Level.toString(), item["ID"]), display);
                        break;
                    case "修改":
                        value += buildString(buttonTemplate, icoEdit + subItem.Name, "btn btn-info btn-sm", "showEdit(this);", display);
                        break;
                    case "删除":
                        value += buildString(buttonTemplate, icoDel + subItem.Name, "btn btn-danger btn-sm", buildString("deletePro(this,'{{0}}','{{1}}')", data.Level.toString(), item["ID"]), display);
                        break;
                    case "保存":
                        value += buildString(buttonTemplate, icoSave + subItem.Name, "btn btn-primary btn-sm", buildString("saveEdit(this,'{{0}}');", subItem.Url), display);
                        break;
                    case "取消":
                        value += buildString(buttonTemplate, icoCancel + subItem.Name, "btn btn-danger btn-sm", buildString("cancelEdit(this,'{{0}}');", subItem.Url), display);
                        break;
                    case "工步配置":
                    case "工具配置":
                    case "检测项配置":
                        value += buildString(LongbuttonTemplate, icoAdd + subItem.Name, "btn btn-primary btn-sm", buildString("showAdd('{{0}}', '{{1}}');", (data.Level + 1).toString(), data.Level + "_" + item["ID"]), display);
                        break;
                    default:
                }
            });

            tdItems += buildString(tdTemplate, value);
        });

        trItems += buildString(trTemplete, tdItems);

        var collapseBody;
        //是否有子表数据（添加展示子表结构）
        //if (item.HavSubTable) {
        collapseBody = buildString(collapseBodyTemplate, { columnNum: data.Title.length + data.Opertions.length + 1, level: data.Level, id: item["ID"] });
        trItems += collapseBody;
        //}
    });

    var tbody = buildString(tbodyTemplate, trItems);

    var table = buildString(tableTemplate, thead + tbody);

    div.append(table);


    //单击图片可预览大图 使用方法
    var wxScale = new WxScale({
        fullPage: document.querySelector("#fullPage"),
        canvas: document.querySelector("#canvas")
    });

    var imgBox = document.querySelectorAll(".table img");
    for (var i = 0; i < imgBox.length; i++) {
        imgBox[i].onclick = function (e) {
            wxScale.start(this);   //这里的this指向需要放大的这张图片

        }
    }

}

//格式化操作
function format(name, dtVal) {

    //数据是否需要格式化
    if (name.Format != "None") {
        switch (name.Format) {
            case "IsEnable":
                dtVal = getIsDisable(dtVal);
                break;
            case "IsOK":
                dtVal = getIsOK(dtVal);
                break;
            case "Light":
                dtVal = getShowLight(dtVal);
                break;
            case "Video":
                if (dtVal != null && dtVal != "") {
                    dtVal = buildString("<button type=\"button\" class=\"btn btn-link\" style=\"margin:2px;\" onclick=\"showVideo('{{0}}')\" >打开视频</button>", dtVal);
                    //dtVal = buildString("<button type=\"button\" class=\"btn btn-link\" style=\"margin:2px;\" onclick=\"showVideo('/{{0}}')\" >打开视频</button>", dtVal);
                }

                break;
            default:
        }
    }
    return dtVal;
}

//图片显示
function getImage(name, item) {
    var strVal = "";
    switch (name) {

        case "GBImage":
            strVal = "/Program/GetGbimg?id=" + item["ID"];
            break;

        case "GJImage":
            strVal = "/BaseInfo/GetGjWlImg?ids=" + (item["GJID"] == null ? "" : item["GJID"]) + "," + (item["WLID"] == null ? "" : item["WLID"]);
            break;

        default:

    }
    return strVal;
}

//视频显示
function showVideo(src) {
    var content = "<video src=\"{{0}}\" width=\"560\" height=\"500\" controls=\"controls\"></video>"
    Ewin.dialog({ title: "显示视频", marginLeft: "auto", width: "592px", height: "auto", content: buildString(content, src) });
}

//禁用|启用 显示
function getIsDisable(status) {

    if (status == null) {
        return "";
    }

    switch (status.toString()) {
        case "0":
            return "<h5><span class='badge badge-success'>启用</span></h5>"; //badge - pill
        case "1":
            return "<h5><span class='badge badge-danger'>禁用</span></h5>";
        default:
            return "";

    }
}

//是|否 显示
function getIsOK(status) {

    if (status == null) {
        return "";
    }

    switch (status.toString()) {
        case "0":
            return "<h5><span class='badge badge-danger'>否</span></h5>";
        case "1":
            return "<h5><span class='badge badge-success'>是</span></h5>";
        default:
            return "";
    }
}

//亮灯显示
function getShowLight(dtVal) {

    var val = "<div style=\"width:25px;height:25px;background-color:{{0}};border-radius:50%;\"/>";
    if (dtVal == null) {
        dtVal = "";
    }
    if (dtVal !== "") {
        return buildString(val, "#00FF00");
    }

    return buildString(val, "#C0C0C0");

}

//创建时间格式化显示
function formatDate(newDtime) {

    var dt = new Date(parseInt(newDtime.slice(6, 19)));
    var year = dt.getFullYear();
    var month = dt.getMonth() + 1;
    var date = dt.getDate();
    //var hour = dt.getHours();
    //var minute = dt.getMinutes();
    //var second = dt.getSeconds();
    return year + "-" + Appendzero(month) + "-" + Appendzero(date);//+ " " + hour + ":" + minute + ":" + second;
}

//首位补零
function Appendzero(obj) {
    if (obj < 10) return "0" + obj; else return obj;
}

//按钮状态显示
function btnStatus(parent, isEdit) {

    var btns = parent.find("[type='button']");
    $.each(btns, function (index, item) {
        var btn = $(item);
        switch (btn.text()) {
            case "修改":
            case "删除":
                if (isEdit) {
                    btn.hide();
                } else {
                    btn.show();
                }
                break;
            case "保存":
            case "取消":
                if (isEdit) {
                    btn.show();
                } else {
                    btn.hide();
                }
                break;
        }
    });
}

//获取 select 控件的Text值
function getSelectText(select) {
    var selectText = "";
    if (select.val() != "") {
        selectText = select.find("option:selected").text()
    }
    return selectText;
}

//字符串传参操作
function buildString(str, paras) {

    //占位符前后修饰符
    var prefix = "\\{\\{", surfix = "\\}\\}";
    //正则表达式字符串
    var regStr = prefix + "(.+?)" + surfix;
    //新建正则表达式
    var regExp = new RegExp(regStr, "mg");

    if (!str) {
        //没有参数时返回空字符串
        return "";
    }
    else if (str && arguments.length == 1) {
        //只有一个参数时返回本身
        return str;
    }
    else if (arguments.length >= 2 && ((typeof paras) == "string")) {
        //字符串传参数时转换参数变成数组
        paras = Array.prototype.splice.call(arguments, 1);
        return bulidStr(str, paras);
    } else {
        //数组或对象传参数
        return bulidStr(str, paras);
    }
    //功能函数,替换并返回
    function bulidStr(str, paras) {
        var ret = str.replace(regExp, function (full, key) {
            return paras[key];
        });
        return ret;
    }
}

//弹框 显示工序
function showGXInfo(id, name) {

    var pageIndex = 1;
    pageIndex = $(".pagination  .active a").html();//获取当前页 2019/05/13
    //alert(pageIndex);

    var level = 1;

    $.ajax({
        type: "POST",
        url: "/Program/GetSubTable",
        data: "subLevel=" + level + "&id=" + id,
        dataType: "json",
        success: function (data) {

            var body = "  <div class='shadow-none bg-light rounded'><div class=\"well\" style=\"margin:10px;padding:5px;\">" +
                          "<div class=\"form-group\" style=\"margin:5px;padding:5px;\">" +
                                "<label>程序名称：</label><label style='color:#007bff;'> " + name + "</label>" +
                                " <a class=\"btn btn-warning\" style='margin-left:40px;' onclick=\"showAdd(1,'" + id + "')\"><i class=\"fas fa-plus\"> 添加工序</i></a> " +
                                " <a class=\"btn btn-danger text-white\" style='margin-left:10px;' onclick=\"quit('" + pageIndex + "')\"><i class=\"fas fa-sign-out-alt\"> 退出</i></a> " +   //显示工序弹框 退出到index 2019/05/09
                            "</div>" +
                        "</div></div>";

            var content = $(buildString("<div id=\"_collapse_0_{{0}}\" data-id=\"1_{{0}}\" data-level=\"0\"></div>", id.toString()));

            showSubTable(content, level, data);


            content = body + content.prop("outerHTML");

            Ewin.dialog({
                //title: "工序配置", marginLeft: "120px", width: "1680px", height: "auto", content: content
                title: "工序配置", marginLeft: "40px", width: "1830px", height: "auto", content: content//2020-03-25 将工序模态窗宽度加大
            });
        },
        error: function (error) {

            ajaxError(error);
        }
    });


}

//显示工序弹框 退出按钮到index页面  2019/05/09
function quit(pageIndex) {
    //alert(pageIndex);
    window.location.href = "/Program/Index?pageIndex=" + pageIndex + "";
}

//编辑操作
function showEdit(btn) {

    var parent = $(btn).parent();
    var dts = parent.parent();

    //var trIndex = parent.parent("tr").index()+1;//获取当前行下标,再加表头行

    //获取显示明细信息 
    var val = dts.find("[data-level]");
    var level = val.attr("data-level");
    var id = val.attr("data-id");
    if (level == "0") {

        id = val.attr("data-gw_prod_def_id")
    }
    var urlData = buildString("sublevel={{0}}&id={{1}}", level, id);
    getDetail(urlData, function (detail) {

        var colVals = dts.find("[columnName]");
        switch (level) {
            case "0":
                showProEdit(colVals, detail);
                break;
            case "1":
                showProGXEdit(colVals, detail);
                break;
            case "2":
                showProGBEdit(colVals, detail);
                break;
            case "3":
                showProGJEdit(colVals, detail);
                break;
            case "4":
                showProValEdit(colVals, detail);
                break;
            default:
        }
        //隐藏修改删除按钮 显示保存取消按钮
        btnStatus(parent, true);
    });

}

//保存操作
function saveEdit(btn, url) {
    var parent = $(btn).parent();
    var dts = parent.parent();

    var val = dts.find("[data-level]");
    var level = val.attr("data-level");
    var id = val.attr("data-id");
    var colVals = dts.find("[columnName]");
    var result;
    switch (level) {
        case "0":
            result = saveProEdit(colVals, id);
            var gw_prod_def_id = val.attr("data-gw_prod_def_id");//关联表id  同时修改关联表
            result.gw_prod_defId = gw_prod_def_id;

            break;
        case "1":
            result = saveProGXEdit(colVals);
            break;
        case "2":
            result = saveProGBEdit(colVals);
            break;
        case "3":
            result = saveProGJEdit(colVals);
            break;
        case "4":
            result = saveProValEdit(colVals);
            break;
        default:
    }
    if (result == null) {
        return;
    }
    result.ID = id;
    if (level == "0") {

        id = val.attr("data-gw_prod_def_id")
    }

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(result),
        contentType: "application/json",
        dataType: "text",
        success: function (success) {

            finish(parent, level, id);
        },
        error: function (error) {

            ajaxError(error);
        }
    });
}

//完成操作
function finish(parent, level, id) {

    var dts = parent.parent();
    var urlData = buildString("sublevel={{0}}&id={{1}}", level, id);

    getDetail(urlData, function (detail) {

        var colVals = dts.find("[columnName]");
        switch (level) {
            case "0":
                finishPro(colVals, detail);
                break;
            case "1":
                finishProGX(colVals, detail);
                break;
            case "2":
                finishProGB(colVals, detail);
                break;
            case "3":
                finishProGJ(colVals, detail);
                break;
            case "4":
                finishProVal(colVals, detail);
                break;
            default:
        }
    });
    //隐藏保存取消按钮 显示修改删除按钮
    btnStatus(parent, false);
}

//取消操作
function cancelEdit(btn, url) {

    //获取显示明细信息 
    var parent = $(btn).parent();
    var dts = parent.parent();
    var val = dts.find("[data-level]");
    var level = val.attr("data-level");
    var id = val.attr("data-id");
    if (level == 0) {
        var gw_prod_def_id = val.attr("data-gw_prod_def_id");//关联表id  同时修改关联表
        id = gw_prod_def_id;
    }
    finish(parent, level, id);

    //var parent = $(btn).parent();
    //var dts = parent.parent();

    ////获取显示明细信息 
    //var val = dts.find("[data-level]");
    //var level = val.attr("data-level");
    //var id = val.attr("data-id");
    //var urlData = buildString("sublevel={{0}}&id={{1}}", level, id);
    //var colVals = dts.find("[columnName]");
    //switch (level) {
    //    case "0":
    //        cancelProEdit(colVals);
    //        break;
    //    case "1":
    //        cancelProGXEdit(colVals);
    //        break;
    //    case "2":
    //        cancelProGBEdit(colVals);
    //        break;
    //    case "3":
    //        cancelProGJEdit(colVals);
    //        break;
    //    case "4":
    //        cancelProValEdit(colVals);
    //        break;
    //    default:
    //}
    ////隐藏保存取消按钮 显示修改删除按钮
    //btnStatus(parent, false);
}

//获取明细信息
function getDetail(data, callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetDetail",
        data: data,
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取工位信息
function getGWList(callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetBaseGongwei",
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取工序信息
//function getGXList(callback) {
//    $.ajax({
//        type: "POST",
//        url: "/Program/GetBaseGongxu",
//        data: "",
//        dataType: "json",
//        success: callback,
//        error: function (error) {
//            ajaxError(error);
//        }
//    });
//}

//获取工步信息
//function getGBList(callback) {
//    $.ajax({
//        type: "POST",
//        url: "/Program/GetBaseGongbu",
//        data: "",
//        dataType: "json",
//        success: callback,
//        error: function (error) {
//            ajaxError(error);
//        }
//    });
//}

//获取工步明细
function getGBDetail(id, callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetGongbuDetail?id=" + id,
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取工序明细
function getGXDetail(id, callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetGongxuDetail?id=" + id,
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取产品型号
function getProModel(callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetProModel",
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取基础数据类型
function getBaseDataType(type, callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetBaseData?type=" + type,
        //data: { type: type },
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取工具列表
function getGJList(callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetGongju",
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//获取物料列表
function getWLList(progbID, callback) {
   
    $.ajax({
        type: "POST",
        //url: "/Program/GetMaterialBarCodeDict",//禁用条码下拉
        url: "/Program/GetMaterialList?progbID=" + progbID,//禁用工艺配置工步物料下拉
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//验证程序名称是否重复
function isProgramNameDouble(programName, id) {

    var retVal = false;
    $.ajax({
        type: "POST",
        url: "/Program/IsProgramNameDouble",
        data: buildString("programName={{0}}&id={{1}}", programName, id),
        dataType: "json",
        async: false,
        success: function (data) {
            retVal = data;
        },
        error: function (error) {
            ajaxError(error);
        }
    });
    return retVal;
}

//获取空模型
function getEmptyTableModel(level, id, callback) {
    $.ajax({
        type: "POST",
        url: "/Program/GetEmptyTableModel?level=" + level + "&id=" + id,
        data: "",
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }

    });
}

//获取工位绑定的工具/物料 opc point 信息
function getGJGWOPCPointInfo(progbID, gjid, wlid, callback) {

    $.ajax({
        type: "POST",
        url: "/Program/getGJGWOPCPointInfo?progbID=" + progbID + "&gjid=" + gjid + "&wlid=" + wlid,
        data: "",
        async: false,
        dataType: "json",
        success: callback,
        error: function (error) {
            ajaxError(error);
        }
    });
}

//程序配置编辑状态
function showProEdit(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {
            case "Pmodel":
                getProModel(function (source) {
                    //comboxEdit(span, detail["PmodelId"], source, "170");
                    comboxEditXH(span, detail["PmodelId"], source, "170");
                });
                break;
            case "GWName":
                getGWList(function (source) {

                    //comboxEdit(span, detail["GWID"], source, "170");
                    comboxEditGW(span, detail["GWID"], source, "170");
                });
                break;
            case "ProgName":
                textEdit(span, detail[colName]);
                break;
            case "FileNo":
                textEdit(span, detail[colName]);
                break;
            case "StartTime":
                timeEdit(span, formatDate(detail[colName]));
                break;
            case "CopyRight":
                textEdit(span, detail[colName]);
                break;
            case "Descript":
                textEdit(span, detail[colName]);
                break;
            case "ProgStatus":
                isEnableEdit(span, detail[colName]);
                break;
            case "Remark":
                textEdit(span, detail[colName]);
                break;
            default:
        }
    });
}

//程序工序配置信息编辑状态
function showProGXEdit(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {

            case "GXName":

                //getGXList(function (source) {

                //    comboSelectEdit(span, detail["GXName"], source, "250", selectChangeGX);
                //});
                textEdit(span, detail[colName]);
                break;
            case "GXVedio":

                var fileName = "";
                var filePath = "";
                if (detail["GXVedioFilename"] != null && detail["GXVedioFilename"] != "") {

                    fileName = detail["GXVedioFilename"];
                    filePath = detail["GXVedio"];
                }

                span.html(buildString("<input type='text' class=\"fileName form-control\" value=\"{{0}}\" readonly />" +
                    "<button type=\"button\" style='margin-right:5px' class=\"fileBrowse btn btn-primary btn-sm\" onclick=\"fileBrowse(this)\"><i class=\"far fa-folder-open\"> 浏览</i></button>" +
                    "<button type=\"button\" style='margin-right:5px' class=\"uploadVedio btn btn-primary btn-sm\" onclick=\"uploadVedio(this)\"><i class=\"fas fa-file-upload\"> {{1}}</i></button>" +
                    "<button type=\"button\" style='display:{{2}};margin-right:5px' class=\"clearVedio btn btn-primary btn-sm\" onclick=\"clearVedio(this)\"><i class=\"fas fa-broom\"> 清理</i></button>" +
                    "<input style='display:none' type=\"file\" accpet='audio/mp4,video/mp4'  class=\"FileUploadVedio\" onchange='getViedoFile(this);' />" +
                    "<input type='hidden' class='GXVedio'value='{{3}}'/>",
                     fileName, fileName == "" ? "上传" : "重新上传", fileName == "" ? "none" : "display", filePath));

                break;
            case "GXDesc":
                textEdit(span, detail[colName]);
                break;
            case "PGXInfoStatus":
                isEnableEdit(span, detail[colName]);
                break;
            case "Remark":
                textEdit(span, detail[colName]);
                break;

            default:
        }
    });
}

//选择工序触发事件
function selectChangeGX(obj, id) {

    if (id == null || id == "") {

        return;
    }
    getGXDetail(id, function (detail) {

        var dr = $(obj).closest("[columnname='GXName']").parent().parent();

        var desc = $(dr).find("[columnName='GXDesc']");

        var vedio = $(dr).find("[columnName='GXVedio']");

        textEdit(desc, detail.Descript);
        //textEdit(vedio, detail.Gxvedio);
        if (detail.GxvedioFilename == null || detail.GxvedioFilename == "") {

            vedio.find(".fileName").val("");

            vedio.find(".clearVedio").hide();

            vedio.find(".uploadVedio").html("<i class=\"glyphicon glyphicon-upload\"></i>上传</button>");

        } else {

            vedio.find(".fileName").val(detail.GxvedioFilename);

            vedio.find(".GXVedio").val(detail.Gxvedio);

            vedio.find(".clearVedio").show();

            vedio.find(".uploadVedio").html("<i class=\"glyphicon glyphicon-upload\"></i>重新上传</button>");
        }

    });
}

//程序工步配置信息编辑状态
function showProGBEdit(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {

            case "GBName":
                //textEdit(span, detail[colName]);LHR 修改为多行文本框
                textareaEdit(span, detail[colName]);
                break;
            case "GBDesc":
                textEdit(span, detail[colName]);
                break;
            case "GBDelayTime":
                numberEdit(span, detail[colName]);
                break;
            case "IsScan":
            case "IsInputPInfo":
            case "IsScanOrderNo":
            case "IsEmpCheck":
                isOKEdit(span, detail[colName]);
                break;
            case "ErrTypeName":
                getBaseDataType("GbErrorType", function (source) {

                    comboxEdit(span, detail["ErrTypeID"], source, "120");
                });
                break;
            case "ControlTypeName":
                getBaseDataType("ControlType", function (source) {

                    comboxEdit(span, detail["ControlTypeID"], source, "100");
                });
                break;
            case "PGBInfoStatus":
                isEnableEdit(span, detail[colName]);
                break;
            case "GBDesc":
                textEdit(span, detail[colName]);
                break;
            case "GBImage":

                if (span.find("img").length == 0) {
                    span.append("<img width=\"60\" height=\"60\" src=\"/Program/GetGbimg?id=\" class=\"rounded\" alt=\"图片\" \>");
                } else if (detail.GBImg != null && detail.GBImg.length > 0) {

                    var base64Str = arrayBufferToBase64(detail.GBImg);//转换字符串
                    var src = 'data:image/png;base64,' + base64Str;
                    $(span.find("img")).attr("src", src);
                }

                var appendStr = "<button type=\"button\" style='margin-right:5px' class=\"imageBrowse btn btn-primary btn-sm\" onclick=\"imageBrowse(this)\">浏览 </button>" +
                    "<button type=\"button\" style='display:{{2}};margin-right:5px' class=\"clearImage btn btn-primary btn-sm\" onclick=\"clearImage(this)\">清理</button>" +
                    "<input style='display:none' type=\"file\" accpet='image/gif,image/jpeg,image/jpg,image/png,image/svg'  class=\"ImageUploadVedio\" onchange='getImageFile(this);'>";
                span.append(appendStr);
                break;
            case "Remark":
                textEdit(span, detail[colName]);
                break;

            default:
        }
    });
}

//选择工步触发事件
function selectChangeGB(obj, id) {

    if (id == null || id == "") {
        return;
    }

    getGBDetail(id, function (detail) {

        var dr = $(obj).closest("[columnname='GBName']").parent().parent();

        var desc = $(dr).find("[columnName='GBDesc']");

        if (detail.Gbimg != null) {

            var base64Str = arrayBufferToBase64(detail.Gbimg);//转换字符串
            var src = 'data:image/png;base64,' + base64Str;
            dr.find("[columnName='GBImage'] img").attr("src", src);
        }

        textEdit(desc, detail.Gbdesc);

    });
}

//程序工具配置信息编辑状态
function showProGJEdit(colVals, detail) {

    var progbID = $(colVals[0]).closest("div").attr("data-id");

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        var other = span.attr("other");

        switch (colName) {
            case "GJName":

                getGJList(function (source) {

                    comboxEdit(span, detail["GJID"], source, "150");

                    span.find("select").change(function (data) {

                        var gjid = span.find("select").val();

                        gjwlChangeSelect(colVals, progbID, gjid, "");
                    });
                });
                break;
            case "WLName":
                console.log(progbID);
                getWLList(progbID,function (source) {

                    comboxEdit(span, detail["WLID"], source, "150");

                    span.find("select").change(function (data) {

                        var wlid = span.find("select").val();

                        gjwlChangeSelect(colVals, progbID, "", wlid);

                    });
                });
                break;
            case "CameraTemplateNo":
            case "materialConfrom"://2020-10-31 添加物料确认为 是否下拉框


                if (detail.GJOPCTypes.length != 0) {

                    $.each(detail.GJOPCTypes, function (index, item) {

                        if (item.Code == colName) {

                            isOKEdit(span, item.Value);
                        }

                    });

                } else {
                    //物料确认 默认下拉选中 否
                    isOKEdit(span, "0");
                }

                break;
            case "Remark":
                textEdit(span, detail[colName]);
                break;
            case "PGJInfoStatus":
                isEnableEdit(span, detail[colName]);
                break;
            default:

                if (other == "auto") {

                    if (detail.GJOPCTypes.length != 0) {

                        $.each(detail.GJOPCTypes, function (index, item) {

                            if (item.Code == colName) {

                                textEdit(span, item.Value);
                            }

                        });

                    } else {

                        textEdit(span, "");
                    }

                }
                break;
        }
    });
}

//获取工具或物料对应的点位配置信息
function gjwlChangeSelect(colVals, progbID, gjid, wlid) {


    getGJGWOPCPointInfo(progbID, gjid, wlid, function (data) {

        var val = data;

        $.each(colVals, function (index, col) {

            var span = $(col);

            if (span.attr("ColumnName") == "gjwlGet" || span.attr("ColumnName") == "gjwlPut") {

                span.find("input").val("");

            }
        });


        $.each(data, function (index, item) {

            $.each(colVals, function (index1, col) {

                var span = $(col);

                if (item.opcTypeCode == span.attr("ColumnName")) {

                    span.find("input").val(item.opcValue);

                }

            });

        });
    });

}

//程序工艺配置检测编辑状态
function showProValEdit(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {
            case "ValueTypeName":
                getBaseDataType("programValueType", function (source) {

                    comboxEdit(span, detail["ValueTypeID"], source, "150");
                });
                break;
            case "EqualTypeName":
                getBaseDataType("programEqualType", function (source) {

                    comboxEdit(span, detail["EqualTypeID"], source, "150");
                });
                break;
            case "StandardValue":
            case "MinValue":
            case "MaxValue":
            case "Remark":
                textEdit(span, detail[colName]);
                break;
            case "PixelPoint":
                numberEdit(span, detail[colName]);
                break;
            case "PVInfoStatus":
                isEnableEdit(span, detail[colName]);
                break;

            default:
        }
    });
}

//保存程序配置
function saveProEdit(colVals, id) {

    var detail = {};

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {
            case "ProgName":

                var input = span.find("input");
                if (!validatorInputIsEmpty(input, "'程序名称' 不能为空！")) {
                    detail = null;
                    return false;
                }
                if (!validatorProgramNameDouble(input, id)) {
                    detail = null;
                    return false;
                }
                detail.ProgName = input.val();

                break;
            case "GWName":

                var input = span.find("select");
                if (!validatorInputIsEmpty(input, "请选择'工位'！")) {
                    detail = null;
                    return false;
                }
                detail.GWID = input.val();

                break;

                //加一列产品型号ID
            case "Pmodel":

                var input = span.find("select");
                if (!validatorInputIsEmpty(input, "请选择'型号'！")) {
                    detail = null;
                    return false;
                }
                detail.Pmodel = input.val();

                break;

            case "FileNo":
                detail.FileNo = span.find("input").val();
                break;
            case "StartTime":
                detail.StartTime = span.find("input").val();
                break;
            case "CopyRight":
                detail.CopyRight = span.find("input").val();
                break;
            case "Descript":
                detail.Descript = span.find("input").val();
                break;
            case "ProgStatus":
                detail.ProgStatus = span.find("select").val();
                break;
            case "Remark":
                detail.Remark = span.find("input").val();
                break;
            default:
        }
    });

    return detail;
}

//保存程序工序配置
function saveProGXEdit(colVals) {

    var detail = {};
    $.each(colVals, function (index, item) {
        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {
            case "GXName":
                var gxValue = span.find("input");
                //if (gxValue == "") {
                //    validatorInputIsEmpty(input, "请选择或输入'工序'！");
                //    detail = null;
                //    return false;
                //}
                if (!validatorInputIsEmpty(gxValue, "请输入'工序'！")) {
                    detail = null;
                    return false;
                }
                detail.GXName = gxValue.val();
                break;
            case "GXVedio":
                detail.GXVedio = span.find(".GXVedio").val();
                detail.GXVedioFilename = span.find(".fileName").val();
                break;
            case "GXDesc":
                detail.GXDesc = span.find("input").val();
                break;
            case "PGXInfoStatus":
                detail.PGXInfoStatus = span.find("select").val();
                break;
            case "Remark":
                detail.Remark = span.find("input").val();
                break;
            default:
        }
    });

    return detail;
}

//保存程序工步配置
function saveProGBEdit(colVals) {

    var detail = {};

    //获取管控方式
    var controlType = $(colVals[3]).find("select").find("option:selected").text();

    $.each(colVals, function (index, item) {
        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {

            case "GBName":
                //var input = span.find("select");

                var gbValue = span.find("textarea");
                //var gbValue = span.find("input");//LHR 2020-10-27
                //if (gbValue == "") {
                //    validatorInputIsEmpty(gbValue, "请选择'工步'！");
                //    detail = null;
                //    return false;
                //}
                if (!validatorInputIsEmpty(gbValue, "请输入'工步'！")) {
                    detail = null;
                    return false;
                }
                detail.GBName = gbValue.val();
                break;
            case "GBDesc":
                detail.GBDesc = span.find("input").val();
                break;
            case "GBDelayTime":

                var input = span.find("input");
                if (controlType == "时间管控") {
                    detail.GBDelayTime = input.val();
                    if (detail.GBDelayTime == null || detail.GBDelayTime == "" || detail.GBDelayTime == "0" || parseInt(detail.GBDelayTime) < 0) {

                        Ewin.alert({ title: "时间管控", message: "请输入‘工步延长时间’！" });
                        input.focus();
                        detail = null;
                        return false;
                    }
                }
                break;
            case "IsScan":

                var input = span.find("select");

                if (controlType == "扫码管控") {
                    detail.IsScan = input.val();
                    if (detail.IsScan == null || detail.IsScan == "" || detail.IsScan == "0") {

                        Ewin.alert({ title: "扫码管控", message: "请选择‘是否要扫码’为‘是’！" });
                        input.focus();
                        detail = null;
                        return false;
                    }
                }
                break;
            case "IsInputPInfo":
                detail.IsInputPInfo = span.find("select").val();
                break;
            case "IsScanOrderNo":
                detail.IsScanOrderNo = span.find("select").val();
                break;
            case "IsEmpCheck":

                var input = span.find("select");

                if (controlType == "自检管控") {
                    detail.IsEmpCheck = input.val();
                    if (detail.IsEmpCheck == null || detail.IsEmpCheck == "" || detail.IsEmpCheck == "0") {

                        Ewin.alert({ title: "自检管控", message: "请选择‘是否要人工自检确认’为‘是’！" });
                        input.focus();
                        detail = null;
                        return false;
                    }
                }
                break;
            case "ErrTypeName":
                detail.ErrTypeID = span.find("select").val();
                break;
            case "ControlTypeName":
                detail.ControlTypeID = span.find("select").val();
                break;
            case "PGBInfoStatus":
                detail.PGBInfoStatus = span.find("select").val();
                break;
            case "Remark":
                detail.Remark = span.find("input").val();
                break;
            case "GBImage":
                var src = span.find("img").attr("src");
                var split = src.split(",");
                if (split.length > 1) {

                    detail.GBImageBase64 = split[1];

                }
                break;
            default:
        }
    });

    return detail;
}

//保存程序工具配置
function saveProGJEdit(colVals) {

    var detail = {};
    detail.GJOPCTypes = [];

    var inputGJName;
    var inputWLName;

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {
            case "GJName":
                inputGJName = span.find("select");
                break;
            case "WLName":
                inputWLName = span.find("select");
                break;
            case "PGJInfoStatus":
                detail.PGJInfoStatus = span.find("select").val();
                break;
            case "Remark":
                detail.Remark = span.find("input").val();
                break;
            case "materialConfrom":

                //LHR 2020-10-31 物料确认 保存取值
                var opc = {};
                opc.Code = colName;
                opc.Value = span.find("select").val();
                detail.GJOPCTypes.push(opc);

                break;
            default:
                if (span.attr("other") == "auto") {

                    var opc = {};
                    opc.Code = colName;
                    opc.Value = span.find("input").val();

                    detail.GJOPCTypes.push(opc);
                }
                break;
        }
    });
    if (inputGJName.val() === "" && inputWLName.val() === "") {

        Ewin.alert({ title: "输入验证", message: "请选择'工具'或'物料'!" });
        detail = null;

    } else if (inputGJName.val() !== "" && inputWLName.val() !== "") {

        Ewin.alert({ title: "输入验证", message: "'工具'或'物料'只能选择一项!" });
        detail = null;
    }
    if (detail !== null) {

        detail.GJID = inputGJName.val();
        detail.WLID = inputWLName.val();
    }

    return detail;
}

//保存程序工艺配置检测
function saveProValEdit(colVals) {
    var detail = {};
    $.each(colVals, function (index, item) {
        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {
            case "ValueTypeName":

                var input = span.find("select");
                if (!validatorInputIsEmpty(input, "请选择'检测项类型'！")) {
                    detail = null;
                    return false;
                }
                detail.ValueTypeID = input.val();

                break;
            case "EqualTypeName":

                var input = span.find("select");
                if (!validatorInputIsEmpty(input, "请选择'值比较类型'！")) {
                    detail = null;
                    return false;
                }
                detail.EqualTypeID = input.val();

                break;
            case "StandardValue":
                detail.StandardValue = span.find("input").val();
                break;
            case "MinValue":
                detail.MinValue = span.find("input").val();
                break;
            case "MaxValue":
                detail.MaxValue = span.find("input").val();
                break;
            case "PixelPoint":
                detail.PixelPoint = span.find("input").val();
                break;
            case "PVInfoStatus":
                detail.PVInfoStatus = span.find("select").val();
                break;
            case "Remark":
                detail.Remark = span.find("input").val();
                break;
            default:
        }
    });
    return detail;
}

//完成程序配置编辑
function finishPro(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {
            case "StartTime":
                span.html(formatDate(detail[colName]));
                break;
            case "ProgStatus":
                span.html(getIsDisable(detail[colName]))
                break;
            case "GWName":
                var aLink = buildString("<a href=\"/BaseInfo/EditBaseGongWei/{{0}}\" target=\"_self\">{{1}}</a>", detail["GWID"].toString(), detail[colName].toString());
                span.html(aLink)
                break;
            default:
                span.html(detail[colName]);
                break;
        }
    });
}

//完成程序工序配置
function finishProGX(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {
            case "PGXInfoStatus":

                span.html(getIsDisable(detail[colName]))
                break;
                //case "GXName":

                //    //var alink = buildString("<a href=\"/BaseInfo/EditBaseGongxu/{{0}}\" target=\"_self\">{{1}}</a>", detail["GXID"].toString(), detail[colName].toString())
                //    span.html(detail[colName].toString());
                //    break;
            case "GXVedio":
                if (detail[colName] != null) {

                    span.html(buildString("<button type=\"button\" class=\"btn btn-link\" style=\"margin:2px;\" onclick=\"showVideo('/{{0}}')\" >打开视频</button>", detail[colName]));
                } else {

                    span.html("");
                }
                break;
            default:
                span.html(detail[colName]);
                break;
        }
    });
}

//完成程序工步配置
function finishProGB(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {

            case "IsScan":
            case "IsInputPInfo":
            case "IsScanOrderNo":
            case "IsEmpCheck":
                span.html(getIsOK(detail[colName]));
                break;
            case "PGBInfoStatus":
                span.html(getIsDisable(detail[colName]));
                break;
            case "GBImage":
                var imgUrl = getImage(colName, detail) + "&r=" + Math.random();
                if (imgUrl !== "") {
                    dtVal = "<img width=\"60\" height=\"60\" class=\"rounded\" src=\"" + imgUrl + "\" alt=\"图片\" />";
                    span.html(dtVal);
                }
                break;
                //case "GBName":
                //    var alink = buildString("<a href=\"/BaseInfo/EditBaseGongbu/{{0}}\" target=\"_self\">{{1}}</a>", detail["GBID"].toString(), detail[colName].toString())
                //    span.html(alink);
                //    break;

            default:
                span.html(detail[colName]);
                break;
        }
    });
}

//完成程序工具配置
function finishProGJ(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");

        switch (colName) {

            case "PGJInfoStatus":

                span.html(getIsDisable(detail[colName]));

                break;
            case "materialConfrom"://LHR 2020-10-31 添加料确认为 是否下拉框

                $.each(detail.GJOPCTypes, function (index, item) {

                    if (colName == item.Code) {

                        var val = item.Value;
                        if (colName == "materialConfrom") {
                            val = getIsOK(val);
                        }

                        span.html(val);
                    }
                });

                break;

            case "GJImage":

                var imgUrl = getImage(colName, detail);
                if (imgUrl !== "") {
                    dtVal = "<img width=\"60\" height=\"60\" class=\"rounded\" src=\"" + imgUrl + "\" alt=\"图片\" />";
                    span.html(dtVal);
                }

                break;
            case "GJName":

                var alink = buildString("<a href=\"/BaseInfo/EditBaseGongju/{{0}}\" target=\"_self\">{{1}}</a>", detail["GJID"] != null ? detail["GJID"].toString() : "", detail[colName] != null ? detail[colName].toString() : "")
                span.html(alink);
                break;
            default:

                if (span.attr("other") == "auto") {

                    $.each(detail.GJOPCTypes, function (index, item) {

                        if (colName == item.Code) {

                            var val = item.Value;
                            if (colName == "gjwlGet" || colName == "gjwlPut") {
                                val = getShowLight(val);
                            }

                            span.html(val);
                        }
                    });

                } else {
                    span.html(detail[colName]);
                }

                break;
        }
    });
}

//完成程序工艺配置检测
function finishProVal(colVals, detail) {

    $.each(colVals, function (index, item) {

        var span = $(item);
        var colName = span.attr("ColumnName");
        switch (colName) {

            case "PVInfoStatus":
                span.html(getIsDisable(detail[colName]))
                break;
            default:
                span.html(detail[colName]);
                break;
        }
    });

}

//程序配置添加状态
function showAdd(level, keyID, copyID) {

    var lev = level;
    var keyId = keyID;

    if (level == 0) {

        //已经加了空行 就不在添加
        if ($("#proTable tr:eq(1) td:eq(0)").html() == "") {
            return;
        }
        getEmptyTableModel(level, copyID, function (data) {

            table = $("#" + keyId);

            showTableNewRow(table, data, "", copyID);

            var dts = table.find("tr:eq(1)");
            $(dts.find("td")[0]).hide();

            var colVals = dts.find("[columnName]");
            showProEdit(colVals, data.Body[0]);
        });
    } else if (level == 1) {

        getEmptyTableModel(lev, keyID, function (data) {

            table = $("#_collapse_0" + "_" + keyId).find("table").first();
            //添加空行
            showTableNewRow(table, data, keyId, copyID);

            var dts = table.find("tr:eq(1)");
            var colVals = dts.find("[columnName]");

            data.Body[0]["ID"] = "";

            showProGXEdit(colVals, data.Body[0]);
        });

    } else {

        var link = $("#" + keyId);
        var span = link.find("span");
        if (span.length != 0) {

            //将图标改成向右向下的三角形 2019/05/10
            //if ($(span.first()).attr("class").indexOf("glyphicon-triangle-bottom") == -1) {

            //    $(span.first()).removeClass("glyphicon-triangle-right");
            //    $(span.first()).toggleClass("glyphicon-triangle-bottom")
            //}

            //由于fontawesome图标插件升级 将图标改成向右向下的三角形 2020/05/22
            if ($(span.first()).attr("class").indexOf("fa-caret-down fa-2x text-blue") == -1) {

                $(span.first()).removeClass("fa-caret-right fa-2x text-blue");
                $(span.first()).toggleClass("fa-caret-down fa-2x text-blue")
            }

        }

        var id = link.attr("data-id");
        //获取空表结构
        getEmptyTableModel(lev, id, function (data) {

            var level = link.attr("data-level");

            var tr = $("#collapse_" + keyId).parent().parent();

            //显示子表信息（没有就空结构）
            getSubTable(level, id, function () {

                table = $("#collapse_" + keyId).find("table").first();

                data.Body[0]["ID"] = "";

                //添加空行
                showTableNewRow(table, data, id, copyID);

                var dts = table.find("tr:eq(1)");
                var colVals = dts.find("[columnName]");
                switch (lev) {
                    //case "1":
                    //    showProGXEdit(colVals, data.Body[0]);
                    //    break;
                    case "2":
                        showProGBEdit(colVals, data.Body[0]);
                        break;
                    case "3":
                        showProGJEdit(colVals, data.Body[0]);
                        break;
                    case "4":
                        showProValEdit(colVals, data.Body[0]);
                        break;
                    default:
                }
                tr.show();
            });
        });
    }
}

//显示新加行
function showTableNewRow(table, data, parentID, copyID) {

    var tdTemplate = "<td>{{0}}</td>"
    var trTemplete = "<tr>{{0}}</tr>";
    var spanTemplate = "<span {{1}}>{{0}}</span>";
    var buttonTemplate = "<button type=\"button\" class=\"{{1}}\" style=\"width:65px;margin:2px;\" onclick=\"{{2}}\" parent-id=\"{{3}}\" >{{0}}</button>";

    $.each(data.Body, function (index, item) {

        var tdItems = buildString(tdTemplate, "", "", "");

        $.each(data.Title, function (index, name) {

            var dtVal = item[name.Name] == null ? "" : item[name.Name].toString();

            //数据是否需要格式化
            dtVal = format(name, dtVal);

            if (name.Name !== "ID") {

                tdItems += buildString(tdTemplate, buildString(spanTemplate, dtVal, "columnName=\"" + name.Name + "\" other=\"" + name.Other + "\""));
            }

        });

        //添加操作 
        $.each(data.Opertions, function (index, item) {

            var value = "";
            //var icoSave = "<i class=\"glyphicon glyphicon-ok\"></i>";
            //由于fontawesome图标插件升级 修改图标 2020/04/30
            var icoSave = "<i class=\"fas fa-save\"></i>";

            //var icoCancel = "<i class=\"glyphicon glyphicon-remove\"></i>";
            //由于fontawesome图标插件升级 修改图标2020/04/30
            var icoCancel = "<i class=\"fas fa-reply\"></i>";
            var copyIDStr = "";
            if (copyID) {
                copyIDStr = copyID.toString();
            }

            $.each(item.Value, function (subIndex, subItem) {

                switch (subItem.Name) {
                    case "保存":
                        value += buildString(buttonTemplate, icoSave + subItem.Name, "btn btn-primary btn-sm", buildString("saveAdd(this,'{{0}}','{{1}}');", data.Level.toString(), copyIDStr), parentID);
                        break;
                    case "取消":
                        value += buildString(buttonTemplate, icoCancel + subItem.Name, "btn btn-danger btn-sm", "cancelAdd(this);", "");
                        break;
                    default:
                }
            });

            tdItems += buildString(tdTemplate, value);

        });

        var value = buildString(trTemplete, tdItems);

        if (table.find("tbody tr").length == 0) {

            table.find("tbody").after(value);

        } else {

            table.find("tr:eq(1)").before(value);

        }

    });
}

//保存添加操作
function saveAdd(btn, level, copyID) {
    var lev = level;
    var detail = {}

    var dts = $(btn).parent().parent();
    var colVals = dts.find("[columnName]");

    //get parent id
    var id = "";
    if (level != "0") {
        id = $(btn).attr("parent-id");
    }

    var url = "";
    switch (level) {
        case "0":
            url = "/Program/AddPro";
            if (copyID) {
                url = "/Program/CopyPro?id=" + copyID;

            }
            detail = saveProEdit(colVals);
            break;
        case "1":
            url = "/Program/AddProGX";
            detail = saveProGXEdit(colVals);
            if (detail != null) {
                detail.ProgID = id;
            }
            break;
        case "2":
            url = "/Program/AddProGB";
            detail = saveProGBEdit(colVals);
            if (detail != null) {
                detail.ProgGXID = id;
            }
            break;
        case "3":
            url = "/Program/AddProGJ";
            detail = saveProGJEdit(colVals);
            if (detail != null) {
                detail.ProgGbInfoID = id;
            }
            break;
        case "4":
            url = "/Program/AddProVal";
            detail = saveProValEdit(colVals);
            detail.ProgGjInfoID = id;
            break;
        default:
    }

    if (detail == null) {
        return;
    }

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(detail),
        contentType: "application/json",
        dataType: "text",
        success: function (success) {

            //重新查询
            if (lev == "0") {

                $("#btnSubmit").click();
            } else if (lev == "1") {

                $.ajax({
                    type: "POST",
                    url: "/Program/GetSubTable",
                    data: "subLevel= 1 &id=" + id,
                    dataType: "json",
                    success: function (data) {

                        div = $("#_collapse_0" + "_" + id);

                        div.html("");

                        showSubTable(div, "1", data);

                    }
                });


            } else {

                var alink = $(buildString("#{{0}}_{{1}}", (parseInt(lev) - 1).toString(), id));
                var span = alink.find("span");
                if (span.length == 0) {

                    //var collapseSpan = "<span class=\"glyphicon glyphicon-plus\" onclick=\"collapse(this);\" />";
                    //将图标改成向右向下的三角形 2019
                    //var collapseSpan = "<span class=\"glyphicon glyphicon-triangle-right\" onclick=\"collapse(this);\" />";

                    //由于fontawesome图标插件升级 将图标改成向右向下的三角形 2020/04/30
                    var collapseSpan = "<span class=\"fas fa-caret-right fa-2x text-blue\" onclick=\"collapse(this);\" />";
                    alink.append(collapseSpan);
                }

                span = alink.find("span").first();
                //折叠
                collapse(span);
                //展开
                collapse(span);

            }
        },
        error: function (error) {

            ajaxError(error);

        }
    });
}

//取消添加操作
function cancelAdd(btn) {

    var tr = $(btn).parent().parent();
    var table = tr.parent();
    var tabParent = table.parent();
    var level = tabParent.attr("data-level");
    if (!level) {
        level = tabParent.parent().attr("data-level");
    }
    //如果只剩下title 也删除
    if (table.find("tr").length == 2 && level != "0") {

        table.remove();
    } else {

        tr.remove();
    }
}

//删除操作
function deletePro(btn, level, id) {

    var parent = $(btn).parent();
    var dts = parent.parent();
    var vall = dts.find("[data-level]");

    if (level == "0") {
        var gw_prod_def_id = vall.attr("data-gw_prod_def_id");//加一个列关联表id2019/05/25
        if (typeof gw_prod_def_id == "undefined" || gw_prod_def_id == "") {
            gw_prod_def_id = 0;
        }
        id = gw_prod_def_id;
    }


    var btn = btn;

    Ewin.confirm({ message: "确认要删除选中的数据吗？" }).on(function (e) {

        if (!e) {
            return;
        }
        $.ajax({
            type: "POST",
            url: buildString("/Program/Delete?level={{0}}&id={{1}}", level, id),
            data: "",
            dataType: "text",
            success: function (success) {

                var tr = $(btn).parent().parent();
                var prev = tr.prev();
                //如果只剩下title 也删除
                if (prev.find("th").length > 0) {

                    prev.remove();
                }
                //删除对应的子级
                var levelID = tr.find("td [data-toggle=collapse]").attr("href");
                if (levelID != null) {

                    $("#" + levelID).remove();
                }
                tr.remove();

            },
            error: function (error) {

                ajaxError(error);
            }
        });
    });

}

//排序操作
function orderSet(btn, isUp, level, id) {
    //获取到触发的tr 注意有两行
    var tr = $($(btn).parent().parent());
    var tr1 = tr.next();
    //向上移动
    if (isUp) {
        var prev = tr.prev().prev();

        //获取tr的前一个相同等级的元素是否为空
        if (prev.html() == null) {
            Ewin.alert({ title: "提示", message: "已经是最顶部了!" });
            return;
        }

        setOrderNo(tr, level, -1);
        setOrderNo(prev, level, 1);
        //将本身插入到目标tr的前面 
        tr.insertBefore(prev);
        var prev1 = tr1.prev().prev();
        tr1.insertBefore(prev1);
    } else {
        var next = tr.next().next().next();
        if (next.html() == null) {
            Ewin.alert({ title: "提示", message: "已经是最低部了!" });
            return;
        }
        //将本身插入到目标tr的后面 
        setOrderNo(tr, level, 1);
        setOrderNo(tr.next().next(), level, -1);
        tr.insertAfter(next);
        var next1 = tr1.next().next().next();
        tr1.insertAfter(next1);

    }
    function setOrderNo(dts, level, no) {
        var span;
        switch (level) {
            case "1":
                span = dts.find("[columnName='GXOrder']");
                break;
            case "2":
                span = dts.find("[columnName='GBOrder']");
                break;
            case "3":
                span = dts.find("[columnName='GJOrder']");
                break;
            default:
        }
        span.html(parseInt(span.html()) + no);

    }

    //提交数据到后台
    $.ajax({
        type: "POST",
        url: buildString("/Program/OrderSet?level={{0}}&id={{1}}&isUp={{2}}", level, id, isUp),
        //data: detail,
        dataType: "text",
        success: function (success) {

        },
        error: function (error) {

            ajaxError(error);

        }
    });

}


//多行文本编辑状态LHR 2020-10-27
function textareaEdit(span, val) {
    if (val == null) {
        val = "";
    }
    var textTemplate = "<textarea rows=\"3\" class=\"form-control\" >\{{0}}\</textarea>";
    span.html(buildString(textTemplate, val));
}

//文本编辑状态
function textEdit(span, val) {
    if (val == null) {
        val = "";
    }
    var textTemplate = "<input type=\"text\" class=\"form-control\" value=\"{{0}}\"/>";
    span.html(buildString(textTemplate, val));
}

//数字编辑状态
function numberEdit(span, val) {
    if (val == null || val == "") {
        val = "0";
    }
    var textTemplate = "<input type=\"number\" min=\"0\" onkeyup=\"this.value=this.value.replace(/\D/g,'')\" style='min-width:60px;' class=\"form-control\" value=\"{{0}}\" />";

    span.html(buildString(textTemplate, val.toString()));
}

//combox编辑状态
function comboxEdit(span, selectVal, sources, width) {

    var selectTemplate = "<select style='width:{{1}}px' class=\" form-control combobox\">{{0}}</select>";
    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"

    if (selectVal == null) {
        selectVal = "";
    }

    var opertions = "";
    $.each(sources, function (index, item) {

        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Key == selectVal.toString() ? " selected = \"selected\"" : "");

    });
    span.html(buildString(selectTemplate, opertions, width));
}


////combox编辑状态 2020-11-23 添加 bootstrap-select
//function comboxEdit(span, selectVal, sources, width) {

//    var selectTemplate = "<select style='width:{{1}}px' class=\" selectpicker form-control \" data-live-search=\"true\" >{{0}}</select>";
//    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"

//    if (selectVal == null) {
//        selectVal = "";
//    }

//    var opertions = "";
//    $.each(sources, function (index, item) {

//        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Key == selectVal.toString() ? " selected = \"selected\"" : "");

//    });
//    span.html(buildString(selectTemplate, opertions, width));
//}


//combox编辑状态型号加onchange事件
function comboxEditXH(span, selectVal, sources, width) {

    var selectTemplate = "<select style='width:{{1}}px' class=\" form-control combobox\" onchange=\"selectXH(this);\" id='xh'>{{0}}</select>";
    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"

    if (selectVal == null) {
        selectVal = "";
    }
    var opertions = "";
    $.each(sources, function (index, item) {

        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Key == selectVal.toString() ? " selected = \"selected\"" : "");

    });
    span.html(buildString(selectTemplate, opertions, width));


}

//combox编辑状态工位加onchange事件
function comboxEditGW(span, selectVal, sources, width) {

    var selectTemplate = "<select style='width:{{1}}px' class=\" form-control combobox\" onchange=\"selectGW(this);\" id='gw'>{{0}}</select>";
    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"
    if (selectVal == null) {
        selectVal = "";
    }
    var opertions = "";
    $.each(sources, function (index, item) {

        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Key == selectVal.toString() ? " selected = \"selected\"" : "");

    });
    span.html(buildString(selectTemplate, opertions, width));
}

//comboSelect 
function comboSelectEdit(span, selectVal, sources, width, selectChange) {

    var selectTemplate = "<select style='width:{{1}}px' class=\"select form-control combobox\">{{0}}</select>";
    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"
    if (selectVal == null) {
        selectVal = "";
    }
    var opertions = "";
    $.each(sources, function (index, item) {

        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Value == selectVal.toString() ? " selected = \"selected\"" : "");

    });
    span.html(buildString(selectTemplate, opertions, width));

    var comboSelect = setComboSelect($(span.find(".select")), selectChange);

    comboSelect.closest("span").find("input").val(selectVal);
}



////comboSelect 
//function comboSelectEdit(span, selectVal, sources, width, selectChange) {

//    var selectTemplate = "<select style='width:{{1}}px' class=\"select form-control selectpicker\" data-live-search=\"true\" >{{0}}</select>";
//    var opertionTemplate = "<option value=\"{{0}}\" {{2}} >{{1}}</option>"
//    if (selectVal == null) {
//        selectVal = "";
//    }
//    var opertions = "";
//    $.each(sources, function (index, item) {

//        opertions += buildString(opertionTemplate, item.Key, item.Value, item.Value == selectVal.toString() ? " selected = \"selected\"" : "");

//    });
//    span.html(buildString(selectTemplate, opertions, width));

//    var comboSelect = setComboSelect($(span.find(".select")), selectChange);

//    comboSelect.closest("span").find("input").val(selectVal);
//}

function selectXH(select) {
    // var op = select.innerHTML;
    //var op = select.value;

    var selectXHText = $(select).find("option:selected").text();//获取类型的文本值
    var selectGWText = $(select).parent().parent().parent().find("td [columnname='GWName']").find("option:selected").text();//获取工位的文本值
    $(select).parent().parent().parent().find("td [columnname='ProgName']").find("input").val(selectXHText + " " + selectGWText);//给程序名赋值
}

function selectGW(select) {
    var selectGWText = $(select).find("option:selected").text();//获取工位的文本值
    var selectXHText = $(select).parent().parent().parent().find("td [columnname='Pmodel']").find("option:selected").text();//获取类型的文本值
    $(select).parent().parent().parent().find("td [columnname='ProgName']").find("input").val(selectXHText + " " + selectGWText);//给程序名赋值
}

//日期编辑状态
function timeEdit(span, val) {

    var textTemplate = "<input type=\"text\" class=\"form-control datepicker\" value=\"{{0}}\"/>";
    span.html(buildString(textTemplate, val));
    actionDatepicker();
}

//启用|禁用 状态
function isEnableEdit(span, val) {

    comboxEdit(span, val, [{ Key: "0", Value: "启用" }, { Key: "1", Value: "禁用" }], "100");

}

//是|否 状态
function isOKEdit(span, val) {

    comboxEdit(span, val, [{ Key: "0", Value: "否" }, { Key: "1", Value: "是" }], "100");

}

//验证输入内容
function validatorInputIsEmpty(input, message) {
    var ipt = $(input);
    var borderColor = "#fff";
    var retVal = true;
    if (ipt.val().trim() == "") {

        borderColor = "red";
        Ewin.alert({ title: "输入验证", message: message });
        retVal = false;
    }
    ipt.css("border-color", borderColor);
    return retVal;
}

//验证程序名称重复
function validatorProgramNameDouble(input, id) {

    var ipt = $(input);
    var borderColor = "#fff";
    var retVal = true;
    if (isProgramNameDouble(ipt.val(), id)) {

        borderColor = "red";
        Ewin.alert({ title: "输入验证", message: "'程序名称'已存在！" });
        retVal = false;
    }
    ipt.css("border-color", borderColor);
    return retVal;
}

//验证选择内容
function ajaxError(error) {

    var errorStr = "系统错误！请联系管理员！" + error.responseText;

    if (error.responseText.indexOf("登录 | 润伟产线管理信息系统 RWPMS") != -1) {

        errorStr = "连接超时，请重新登录！";
    }

    Ewin.alert({ title: "错误", message: errorStr });
}

function setComboSelect(select, selectChange) {

    var cmbo = $(select).comboSelect();

    $(select).change(function (e, v) {
        //$('.idx').text(e.target.selectedIndex)
        //
        if (selectChange != null) {
            selectChange(this, e.target.value);
        }
    });

    return cmbo;
}

/*****************视频上传*******************/
//激活视频上传控件的点击事件
function fileBrowse(btn) {

    var parent = $(btn).parent();
    parent.find(".FileUploadVedio").click();
}

//获取文件信息
function getViedoFile(control) {

    var uploadVedio = control.files[0];

    if (uploadVedio != null) {

        var fileExtension = uploadVedio.name.split('.').pop();
        if (fileExtension.toUpperCase() != "MP4") {

            alert("格式不正确，视频文件只能为MP4格式!");

            control.files[0] = null;

            return;
        }
        $(control).parent().find(".fileName").val(uploadVedio.name);
    }
}

//清理视频
function clearVedio(btn) {

    var parent = $(btn).parent();
    parent.find(".fileName").val("");
    parent.find(".GXVedio").val("");
    parent.find(".clearVedio").hide();
    parent.find(".FileUploadVedio")[0].files[0] = null;
    parent.find(".uploadVedio").html('<i class="glyphicon glyphicon-upload"></i>上传');
}

//视频文件上传
function uploadVedio(btn) {

    var parent = $(btn).parent();
    var UploadVedio = parent.find(".FileUploadVedio")[0].files[0];
    if (UploadVedio == null || UploadVedio.name == "") {

        return false;
    }
    //var FileName = UploadVedio.name;
    var formData = new FormData();
    formData.append("FileUploadVedio", UploadVedio);
    $.ajax({
        url: "/BaseInfo/UploadFile",
        type: "post",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {

            Modal.alert({

                text: data.Message, callback: function () {

                    if (data.Result) {

                        $(btn).html('<i class="glyphicon glyphicon-upload"></i>重新上传');

                        parent.find(".clearVedio").show();

                        parent.find(".GXVedio").val(data.Path);

                    }
                }
            });

        },

        error: function (xhr) {

            alert(xhr.responseText);

        }
    });
}
/*****************视频上传*******************/

/*****************图片上传******************/

//激活图片上传控件的点击事件
function imageBrowse(btn) {

    var parent = $(btn).parent();
    parent.find(".ImageUploadVedio").click();
}

//获取图片文件信息
function getImageFile(control) {

    var uploadImage = control.files[0];
    if (uploadImage != null) {
        if (window.FileReader) {
            var reader = new FileReader();
            reader.readAsDataURL(uploadImage);
            //监听文件读取结束后事件    
            reader.onloadend = function (e) {
                $(control).parent().find("img").attr("src", e.target.result);    //e.target.result就是最后的路径地址
            };

            //var reader1 = new FileReader();
            //reader1.readAsArrayBuffer(uploadImage);
            ////监听文件读取结束后事件    
            //reader1.onloadend = function (e) {
            //    //$(".img").attr("src", e.target.result);    //e.target.result就是最后的路径地址
            //    $(control).parent().find(".GBImage").val(e.target.result);
            //};
        }
    }

}

//清理图片
function clearImage(btn) {

    var parent = $(btn).parent();
    parent.find("img").attr("src", "")
}

/*****************图片上传******************/

//二进制数组转换成base64
function arrayBufferToBase64(buffer) {

    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {

        binary += String.fromCharCode(bytes[i]);
    }

    return window.btoa(binary);
}
