$(function () {
    var Starttime = $("[name=Starttime]").val();
    var Endtime = $("[name=Endtime]").val();
    CarNo(Starttime, Endtime);//车号
    CarModel(Starttime, Endtime);//车型
  
})

function onclic() {
    var Starttime = $("[name=Starttime]").val();
    var Endtime = $("[name=Endtime]").val();
    CarNo(Starttime, Endtime);//车号
    CarModel(Starttime, Endtime);//车型
}

//车厢号
function CarNo(Starttime, Endtime) {

    $.get("/Data/GetPercentPass2?Starttime=" + Starttime + "&Endtime=" + Endtime + "", null, function (result) {
        if (result.length > 0) {
            var carNodom = document.getElementById("carNo");
            var myChartCar = echarts.init(carNodom);
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
                            type: ['bar', 'line']
                        },
                        restore: { //重置
                            show: true
                        },
                        saveAsImage: {//保存图片
                            show: true
                        }
                    }
                },
                legend: {
                    data: ['合格数', '不合格数', '合格率']
                },
                xAxis: [
                    {
                        type: 'value',
                        name: '数量',
                        show: true,
                        boundaryGap: ['0%', '20%']

                    },
                    {
                        type: 'value',
                        name: '合格率',
                        min: 0,
                        max: 100,
                        interval: 10,
                        axisLabel: {
                            formatter: '{value} %'
                        },
                        splitLine: { //网格
                            show: false
                        },
                    }
                ],
                yAxis: [
                    {
                        type: 'category',
                        data: (function () {
                            var res = [];
                            var len = result.length;
                            for (var i = 0, size = len; i < size; i++) {
                                res.push(
                                    result[i].pf_compartNo //data中的名字要与series-data中的列名对应，方可点击操控
                                );
                            }
                            return res;
                        })(),
                        axisPointer: {
                            type: 'shadow'
                        }
                    }
                ],
                
                series: [
                    {
                        name: '合格数',
                        type: 'bar',
                        barGap: '0%',//柱图间距
                        barCategoryGap: '10%',//多个并排柱子设置柱子之间的间距
                        barWidth: '50%',//柱图宽度
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true, //开启显示
                                    position: 'right', //在右方显示
                                    textStyle: { //数值样式
                                        color: 'black',
                                        fontSize: 16
                                    }
                                },
                                color: '#02DF82'
                            }
                        },
                        data: (function () {
                            var res1 = [];
                            var len1 = result.length;
                            for (var i = 0, size = len1; i < size; i++) {
                                res1.push(
                                    result[i].Okqty
                                );
                            }
                            return res1;
                        })()
                    },
                    {
                        name: '不合格数',
                        type: 'bar',
                        barGap: '0%',//柱图间距
                        barCategoryGap: '10%',//多个并排柱子设置柱子之间的间距
                        barWidth: '50%',//柱图宽度
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true, //开启显示
                                    position: 'right', //在上方显示
                                    textStyle: { //数值样式
                                        color: 'black',
                                        fontSize: 16
                                    }
                                },
                                color: '#E1E100'
                            }
                        },
                        data: (function () {
                            var res1 = [];
                            var len1 = result.length;
                            for (var i = 0, size = len1; i < size; i++) {
                                res1.push(
                                    result[i].Errorqty
                                );
                            }
                            return res1;
                        })()
                    },
                    {
                        name: '合格率',
                        type: 'line',
                        xAxisIndex: 1,
                        data: (function () {
                            var res2 = [];
                            var len2 = result.length;
                            for (var i = 0, size = len2; i < size; i++) {
                                res2.push(
                                    result[i].OkRate
                                );
                            }
                            return res2;
                        })()
                    }
                ]
            };
            if (option && typeof option === "object") {
                myChartCar.setOption(option, true);
            }
        }
    });
}

//转向架号
function CarModel(Starttime, Endtime) {

    $.get("/Data/GetPercentPass1?Starttime=" + Starttime + "&Endtime=" + Endtime + "", null, function (result) {
        if (result.length > 0) {
            var carNodom = document.getElementById("carModel");
            var myChartCar = echarts.init(carNodom);
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
                            type: ['bar', 'line']
                        },
                        restore: { //重置
                            show: true
                        },
                        saveAsImage: {//保存图片
                            show: true
                        }
                    }
                },
                legend: {
                    data: ['合格数', '不合格数', '合格率']
                },
                xAxis: [
                    {
                        type: 'value',
                        name: '数量',
                        show: true,
                        boundaryGap: ['0%', '20%']

                    },
                    {
                        type: 'value',
                        name: '合格率',
                        min: 0,
                        max: 100,
                        interval: 10,
                        axisLabel: {
                            formatter: '{value} %'
                        },
                        splitLine: { //网格
                            show: false
                        },
                    }
                ],
                yAxis: [
                    {
                        type: 'category',
                        data: (function () {
                            var res = [];
                            var len = result.length;
                            for (var i = 0, size = len; i < size; i++) {
                                res.push(
                                    result[i].pf_bogieNo //data中的名字要与series-data中的列名对应，方可点击操控
                                );
                            }
                            return res;
                        })(),
                        axisPointer: {
                            type: 'shadow'
                        }
                    }
                ],

                series: [
                    {
                        name: '合格数',
                        type: 'bar',
                        barGap: '0%',//柱图间距
                        barCategoryGap: '10%',//多个并排柱子设置柱子之间的间距
                        barWidth: '50%',//柱图宽度
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true, //开启显示
                                    position: 'right', //在右方显示
                                    textStyle: { //数值样式
                                        color: 'black',
                                        fontSize: 16
                                    }
                                },
                                color: '#02DF82'
                            }
                        },
                        data: (function () {
                            var res1 = [];
                            var len1 = result.length;
                            for (var i = 0, size = len1; i < size; i++) {
                                res1.push(
                                    result[i].Okqty
                                );
                            }
                            return res1;
                        })()
                    },
                    {
                        name: '不合格数',
                        type: 'bar',
                        barGap: '0%',//柱图间距
                        barCategoryGap: '10%',//多个并排柱子设置柱子之间的间距
                        barWidth: '50%',//柱图宽度
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true, //开启显示
                                    position: 'right', //在上方显示
                                    textStyle: { //数值样式
                                        color: 'black',
                                        fontSize: 16
                                    }
                                },
                                color: '#E1E100'
                            }
                        },
                        data: (function () {
                            var res1 = [];
                            var len1 = result.length;
                            for (var i = 0, size = len1; i < size; i++) {
                                res1.push(
                                    result[i].Errorqty
                                );
                            }
                            return res1;
                        })()
                    },
                    {
                        name: '合格率',
                        type: 'line',
                        xAxisIndex: 1,
                        data: (function () {
                            var res2 = [];
                            var len2 = result.length;
                            for (var i = 0, size = len2; i < size; i++) {
                                res2.push(
                                    result[i].OkRate
                                );
                            }
                            return res2;
                        })()
                    }
                ]
            };
            if (option && typeof option === "object") {
                myChartCar.setOption(option, true);
            }
        }
    });
}