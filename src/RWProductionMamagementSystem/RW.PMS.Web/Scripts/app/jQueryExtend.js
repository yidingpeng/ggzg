(function ($) {
    $.fn.extend({
        TableRowClick: function (id) {
            var AppID = $(this).children("#" + id).text();
            return AppID;
        },
        TableIni: function () {
            $(this).children("tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                //给这行添加class值为over，并且当鼠标一出该行时执行函数
                $(this).removeClass("over");
            }).click(function () { //移除该行的class               
                $(this).siblings().removeClass("bg2");
                $(this).removeClass("over").toggleClass("bg2");
                $(this).children("tr").addClass("bg2");
            });
            $(this).children("tr:even").addClass("bg1");
        }
    })
})(jQuery)