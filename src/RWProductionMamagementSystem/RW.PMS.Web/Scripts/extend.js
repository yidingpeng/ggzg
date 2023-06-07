String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined || arguments[i] == null) {
                    //var reg = new RegExp("({[" + i + "]})", "g");//这个在索引大于9时会有问题，谢谢何以笙箫的指出
                    var reg = new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, (arguments[i] == null ? "" : arguments[i]));
                }
            }
        }
    }
    return result;
}
 
function Page(CurrentPage, TotalNumber, Pages) {
    var p = "";
    if (CurrentPage == 1 && CurrentPage == Pages) {
        p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a >上一页</a> </li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur='Inti(this.value)' /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((CurrentPage - 1), (CurrentPage + 1), Pages, TotalNumber, CurrentPage);
    }
    else if (CurrentPage == 1) {
        p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a  >上一页</a></li>&nbsp;&nbsp;<li  ><a href='#'  onclick='Inti({1})'>下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur='Inti(this.value)' /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((CurrentPage - 1), (CurrentPage + 1), Pages, TotalNumber, CurrentPage);
    } else if (CurrentPage == Pages) {
        p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#'  onclick='Inti({0})'>上一页</a></li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur='Inti(this.value)' /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((CurrentPage - 1), (CurrentPage + 1), Pages, TotalNumber, CurrentPage);
    } else {
        p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#' onclick='Inti({0})'>上一页</a></li>&nbsp;&nbsp;<li ><a href='#'  onclick='Inti({1})'>下一页</a></li> <li>&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}'  onblur='Inti(this.value)' /> 页 <input type=\"button\" value=\"GO\" /></li></ul></nav>".format((CurrentPage - 1), (CurrentPage + 1), Pages, TotalNumber, CurrentPage);
    }
    return p;
}
/*跳转前的验证*/
function IntiCheck(PageMothed, redirectPage, CurrentPage, TotalNumber, Pages) {
    if (redirectPage < Pages && redirectPage <= 0) {
        Inti(1);

    } else if (redirectPage > Pages && redirectPage >= 0) {
        Inti(Pages);
    } else if (redirectPage >= CurrentPage || redirectPage <= Pages) {
        if (PageMothed) {
            PageMothed(redirectPage);
        } else {
            Inti(redirectPage);
        }
    }

}
function Page(CurrentPage, TotalNumber, Pages, PageMothed) {
    var p = "";
    if (PageMothed) {
        if (CurrentPage == 1 && CurrentPage == Pages) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a >上一页</a> </li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck({5}, this.value, {4},{3}, {2})\"    /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage, PageMothed);
        }
        else if (CurrentPage == 1) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a  >上一页</a></li>&nbsp;&nbsp;<li  ><a href='#'  onclick='{5}({1})'>下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck({5}, this.value, {4},{3}, {2})\"  /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage, PageMothed);
        } else if (CurrentPage == Pages) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#'  onclick='{5}({0})'>上一页</a></li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck({5}, this.value, {4},{3}, {2})\"  /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage, PageMothed);
        } else {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#' onclick='{5}({0})'>上一页</a></li>&nbsp;&nbsp;<li ><a href='#'  onclick='{5}({1})'>下一页</a></li> <li>&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck({5}, this.value, {4},{3}, {2})\" /> 页 <input type=\"button\" value=\"GO\" /></li></ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage, PageMothed);
        }
    } else {
        if (CurrentPage == 1 && CurrentPage == Pages) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a >上一页</a> </li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck('',this.value,{4},{3}, {2})\" /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage);
        }
        else if (CurrentPage == 1) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li class='previous disabled'><a  >上一页</a></li>&nbsp;&nbsp;<li  ><a href='#'  onclick='Inti({1})'>下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck('',this.value,{4},{3}, {2})\"  /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage);
        } else if (CurrentPage == Pages) {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#'  onclick='Inti({0})'>上一页</a></li>&nbsp;&nbsp;<li  class='previous disabled'><a href='#'  >下一页</a></li><li>&nbsp;&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}' onblur=\"IntiCheck('',this.value,{4},{3}, {2})\" /> 页 <input type=\"button\" value=\"GO\" /></li> </ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage);
        } else {
            p = "<nav> <ul class='pager' style='margin:10px auto;'> <li ><a href='#' onclick='Inti({0})'>上一页</a></li>&nbsp;&nbsp;<li ><a href='#'  onclick='Inti({1})'>下一页</a></li> <li>&nbsp;&nbsp;共{2}页&nbsp;&nbsp;&nbsp;{3}条数据&nbsp;&nbsp;&nbsp;当前第<span id=\"spCurrentPage\">{4}</span>页，跳转至：<input type='number' value='{4}'  onblur=\"IntiCheck('',this.value,{4},{3}, {2})\" /> 页 <input type=\"button\" value=\"GO\" /></li></ul></nav>".format((Number(CurrentPage) - 1), (Number(CurrentPage) + 1), Pages, TotalNumber, CurrentPage);
        }
    }
    return p;
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