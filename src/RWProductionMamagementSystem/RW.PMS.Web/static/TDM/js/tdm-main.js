//Modal提示框
/*
 * 最后更新：2018-10-09 09:32 by yuanyong
 * 控件说明：
 *     用于替换系统的alert与confirm，基于bootstrap3.x进行的二次开发，请确认$("#tempalteModel")有模板内容。
 * 使用说明：
 * Modal.alert("提示内容");
 * Modal.confirm("确认提示");
 * Modal.alert({text:"提示内容",okClick:function(){ alert('点了确认'); }});
 * Modal.alert({text:"提示内容",callback:function(){ alert('页面关闭'); }});
 * Modal.confirm({text:"提示内容",cancelClick:function(){ alert('点了取消');}});
 * options选项说明：
 * title    :   弹出信息的标题
 * text     :   弹出信息的内容
 * btnOK    :   确定按钮的文字信息，默认为"确定"
 * btnCancel:   取消按钮的文字信息，默认为“取消”
 * okClick  :   点击确定后的方法回调（之前是success已过时）
 * cancelClick: 点击取消后的方法回调（之前是error已过时）
 * reload   :   弹出信息关闭后的是否重新加载页面；
*/
$(function () {
    window.Modal = function () {
        var selector = "#commModel";
        var html = $("#templateModel").html();
        var defaultops = { title: "系统提示", text: "提示内容", btnOK: "确定", btnCancel: "取消" };
        var _alert = function (options) {
            var ops = { confirm: false };
            if (typeof (options) == "string") options = { text: options, confirm: false };
            ops = $.extend(ops, defaultops, options);
            _init(ops);
        }
        var _confirm = function (options) {
            var ops = { confirm: true };
            if (typeof (options) == "string") options = { text: options };
            ops = $.extend(ops, defaultops, options);
            _init(ops);
        }

        var _init = function (ops) {
            if ($(selector).text()) {
                $(selector).remove();
                $(".modal-backdrop").remove();
            }

            var ahtml = html.replace("[title]", ops.title).replace("[body]", ops.text).replace("[ok]", ops.btnOK).replace("[cancel]", ops.btnCancel);

            $('body').append(ahtml);

            //$(selector).find(".modal-title").text(ops.title);
            //$(selector).find(".modal-body").text(ops.text);
            //$(selector).find(".btnok").text(ops.btnOK);
            //$(selector).find(".btncancel").text(ops.btnCancel);
            if (!ops.confirm)
                $(selector).find(".btncancel").hide();
            else
                $(selector).find(".btncancel").show();
            $(selector).find(".btnok").unbind("click");
            $(selector).find(".btncancel").unbind("click");
            $(selector).find(".btnok").click(ops.okClick || ops.success);
            $(selector).find(".btncancel").click(ops.cancelClick || ops.error);
            $(selector).on("hide.bs.modal", function (e) {
                if (ops.callback) ops.callback(e);
                if (ops.reload) window.location.reload();
            });
            //debugger;
            $(selector).modal();
        }

        return { alert: _alert, confirm: _confirm, selector: selector };
    }();

    //允许使用confirm样式来自动弹出提示对话框
    $(document).on("click", "a.confirm,button.confirm", function () {
        var text = $(this).data('text') || '提示';
        var url = $(this).data('url');
        var ok = $(this).data('ok') || '确定';
        var method = $(this).data('method');
        Modal.confirm({
            text: text, btnOK: ok, okClick: function () {
                $.ajax({
                    url: url,
                    method: method,
                    success: function (result) {
                        Modal.alert({ text: result.Message, reload: true });
                    }, error: function (xhr, e) {
                        var resp = xhr.responseJSON;
                        if (xhr.status == 404 && !resp)
                            Modal.alert("页面未找到，可能是页面被删除！");
                        else if (!resp)
                            Modal.alert(xhr.statusText);
                        else
                            Modal.alert(resp.Message);
                    }
                });
            }
        });
    });
});

//使用form标签增加ajaxForm属性，可使用ajax提交
$(function () {

    //$(".ajaxForm").validate({
    //    submitHandler: $(".ajaxForm button[type='submit']")
    //});



    //bootstrap3时用于表单验证提交方案
    $(".ajaxForm").bootstrapValidator({
        submitButtons: $(".ajaxForm button[type='submit']")
    });
    $(".ajaxForm").ajaxForm({
        //beforeSubmit: function () { return FormVi(); },
        success: function (result) {
            var url = $(".ajaxForm").data("url");
            Modal.alert({
                text: result.Message, callback: function () {
                    if (result.Result) {
                        if (url)
                            window.location.href = url;
                        else
                            window.location.reload();
                    }
                }
            });
        },
        error: function (xhr, e) {
            var resp = xhr.responseJSON;
            if (resp)
                Modal.alert(resp.Message);
            else
                Modal.alert(xhr.statusText);
        }
    });



});

//通用移除提示内容
function removeItem(text, url) {
    //$("#okDel").removeClass("btn-info");
    //$("#okDel").addClass("btn-danger");
    Modal.confirm({
        text: text, btnOK: "确定删除", okClick: function () {
            $.ajax({
                url: url,
                method: "DELETE",
                success: function (result) {
                    Modal.alert({ text: result.Message, reload: true });
                }, error: function (xhr, e) {
                    var resp = xhr.responseJSON;
                    if (xhr.status == 404 && !resp)
                        Modal.alert("页面未找到，可能是页面被删除！");
                    else if (!resp)
                        Modal.alert(xhr.statusText);
                    else
                        Modal.alert(resp.Message);
                }

            });
        }
    });
}


//通用审核提示内容
function AuditInfo(text, url) {
    //if (state)
    //    Modal.alert({ text: "该信息已通过审核，请勿重复审核！", reload: false });

    Modal.confirm({
        text: text, btnOK: "确定审核", okClick: function () {
            $.ajax({
                url: url,
                method: "post",
                success: function (result) {
                    Modal.alert({ text: result.Message, reload: true });
                }, error: function (xhr) {
                    var resp = xhr.responseJSON;
                    Modal.alert(resp.Message);
                }
            });
        }
    });
}


//清空搜索条件
function ResetCondition() {
    $(".form-control").val("");
}

//修改试验数据详细页面专用
function TestDataDetail(result) {
    Modal.alert({
        text: result.Message, callback: function () {
            if (result.Result) {
                window.location.reload();
            }
        }
    });
}






