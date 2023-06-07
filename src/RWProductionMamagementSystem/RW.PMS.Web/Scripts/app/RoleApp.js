var roleApp = (function () {
    var app = {};
    var Status = { '1': '启用', '0': '禁用' };
    app.InIt = function (PageIndex) {
        $.ajax({
            url: "/Role/Page",
            type: "POST",
            dataType: "json",
            data: { PageIndex: PageIndex },
            success: function (data) {
                var html = "";
                if (data) {
                    var list = (new Function("return " + data.json))();
                    var TotalNumber = data.TotalNumber;
                    var Pages = data.Pages;
                    for (var i = 0; i < list.length; i++) {
                        html += "<tr><td>{0}</td><td id='OrganizationCode' style='display:none'>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td class=\"qx\"><a href='/Role/Permission/{1}'>分配权限</a> | <a href='/Role/DataAuth/{1}'>数据权限</a> | <a href='/Role/AssignUser/{1}'>指定用户</a></td></tr>".format(((PageIndex-1)*10+i + 1), list[i].Code, list[i].NAME, Status[list[i].Status], list[i].Remark);
                    }
                    //html += "<tr><td colspan=4>{0}</td></tr>".format(Page(PageIndex, TotalNumber, Pages));
                } else {

                    html += "<tr><td conspan=4>暂无数据</td></tr>";
                }
                $("#Page").html(Page(PageIndex, TotalNumber, Pages));
                $("#tbody").html(html).TableIni();
                $("#tbody tr").bind("click", function (event) {
                    AppID = $(this).TableRowClick("OrganizationCode");
                });
            },
            error: function (e) {
                alert(e.toString());
            }
        });
    }
    return app;
})();
$(document).ready(function () {
    roleApp.InIt(1);
});
function Inti(PageIndex)
{
    roleApp.InIt(PageIndex);
}