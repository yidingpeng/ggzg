$(function () {
    AnomalyYCXX();//异常饼图(本月) 
    AnomalyYY();//人员操作异常饼图(本月) 


    //异常明细情况
    GetUserErrorList();//用户操作装配异常信息 2020-05-18
    getPeopleList();//人员工时汇总信息(本月) 2020-05-25

});


function AnomalyYCXX() {
    $.get("/Home/AnomalyMessage", null, function (result) {
        // 基于准备好的DOM，初始化echarts图表
        var myChart1 = echarts.init(document.getElementById('anomaly'));
        var option1 = {
            //提示框组件,鼠标移动上去显示的提示内容
            color: ['#c23531', '#2f4554', '#61a0a8', '#d48265', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
            title: {
                text: new Date().getMonth() + 1 + '月',
                right: 0,
                textStyle: {
                    color: '#333',
                    fontStyle: 'normal',
                    fontWeight: 'normal',
                    fontSize: 15
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c}次 ({d}%)", //模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。
            },
            legend: {
                orient: 'vertical',
                x: 'left',
                data: (function () {
                    var res = [];
                    var len = result.length;
                    for (var i = 0, size = len; i < size; i++) {
                        res.push({
                            name: result[i].AnomalyType, //data中的名字要与series-data中的列名对应，方可点击操控
                        });
                    }
                    return res;
                })()
            },
            series: [
                {
                    name: '异常情况',
                    type: 'pie',
                    radius: '70%',
                    center: ['57%', '56%'],
                    avoidLabelOverlap: false,
                    label: {
                        normal: {
                            show: true,
                            position: 'outside',
                            formatter: '{b}: {c}次 ({d}%)',//模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。{d}数据会根据value值计算百分比
                            textStyle: {
                                align: 'center',
                                baseline: 'middle',
                                fontFamily: '微软雅黑',
                                fontSize: 14,
                                fontWeight: 'bolder'
                            }
                        },
                    },
                    data: (function () {
                        var res = [];
                        var len = result.length;
                        for (var i = 0, size = len; i < size; i++) {
                            res.push({
                                //通过把result进行遍历循环来获取数据并放入Echarts中
                                name: result[i].AnomalyType,
                                value: result[i].AnomalyCount
                            });
                        }
                        return res;
                    })()
                }
            ]
        }
        if (option1 && typeof option1 === "object") {
            myChart1.setOption(option1, true);
        }
    });
}

function AnomalyYY() {

    $.get("/Home/PeopleAnomaly", null, function (result) {
        // 基于准备好的dom，初始化echarts图表
        var myChartOper = echarts.init(document.getElementById('anomalyOper'));
        var option2 = {
            //提示框组件,鼠标移动上去显示的提示内容
            title: {
                text: new Date().getMonth() + 1 + '月',
                subtext: '',
                right: 0,
                textStyle: {
                    color: '#333',
                    fontStyle: 'normal',
                    fontWeight: 'normal',
                    fontSize: 15
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a}<br/>{b}: {c}次 ({d}%)"//模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。
            },
            legend: {
                type: 'scroll',
                orient: 'vertical',
                //right: 10,
                //top: 20,
                //bottom: 20,
                x: 'left',
                data: (function () {
                    var res = [];
                    var len = result.length;
                    for (var i = 0, size = len; i < size; i++) {
                        res.push({
                            name: result[i].ErrOpen, //data中的名字要与series-data中的列名对应，方可点击操控
                        });
                    }
                    return res;
                })()
            },
            series: [
                {
                    name: '人员操作异常',
                    type: 'pie',
                    radius: '70%',
                    center: ['57%', '56%'],
                    avoidLabelOverlap: false,
                    label: {
                        normal: {
                            show: true,
                            position: 'outside',
                            formatter: '{b}: \n{c}次 ({d}%)',//模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。{d}数据会根据value值计算百分比
                            textStyle: {
                                align: 'center',
                                baseline: 'middle',
                                fontFamily: '微软雅黑',
                                fontSize: 15,
                                fontWeight: 'bolder'
                            }
                        },
                    },
                    data: (function () {
                        var res = [];
                        var len = result.length;
                        for (var i = 0, size = len; i < size; i++) {
                            res.push({
                                //通过把result进行遍历循环来获取数据并放入Echarts中
                                name: result[i].ErrOpen,
                                value: result[i].ErrCount
                            });
                        }
                        return res;
                    })(),
                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        }
        if (option2 && typeof option2 === "object") {
            myChartOper.setOption(option2, true);
        }
    });
}

//格式化日期
function getFDate(date) {
    var d = eval('new ' + date.substr(1, date.length - 2));

    var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate()];
    var ar_time = [d.getHours(), d.getMinutes(), d.getSeconds()];

    for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
    for (var i = 0; i < ar_time.length; i++) ar_time[i] = dFormat(ar_time[i]);

    return ar_date.join('-') + ' ' + ar_time.join(':');
}
function dFormat(i) {
    return i < 10 ? "0" + i.toString() : i;
}





function GetUserErrorList() {
    $("#tbErrList").bootstrapTable({
        url: '/Home/AnomalyDetail',     //请求后台的URL
        theadClasses: "thead-blue",//这里设置表头样式
        method: 'GET',//请求方式
        //toolbar: '#toolbar',//工具按钮用哪个容器
        paginationFirstText: "首页",
        paginationPreText: "上一页",
        paginationNextText: "下一页",
        paginationLastText: "末页",
        undefinedText: '',                       //定义默认undefined文本 默认值：'-'
        striped: true,                      //是否显示行间隔色,是否显示斑马线效果
        showLoading: false,                 //隐藏正在加载
        cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true,                   //是否显示分页（*）
        sortable: true,                     //是否启用排序
        sortOrder: "asc",                   //排序方式
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        showExport: false,                  //是否显示导出
        paginationLoop: false,              //设置为 true 启用分页条无限循环的功能。
        //strictSearch: true,                //
        //showColumns: true,                 //是否显示所有的列（选择显示的列）
        //showRefresh: true,                  //是否显示刷新按钮
        //minimumCountColumns: 2,             //最少允许的列数
        //clickToSelect: true,                //是否启用点击选中行
        //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        showColumns: false,                  //是否显示所有的列（选择显示的列）
        pageNumber: 1,                      //初始化加载第一页，默认第一页,并记录
        pageSize: 5,                       //每页的记录行数（*）
        pageList: [5, 10, 20, 30, 40, 50],     //可供选择的每页的行数（*）
        locale: 'zh-CN',
        search: false,                      //是否显示表格搜索,此搜索是客户端搜索,不进服务端
        uniqueId: "ProdNo",                   //每一行的唯一标识，一般为主键列
        clickToSelect: true,                //点击选中checkbox
        singleSelect: false,                //设置True 将禁止多选
        reorderableRows: false,             //设置拖动排序
        useRowAttrFunc: false,              //设置拖动排序
        queryParams: function (params) {
            var temp = {
                pageSize: params.limit,                             //每页显示[10,20,30,40]数量
                PageIndex: params.offset                           //(params.offset / params.limit) + 1, //页码数量
            }
            return temp;
        },                  //传递数据
        columns: [{
            field: 'ProdNo', title: '产品编号',
            //添加 tooltip浮动title
            formatter: function paramsMatter(value, row, index) {
                if (isDeNull(value)) {
                    return "<span onmouseover='mouseoverText(this);'>" + value + "</span>";
                } else {
                    return "";
                }
            },
            cellStyle: function (value, row, index) {
                return {
                    classes: "MyClass"
                }
            }
        },
        {
            field: 'PmodelDrawingNo', title: '产品型号',
            //添加 tooltip浮动title
            formatter: function paramsMatter(value, row, index) {
                if (isDeNull(value)) {
                    return "<span onmouseover='mouseoverText(this);'>" + value + "</span>";
                } else {
                    return "";
                }
            },
            cellStyle: function (value, row, index) {
                return {
                    classes: "MyClass"
                }
            }
        },
        {
            field: 'ErrGw', title: '异常工位'
        },
        {
            field: 'ErrorName', title: '异常类型'
        },
        {
            field: 'ErrOpen', title: '操作员'
        },
        {
            field: 'ErrorDateText', title: '操作时间',
            //添加 tooltip浮动title
            formatter: function paramsMatter(value, row, index) {
                if (isDeNull(value)) {
                    return "<span onmouseover='mouseoverText(this);'>" + value + "</span>";
                } else {
                    return "";
                }
            },
            cellStyle: function (value, row, index) {
                return {
                    classes: "MyClass"
                }
            }
        },
        {
            field: 'ErrorDesp', title: '异常描述',
            //备注添加 tooltip浮动title
            formatter: function paramsMatter(value, row, index) {
                if (isDeNull(value)) {
                    return "<span onmouseover='mouseoverText(this);'>" + value + "</span>";
                } else {
                    return "";
                }
            },
            cellStyle: function (value, row, index) {
                return {
                    classes: "MyClass"
                }
            }
        }],                //设置列
        showJumpTo: true,                   // 是否显示跳页
        onLoadSuccess: function (res) {

        },
        onLoadError: function () {
        }
    });
}


function mouseoverText(text) {
    if (isDeNull(text.innerHTML)) {
        $(text).tooltip({
            trigger: 'hover',
            animation: true,//在工具提示中应用CSS渐变过渡
            html: true,
            placement: 'top',//如何定位工具提示-自动|顶部|底部|左|右。 left
            title: '<h6>' + text.innerHTML + '</h6>',
            //template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner define-tooltip-inner"></div></div>'
            template: '<div class="tooltip" role="tooltip"><div class="arrow"></div><div class="tooltip-inner"></div></div>'
        }).tooltip('show');
    }
}


function getPeopleList() {
    $("#tbPeopleList").bootstrapTable({
        url: '/Home/PeopleHour',     //请求后台的URL
        theadClasses: "thead-blue",//这里设置表头样式
        method: 'GET',//请求方式
        //toolbar: '#toolbar',//工具按钮用哪个容器
        paginationFirstText: "首页",
        paginationPreText: "上一页",
        paginationNextText: "下一页",
        paginationLastText: "末页",
        undefinedText: '',                       //定义默认undefined文本 默认值：'-'
        striped: true,                      //是否显示行间隔色,是否显示斑马线效果
        showLoading: false,                 //隐藏正在加载
        cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true,                   //是否显示分页（*）
        sortable: true,                     //是否启用排序
        sortOrder: "asc",                   //排序方式
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        showExport: false,                  //是否显示导出
        paginationLoop: false,              //设置为 true 启用分页条无限循环的功能。
        //strictSearch: true,                //
        //showColumns: true,                 //是否显示所有的列（选择显示的列）
        //showRefresh: true,                  //是否显示刷新按钮
        //minimumCountColumns: 2,             //最少允许的列数
        //clickToSelect: true,                //是否启用点击选中行
        //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        showColumns: false,                  //是否显示所有的列（选择显示的列）
        pageNumber: 1,                      //初始化加载第一页，默认第一页,并记录
        pageSize: 5,                       //每页的记录行数（*）
        pageList: [5, 10, 20, 30, 40, 50],     //可供选择的每页的行数（*）
        locale: 'zh-CN',
        search: false,                      //是否显示表格搜索,此搜索是客户端搜索,不进服务端
        uniqueId: "ProdNo",                   //每一行的唯一标识，一般为主键列
        clickToSelect: true,                //点击选中checkbox
        singleSelect: false,                //设置True 将禁止多选
        reorderableRows: false,             //设置拖动排序
        useRowAttrFunc: false,              //设置拖动排序
        queryParams: function (params) {
            var temp = {
                pageSize: params.limit,                             //每页显示[10,20,30,40]数量
                PageIndex: params.offset                           //(params.offset / params.limit) + 1, //页码数量
            }
            return temp;
        },                  //传递数据
        columns: [
        { field: 'EmpName', title: '人员名称' },
        { field: 'RoleName', title: '角色名称' },
        { field: 'Gw_starttimeText', title: '本月最早开始时间' },
        { field: 'Gw_finishtimeText', title: '本月最晚结束时间' },
        { field: 'WorkingHours', title: '总工时' }
        ],                //设置列
        showJumpTo: true,                   // 是否显示跳页
        onLoadSuccess: function (res) {

        },
        onLoadError: function () {
        }
    });
}






////总记录数
//var totalNum = 0;

////总页数
//var totalPage = 0;

////默认每页显示几条数据
//var avageNum = 5;

////默认页码显示几条
//var showPages = 5;

////默认显示第一页
//var currentPage = 1;

//var start = 1;

////判断默认页码数量
//function LoadPage() {
//    if (currentPage > 3) { start = currentPage - 3; }
//    if (totalPage >= showPages && totalPage - start < showPages) { start = totalPage - showPages + 1; }
//}

//LoadPage();
//getUserList(currentPage, avageNum);
//initPagination(totalPage, totalNum);
//PageShow(totalPage, totalNum);
//PageNext();
//与后台交互获取数据，异步加载到页面上
//function getUserList(pageNum, pageSize) {
//    currentPage = pageNum;
//    $("#ErrDetail").html(" ");
//    $.ajax({
//        url: "/Home/AnomalyDetail",
//        method: "get",
//        data: { "PageIndex": pageNum, "PageSize": pageSize },
//        async: false,
//        success: function (data) {
//            if (data.Result) {
//                var length = data.datalist.length;
//                totalNum = data.TotalCount;
//                totalPage = totalNum % pageSize == 0 ? totalNum / pageSize : Math.floor(totalNum / pageSize) + 1;//根据记录条数，计算页数
//                for (var i = 0; i < length; i++) {
//                    var ProdNo = data.datalist[i].ProdNo;
//                    var ProdName = data.datalist[i].ProdName;
//                    var ProdModel = data.datalist[i].ProdModel;
//                    var ErrGw = data.datalist[i].ErrGw;
//                    var ErrorName = data.datalist[i].ErrorName;
//                    var ErrOpen = data.datalist[i].ErrOpen;
//                    var ErrorDate = getFDate(data.datalist[i].ErrorDate);
//                    var ErrorDesp = data.datalist[i].ErrorDesp;
//                    $("#ErrDetail").append(
//                        '<tr>' +
//                        '<td>' + ProdNo + '</td>' +
//                        '<td>' + ProdName + '</td>' +
//                        '<td>' + ProdModel + '</td>' +
//                        '<td>' + ErrGw + '</td>' +
//                        '<td>' + ErrorName + '</td>' +
//                        '<td>' + ErrOpen + '</td>' +
//                        '<td>' + ErrorDate + '</td>' +
//                        '<td>' + ErrorDesp + '</td>' +
//                        '</tr>'
//                    )
//                }
//            }
//        }
//    });
//}



//function initPagination(totalPage, totalNum) {
//    $('#pagination').html(" ");
//    $('#pagination').append(
//        '<ul class="pagination" style="display:inline;">' +
//        '<span style="float: right;">每页显示' +
//        '<select id="dataNum">' +
//        '<option value="5">5</option>' +
//        '<option value="10">10</option>' +
//        '<option value="15">15</option>' +
//        '</select>条记录，总共有' + totalPage + '页，总共' + totalNum + '条记录</span>' +
//        '</ul>'
//    );

//    $("#pagination ul").append(
//        '<li><a href="javascript:void(0);"  id="prev">上一页</a>'
//    );
//}




//function PageShow(totalPage, totalNum) {
//    for (var i = start; i < Math.min(totalPage + 1, start + showPages) ; i++) {
//        $("#pagination ul").append(
//            '<li id="page' + i + '"><a href="javascript:void(0);"  onclick="getUserList(' + i + ',' + avageNum + ')">' + i + '</a>'
//        );
//    }

//    $("#pagination ul").append(
//       '<li class="xiayiye"><a href="javascript:void(0);"  id="next">下一页</a>'
//    );
//}


//function PageNext() {

//    $("select option[value=" + avageNum + "]").attr('selected', true)
//    $("#page1").addClass("active");
//    checkA();
//}


////很关键，因为执行initPagination方法时，将select删除再重新添加，所以需要先将select上的结点移除off
////然后再绑定结点on，如果不这么做，会出现change事件只被触发一次。
//$(document).off('change', '#dataNum').on('change', '#dataNum', function () {
//    avageNum = $(this).children('option:selected').val();
//    currentPage = 1;
//    getUserList(currentPage, avageNum);
//    LoadPage();
//    initPagination(totalPage, totalNum);
//    PageShow(totalPage, totalNum);
//    PageNext();
//    checkA();

//});


////设置分页栏点击时候的高亮
//$("#pagination").on("click", "li", function () {
//    var aText = $(this).find('a').html();
//    checkA();
//    if (aText == "上一页") {
//        getUserList(currentPage - 1, avageNum);//加载分页数据

//        LoadPage();//判断默认页码
//        initPagination(totalPage, totalNum);//加载上一页、分页导航
//        PageShow(totalPage, totalNum);//循环加载页码、下一页
//        PageNext();
//        checkA();//判断上一页下一页禁用样式

//        $(".pagination > li").removeClass("active");//移除所有li的选中样式
//        $("#page" + (currentPage)).addClass("active");//附加页码选中样式
//    } else if (aText == "下一页") {
//        getUserList(currentPage + 1, avageNum);//加载分页数据

//        LoadPage();//判断默认页码
//        initPagination(totalPage, totalNum);//加载上一页、分页导航
//        PageShow(totalPage, totalNum);//循环加载页码、下一页
//        PageNext();
//        checkA();//判断上一页下一页禁用样式

//        $(".pagination > li").removeClass("active");//移除所有li的选中样式
//        $("#page" + (currentPage)).addClass("active");//附加页码选中样式

//    } else {
//        $(".pagination > li").removeClass("active");
//        $(this).addClass("active");
//    }
//})

////因为其他地方都需要用到这两句，所以封装出来
////主要是用于检测当前页如果为首页，或者尾页时，上一页和下一页设置为不可选中状态
//function checkA() {
//    currentPage == 1 ? $("#prev").addClass("btn btn-default disabled") : $("#prev").removeClass("btn btn-default disabled");
//    currentPage == totalPage ? $("#next").addClass("btn btn-default disabled") : $("#next").removeClass("btn btn-default disabled");
//}
