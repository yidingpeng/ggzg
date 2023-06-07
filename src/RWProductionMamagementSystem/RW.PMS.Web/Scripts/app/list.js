var AppID;
$(function(){
   
})
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

function Create(controller) {
        var url = "/{0}/Create".format(controller);
        window.document.location.href = url;
}

function Create(controller,para) {
    var url = "/{0}/Create?{1}".format(controller, para);
    window.document.location.href = url;
}


function Edit(controller) {
    if (AppID) {
        var url = "/{0}/Edit/{1}".format(controller, AppID);
        window.document.location.href = url;       
    }
    else {
        alert("请选择修改记录！");
    }
}

function Details(controller) {
    if (AppID) {
        var url = "/{0}/Details/{1}".format(controller, AppID);
        window.document.location.href = url;
    }
    else {
        alert("请选择记录！");
    }
}


function Delete(controller) {
    if (AppID) {
        confirm("是否删除当前选中数据",function(){
            var url = "/{0}/Delete/{1}".format(controller,AppID);
            $.ajax({
                type: "POST",
                data:{id:AppID},
                url: url,
                datatype: "json",
                success: function (result) {
                    if (!result) {
                        if (controller == "Enterprise" || controller == "Products") {
                            alert("已经产生业务数据，不能删除！");
                            //window.document.location.href = "/{0}/Index".format(controller);
                        }
                    }
                    Inti(1);
                }
            });
        });
    }
    else {
        alert("请选择删除记录！");
    }
}
//批量删除产品细则
function DelBatch(controller) {
   // return false;
    if (AppID) {
        confirm("是否确认批量删除该产品下核查细则", function () {
            var url = "/{0}/DelBatch/{1}".format(controller);
            $.ajax({
                type: "POST",
                data: { id: AppID },
                url: url,
                datatype: "json",
                success: function (result) {
                    if (!result||result=="false") {
                        if (controller == "Enterprise" || controller == "Products" || controller == "SupervisionItem") {
                            alert("已经产生业务数据，不能删除！");
                            //window.document.location.href = "/{0}/Index".format(controller);
                        }
                    }
                    Inti(1);
                }
            });
        });
    }
    else {
        alert("请选择删除记录！");
    }
}
function ResultCallBack(type,id) {
    if (type && id) {
        var url = "";
        if (type.toUpperCase().indexOf("ZT") > -1) {
            url = "/ResultCallBack/StopReceiveCallBack/{0}".format(id);
        } else if (type.toUpperCase().indexOf("HX") > -1) {
            url = "/ResultCallBack/RepairCallBack/{0}".format(id);
        }else{
            url = "/ResultCallBack/RectificationCallBack/{0}".format(id);
        }
        window.document.location.href = url;
    }
    else {
        alert("请选择修改记录！");
    }
}


function ResetPassword() {
    if (AppID) {
        url = "/User/ResetPassWord/{0}".format(AppID);
        $.ajax({
            type: "POST",
            url: url,
            success: function () {
                //Inti(1);
            }
        });
    }
    else {
        alert("请选择修改记录！");
    }
}

function GenerateAccount() {
    url = "/User/GenerateEnterpriseAccount";
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            Inti(1);
        }
    });
}

function GeneratePersonAcount(controller)
{
    if (AppID) {
        $.ajax({
            data:{ID:AppID},
            type: "POST",
            url: "/{0}/IsExistsPersonCode".format(controller),
            success: function (result) {
                if (result) {
                    var url = "/{0}/GenerateAcount/{1}".format(controller, AppID);
                    window.document.location.href = url;
                } else
                {
                    alert("已经生成账号，无需再生成！");
                }
            }
        });
       
    }
    else {
        alert("请选择修改记录！");
    }
}
var timestamp = function (){
    return new Date().getTime();
}

function UserEnable(controller)
{
  if (AppID) {
        $.ajax({
            data: { UserID: AppID },
            type: "POST",
            url: "/{0}/Enable/{1}".format(controller, AppID),
            success: function () {
                alert("启用成功！");
                Inti(1);
            }
        });
       
    }
    else {
        alert("请选择修改记录！");
    }
}

function UserDisable(controller) {
    if (AppID) {
        $.ajax({
            data: { UserID: AppID },
            type: "POST",
            url: "/{0}/Disable/{1}".format(controller, AppID),
            success: function () {
                alert("禁用成功！");
                Inti(1);
            }
        });

    }
    else {
        alert("请选择修改记录！");
    }
}
function ChangeNoticeType(type)
{
    var result = "";
    switch (type)
    {
        case "ZT": result = "暂停通知书"; break;
        case "HX": result = "回修通知书"; break;
        case "ZG": result = "整改通知书"; break;
        case "ZD": result = "重大不符合项"; break;
    }
    return result;
}