$(function () {
    var Starttime = $("[name=Starttime]").val();
    var Endtime = $("[name=Endtime]").val();
    Circle(Starttime, Endtime);//饼形图
    Line(Starttime, Endtime);//折线图
    Pillar(Starttime, Endtime);//柱状图
})

function onclic() {
    var Starttime = $("[name=Starttime]").val();
    var Endtime = $("[name=Endtime]").val();
    Circle(Starttime, Endtime);//饼形图
    Line(Starttime, Endtime);//折线图
    Pillar(Starttime, Endtime);//柱状图
}

function formatDate(val, formatType) {
    if (val == undefined) {
        return '';
    }
    var reg = /^\/Date\(\d+\)\/$/;
    if (!reg.test(val)) return '';//格式不正确 ，返回空
    var strDate = val.substr(1, val.length - 2);
    var obj = eval('(' + "{ date :new " + strDate + "}" + ')')
    var date = obj.date;
    var year = date.getFullYear();
    var month = date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1;
    var day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
    var datetime = year + '-' + month + '-' + day;

    if (formatType == 'yyyy-MM-dd') {
        return datetime;
    } else if (formatType == 'yyyy-MM-dd HH:mm:ss') {
        var hour = date.getHours() < 10 ? '0' + date.getHours() : date.getHours();
        var minute = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes();
        var seconds = date.getSeconds() < 10 ? '0' + date.getSeconds() : date.getSeconds();
        return datetime + ' ' + hour + ':' + minute + ':' + seconds;
    }
    return datetime;
}

//柱状图
function Pillar(Starttime, Endtime) {
    $.get("/Data/GetHitchPillar?Starttime=" + Starttime + "&Endtime=" + Endtime + "", null, function (result) {
        if (result.datalist.length > 0) {
            var dom = document.getElementById("operateErrorPillar");
            var myChart = echarts.init(dom);
            option = null;
            option = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {
                        type: 'shadow',
                        crossStyle: {
                            color: '#999'
                        }
                    }
                },
                toolbox: { //可视化的工具箱
                    show: false,
                    feature: {
                        dataView: { //数据视图
                            show: true
                        },
                        magicType: {//动态类型切换
                            type: ['bar']
                        },
                        restore: { //重置
                            show: true
                        },
                        saveAsImage: {//保存图片
                            show: true
                        }
                    }
                },
                grid: {
                    left: '0%',
                    right: '0%',
                    top: '15%',
                    bottom: '1%',
                    containLabel: true
                },
                legend: {
                    data: ['异常数', '异常率']
                },
                xAxis: [
                    {
                        type: 'category',
                        axisLabel: {
                            interval: 0,
                            rotate: 20
                        },//调整字体倾斜度
                        axisPointer: {
                            type: 'shadow'
                        },
                        data: (function () {
                            var res = [];
                            var len = result.datalist.length;
                            for (var i = 0, size = len; i < size; i++) {
                                res.push(
                                     formatDate(result.datalist[i].createtime,"yyyy-MM-dd")
                                );
                            }
                            return res;
                        })()
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: '数量',
                        show: true,
                        boundaryGap: ['0%', '20%']
                    },
                    {
                        type: 'value',
                        name: '异常率',
                        min: 0,
                        max: 100,
                        interval: 10,
                        axisLabel: {
                            formatter: '{value} %'
                        },
                        splitLine: { //y轴网格
                            show: false
                        },
                    }
                ],
                series: [
                    {
                        name: '异常数',
                        type: 'bar',
                        barGap: '0%',//柱图间距
                        barCategoryGap: '10%',//多个并排柱子设置柱子之间的间距
                        barWidth: 50,//柱图宽度
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true, //开启显示
                                    position: 'top', //在上方显示
                                    textStyle: { //数值样式
                                        color: 'black',
                                        fontSize: 16
                                    }
                                },
                                color: '#18e0ff'
                            }
                        },
                        data: (function () {
                            var res1 = [];
                            var len1 = result.datalist.length;
                            for (var i = 0, size = len1; i < size; i++) {
                                res1.push(
                                    result.datalist[i].count
                                );
                            }
                            return res1;
                        })()
                    },
                    {
                        name: '异常率',
                        type: 'line',
                        symbolSize: [9, 9], //标记点大小
                        yAxisIndex: 1,
                        color: '#e05659',
                        data: (function () {
                            var res2 = [];
                            var len2 = result.datalist.length;
                            for (var i = 0, size = len2; i < size; i++) {
                                res2.push(
                                    result.datalist[i].count / result.Total * 100
                                );
                            }
                            return res2;
                        })()
                    }
                ]
            };
            if (option && typeof option === "object") {
                myChart.setOption(option, true);
            }
        }
    });
}

//饼形图
function Circle(Starttime, Endtime) {
    $.get("/Data/GetHitchCircle?Starttime=" + Starttime + "&Endtime=" + Endtime + "", null, function (result) {
        // 基于准备好的dom，初始化echarts图表
        var myChart1 = echarts.init(document.getElementById('operateErrorCircle'));
        var option1 = {
            //提示框组件,鼠标移动上去显示的提示内容
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b}: {c} ({d}%)"//模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。
            },
            legend: {
                orient: 'vertical',
                x: 'left',
                data: (function () {
                    var res = [];
                    var len = result.length;
                    for (var i = 0, size = len; i < size; i++) {
                        res.push({
                            name: result[i].faultClass, //data中的名字要与series-data中的列名对应，方可点击操控
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
                    center: ['50%', '55%'],
                    avoidLabelOverlap: false,
                    label: {
                        normal: {
                            show: true,
                            position: 'outside',
                            formatter: '{b}:{c} ({d}%)',//模板变量有 {a}、{b}、{c}、{d}，分别表示系列名，数据名，数据值，百分比。{d}数据会根据value值计算百分比
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
                                name: result[i].faultClass,
                                value: result[i].count
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


//折线图
function Line(Starttime, Endtime) {
    $.get("/Data/GetHitchLine?Starttime=" + Starttime + "&Endtime=" + Endtime + "", null, function (result) {
        // 基于准备好的dom，初始化echarts图表
        var myChart1 = echarts.init(document.getElementById('operateErrorLine'));
        var option1 = {
                title: {
                    text: ''
                },
                tooltip: {},
                legend: {
                    data: ['异常数']
                },
                grid: {
                    left: '0%',
                    right: '0%',
                    top: '15%',
                    bottom: '1%',
                    containLabel: true
                },
                xAxis: {
                    data: (function () {
                        var res = [];
                        var len = result.length;
                        for (var i = 0, size = len; i < size; i++) {
                            res.push(result[i].faultLevel);
                        }
                        return res;
                    })()
                },
                yAxis: {},
                series: [{
                    name: '异常数',
                    type: 'line',//图表类型 line
                    symbolSize: [9, 9], //标记点大小
                    data: (function () {
                        var res = [];
                        var len = result.length;
                        for (var i = 0, size = len; i < size; i++) {
                            res.push(result[i].count);
                        }
                        return res;
                    })()
                }]
            }
        if (option1 && typeof option1 === "object") {
            myChart1.setOption(option1, true);
        }
    });

    }