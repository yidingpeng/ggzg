/*
* 在引入该JS文件之前，必须先引入jquery.js, jquery.webcam.js(摄像头js), jquery.jqprint-0.3.js(打印), 
* jquery.autocomplete.js(自动补充), layer.js(弹出框), laypage.js(分页), dtree.js(树形控件)
* @Author:Leon 李明达
*/

var leonhelper = leonhelper || {};

if (!$.browser) $.browser = {};

var laypage = window.laypage || null;
if (laypage) laypage.dir = false; //不加载默认css

function UploadObj(html, add, source) {
    this.html = html;
    this.add = add;
    this.source = source;
};

//Datatables语言
var objDatatablesLanguage = {
    "sProcessing": "处理中...",
    "sLengthMenu": "显示 _MENU_ 项结果",
    "sZeroRecords": "没有匹配结果",
    "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
    "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
    "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
    "sInfoPostFix": "",
    "sSearch": "搜索:",
    "sUrl": "",
    "sEmptyTable": "数据为空",
    "sLoadingRecords": "载入中...",
    "sInfoThousands": ",",
    "oPaginate": {
        "sFirst": "首页",
        "sPrevious": "上一页",
        "sNext": "下一页",
        "sLast": "末页"
    },
    "language": {
        "thousands": ","
    }
}

$.extend(leonhelper, {
    //调用ajax
    callByAjax: function (url, data, callback, isAsync) {
        var base = this;
        if (isAsync !== false) {
            isAsync = true;
        }
        $.ajax({
            url: url,
            data: data,
            async: isAsync,
            dataType: 'json',
            type: 'POST',
            success: function (result) {
                if (result && !result.flag && result.msg) {
                    if (result.elemId) {
                        //如果含elemId则高亮显示它
                        base.simpleAlert(result.msg, 0, function () {
                            if (result.elemId.indexOf(',') > 0) {
                                var elemIdArr = result.elemId.split(',');
                                var str = 'base.showHighLight(';
                                for (var i = 0; i < elemIdArr.length; i++) {
                                    str += '$("' + elemIdArr[i].trim() + '"),';
                                }
                                str = str.endsWith(',') ? str.substr(0, str.length - 1) : str;
                                str += ')';
                                eval(str);
                            } else {
                                base.showHighLight($('#' + result.elemId));
                            }
                        });
                    } else {
                        base.simpleAlert(result.msg, 2);
                    }
                } else {
                    if (callback && typeof callback == 'function') {
                        callback(result);
                    }
                }
            },
            error: function (xhr, msg, ex) {
                base.simpleAlert('操作失败，可能是网络不通，请稍后再试！', 2);
            }
        });
    },
    //弹窗提示
    simpleAlert: function (msg, icon, callback) {
        layer.closeAll();
        layer.msg(msg, {
            icon: icon,
            time: 1500,
            shade: [0.1, '#FFF'],
            scrollbar: false,
            offset: 200
            //shift: 6//抖动
        }, function () {
            if (callback && typeof callback == 'function') {
                callback();
            }
        });
    },
    //确认提示
    simpleConfirm: function (content, yescallback, nocallback) {
        layer.closeAll();
        layer.open({
            content: content,
            btn: ['确认', '取消'],
            shadeClose: false,
            yes: function () {
                if (yescallback && typeof yescallback == 'function') {
                    yescallback();
                }
            },
            end: function () {
                if (nocallback && typeof nocallback == 'function') {
                    nocallback();
                }
            }
        });
    },
    //作为全局变量
    pageCache: {},
    //简单下拉提示框(不必精确匹配选择项)
    autoFill: function (x, arr, callback) {
        $(x).autocomplete(arr, {
            formatResult: function (row) {
                return row.name;
            }, //和formatItem类似,但可以将将要输入到input文本框内的值进行格式化.同样有三个参数,和formatItem一样.Default: none,表示要么是只有数据,要么是使用formatItem提供的值.
            formatItem: function (row, i, max) {
                return row.name;
            }, //结果中的每一行都会调用这个函数,返回值将用LI元素包含,显示在下拉列表中. 三个参数(row, i, max): 返回的结果数组, 当前处理的行数(从1开始), 当前结果数组元素的个数. Default: none, 表示不指定自定义的处理函数.
            formatMatch: function (row, i, max) {
                return row.tip;
            }, //对每一行数据使用此函数格式化需要查询的数据格式. 返回值是给内部搜索算法使用的. 参数值row
            minChars: 0//至少输入的字符数，default：1；如果设为0，在输入框内双击或者删除内容时显示列表。 
        }).result(function (event, data, formatted) {
            if (callback && typeof callback == 'function') {
                callback(data);
            }
        });
    },
    //下拉提示框(可多选)
    autoFillMultiple: function (x, arr, callback) {
        $(x).autocomplete(arr, {
            formatResult: function (row) {
                return row.name;
            }, //和formatItem类似,但可以将将要输入到input文本框内的值进行格式化.同样有三个参数,和formatItem一样.Default: none,表示要么是只有数据,要么是使用formatItem提供的值.
            formatItem: function (row, i, max) {
                return row.name;
            }, //结果中的每一行都会调用这个函数,返回值将用LI元素包含,显示在下拉列表中. 三个参数(row, i, max): 返回的结果数组, 当前处理的行数(从1开始), 当前结果数组元素的个数. Default: none, 表示不指定自定义的处理函数.
            formatMatch: function (row, i, max) {
                return row.tip;
            }, //对每一行数据使用此函数格式化需要查询的数据格式. 返回值是给内部搜索算法使用的. 参数值row
            minChars: 0, //至少输入的字符数，default：1；如果设为0，在输入框内双击或者删除内容时显示列表。
            multiple: true //是否允许输入多个值. Default: false
        }).result(function (event, data, formatted) {
            if (callback && typeof callback == 'function') {
                callback(data);
            }
        });
    },
    //下拉提示框帮助说明
    autocompleteHelpText: function (x, arr, callback, autoType, callbackAction) {
        $(x).autocomplete(arr, {
            //autoFill: false,                          //是否自动填充. Default: false
            //cacheLength: 10,                          //缓存的长度.即缓存多少条记录.设成1为不缓存.Default: 10
            //delay: 20,                                //击键后的延迟时间(单位毫秒).Default: 远程为400 本地10
            formatResult: function (row) {
                return row.name;
            },                                          //和formatItem类似,但可以将将要输入到input文本框内的值进行格式化.同样有三个参数,和formatItem一样.Default: none,表示要么是只有数据,要么是使用formatItem提供的值.
            formatItem: function (row, i, max) {
                var item = row.name;
                if (row.brand) {
                    item += "-" + row.brand;
                }
                if (row.regu) {
                    item += "-" + row.regu;
                }
                return item;
            },                                          //结果中的每一行都会调用这个函数,返回值将用LI元素包含,显示在下拉列表中. 三个参数(row, i, max): 返回的结果数组, 当前处理的行数(从1开始), 当前结果数组元素的个数. Default: none, 表示不指定自定义的处理函数.
            formatMatch: function (row, i, max) {
                return row.tip;
            },                                          //对每一行数据使用此函数格式化需要查询的数据格式. 返回值是给内部搜索算法使用的. 参数值row
            //matchCase: false,　　　　                 //是否开启大小写敏感. Default: false
            //matchContains: false,                     //决定比较时是否要在字符串内部查看匹配.Default: false
            //matchSubset: true,                        //是否启用缓存.Default: true
            //max: 10,                                  //下拉项目的个数，default：10
            minChars: 0                                 //至少输入的字符数，default：1；如果设为0，在输入框内双击或者删除内容时显示列表。 
            //multiple: false,                          //是否允许输入多个值. Default: false
            //multipleSeparator: ",",                   //输入多个字符时,用来分开各个的字符. Default: ","
            //mustMatch: false,                         //如果设置为true,只会允许匹配的结果出现在输入框,当用户输入的是非法字符时,将被清除， Default: false
            //selectFirst: true,                        //如果设置成true,下拉列表的第一个值将被自动选择, Default: true
            //scroll: true,                             //当结果集大于默认高度时，是否使用滚动条，Default: true
            //scrollHeight: 180,                        //下拉框的高度， Default: 180
            //width: $(x).outerWidth()                  //下拉框的宽度，default：input元素的宽度
        }, autoType, callbackAction).result(function (event, data, formatted) {
            //此事件会在用户选中某一项后触发，参数为：event: 事件对象, data: 选中的数据行,formatted:formatResult函数返回的值;
            //例如： $("#d").result(function(event, data, formatted){alert(formatted);})
            if (callback && typeof callback == 'function') {
                callback(data);
            }
        });
    },
    //必须精确匹配选择项
    autoFillNoMustSelect: function (x, arr, callback, autoType, callbackAction) {
        $(x).autocomplete(arr, {
            minChars: 0,
            matchContains: false,
            autoFill: false,
            mustMatch: true,
            formatItem: function (row, i, max) {
                var item = row.name;
                if (row.brand) {
                    item += "-" + row.brand;
                }
                if (row.regu) {
                    item += "-" + row.regu;
                }
                return item;
            },
            formatMatch: function (row, i, max) {
                return row.tip;
            },
            formatResult: function (row) {
                return row.name;
            },
            width: $(x).outerWidth()
        }, autoType, callbackAction).result(function (event, data, formatted) {
            if (callback && typeof callback == 'function') {
                callback(data);
            }
        });
    },
    //选中页面上全部复选框
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
    //更新实体
    updEntity: function (url, callback) {
        var cur = this;
        var ids = new Array();
        //获取所有勾选项的ID，要求属性名为id，格式为check_xxxxxx
        $('input[name="check"]:checked').each(function (index, item) {
            var itemId = $(item).attr('id');
            var id = itemId.substring(itemId.indexOf('check_') + 6, itemId.length);
            ids.push(id);
        });
        if (ids.length == 0) {
            cur.simpleAlert("请选择对象！", 0);
            return;
        }
        leonhelper.callByAjax(
            url,
            {
                Ids: JSON.stringify(ids)
            },
            function (result) {
                if (result.flag) {
                    cur.simpleAlert("操作成功！", 1, function () {
                        //cur.loadPage(1);
                        if (callback && typeof callback == 'function') {
                            callback();
                        }
                    });
                } else {
                    cur.simpleAlert("操作失败！", 2);
                }
            }
        );
    },
    //根据身份证号获取年龄、生日和性别信息
    getInfoByIdCard: function (idCard) {
        //生日年份
        var birthYear = idCard.substr(6, 4);
        //生日月份
        var birthMonth = idCard.substr(10, 2);
        //生日
        var birthDay = idCard.substr(12, 2);
        //性别
        var sex = idCard.substr(16, 1);
        //今年
        var year = new Date().getFullYear();
        sex = sex % 2;
        if (!/^\d+$/.test(birthYear) || !/^\d+$/.test(birthMonth) || !/^\d+$/.test(birthDay) || !/^\d+$/.test(sex)) {
            return '';
        }
        if (birthMonth > 12 || birthDay > 31 || birthYear < 1800 || birthYear > year) {
            return '';
        }
        //年龄可改为根据日的精确算法
        return [year - birthYear + 1, birthYear + '-' + birthMonth + '-' + birthDay, sex];
    },
    //“加载中”效果
    loading: function () {
        var mileSeconds = 15000;
        if (arguments[0] == 1) {
            mileSeconds = 30000;
        }
        //loading层 
        this.pageCache.loadLayerId = layer.load(0, {
            shade: [0.5, '#fff'], //0.5透明度的白色背景
            time: mileSeconds
        });
    },
    //打印区域
    print: function ($content) {
        $content.jqprint({
            debug: false, //如果是true则可以显示iframe查看效果（iframe默认高和宽都很小，可以再源码中调大），默认是false
            importCSS: true, //true表示引进原来的页面的css，默认是true。（如果是true，先会找$("link[media=print]")，若没有会去找$("link")中的css文件）
            printContainer: true, //表示如果原来选择的对象必须被纳入打印（注意：设置为false可能会打破你的CSS规则）。
            operaSupport: true//表示如果插件也必须支持歌opera浏览器，在这种情况下，它提供了建立一个临时的打印选项卡。默认是true
        });
    },
    //首次加载页面时处理页码显示
    getPage: function ($tb) {
        if ($tb.find("tbody tr").length > 0) {
            if (laypage) {
                this.loadPageNum({
                    total: $('#HidTotalPage').val(),
                    totalCount: $('#LabTotalCount').val()
                }, 1);
            }
        } else {
            $('.paginList').hide();
            $('#dvPageInfo').hide();
            $tb.find("tbody").empty().append('<tr><td colspan="' + $tb.find("thead th").length + '" style="text-align:center;">没有数据！</td></tr>');
        }
    },
    //根据列排序
    sortByColumn: function (elem) {
        this.loading();
        if ($(elem).parent().data('sort') == 'asc') {
            $(elem).attr('src', '../images/down.png');
            $(elem).parent().data('sort', 'desc');
        } else {
            $(elem).attr('src', '../images/up.png');
            $(elem).parent().data('sort', 'asc');
        }
        $(elem).parent().data('active', 'yes');
        $(elem).parent().siblings().each(function (index, item) {
            $(item).data('sort', '');
            $(item).data('active', 'no');
            $(item).children('img').attr('src', '../images/px.png');
        });
        this.loadPage(1);
    },
    //分页模型，分页使用的对象，需要初始化
    pagerModel: {
        currentIndex: 1,
        searchParams: {},
        $tb: null,
        url: ''
    },
    //加载页面
    loadPage: function (curr, searchParams, $tb, url) {
        var basic = this;
        if (!searchParams) {
            searchParams = this.pagerModel.searchParams;
        } else {
            this.pagerModel.searchParams = searchParams;
        }
        if (!$tb) {
            $tb = this.pagerModel.$tb;
        } else {
            this.pagerModel.$tb = $tb;
        }
        if (!url) {
            url = this.pagerModel.url;
        } else {
            this.pagerModel.url = url;
        }
        searchParams.pageIndex = curr;
        $tb.find('thead th').each(function (index, item) {
            if ($(item).data('active') == 'yes') {
                searchParams.OrderColumn = $(item).data('column');
                searchParams.OrderDesc = $(item).data('sort');
                return false;
            }
        });
        $.post(url, searchParams, function (result) {
            var json = JSON.parse(result);
            layer.closeAll();
            //渲染数据
            if (json.rows.length === 0) {
                if (curr > 1) {
                    curr--;
                    this.loadPage(curr);
                } else {
                    $tb.children("tbody").empty().append('<tr><td colspan="' + $tb.find("thead th").length + '" style="text-align:center;">没有数据！</td></tr>');
                    $('.paginList').fadeOut();
                    $('#dvPageInfo').fadeOut();
                }
                return;
            }
            var html = $("#RowTemplate").render(json);
            $tb.children("tbody").empty().append(html);
            if (!$('.paginList').is('visible')) {
                $('.paginList').fadeIn();
                $('#dvPageInfo').fadeIn();
            }
            $("#LabPageIndex").html(curr);
            $("#LabTotalCount").html(json.totalCount);
            basic.loadPageNum(json, curr);
        });
        //loading层
        this.loading();
    },
    //加载页码
    loadPageNum: function (json, curr) {
        var base = this;
        //渲染分页
        laypage({
            cont: $('.paginList'),
            pages: json.total,
            totalCount: json.totalCount,
            curr: curr,
            //hash: 'fenye', //自定义hash值
            first: '«',
            last: '»',
            prev: '‹',
            next: '›',
            skip: false,
            jump: function (obj, first) {
                if (!first) {
                    base.loadPage(obj.curr);
                }
                base.pagerModel.currentIndex = obj.curr;
            }
        });
    },
    //初始化列表排序
    initSort: function () {
        $('.sort').each(function (index, item) {
            if (item.tagName == "TD" || item.tagName == "TH") {
                $(item).append('<img src="../images/px.png" style="cursor:pointer;width:13px;padding-top:4px;float:right;" onclick="leonhelper.sortByColumn(this)"/>');
            }
        });
    },
    //初始化上传控件
    initUpload: function () {
        var base = this;
        $('#fileUpload').uploadify({
            'multi': false,
            'buttonText': '选择图片',
            'fileTypeDesc': 'Image Files',
            'fileTypeExts': '*.gif; *.jpg; *.png',
            'swf': '../Images/uploadify.swf',
            'uploader': '../Handle/DeliverHandler.ashx?op=upload',
            'onUploadError': function (file, errorCode, errorMsg, errorString) {
                base.simpleAlert('The file ' + file.name + ' could not be uploaded: ' + errorString, 2);
            },
            'onUploadSuccess': function (file, data, response) {
                var result = JSON.parse(data);
                if (result && result.fileName) {
                    $('#tbImg tr:first td').empty();
                    $('#tbImg tr:first td').html('<img src="../Upload/' + result.fileName + '" style="height:100%"/>');
                    if ($('#hidDelFiles').length) {
                        $('#hidDelFiles').val(result.fileName);
                    }
                }
            }
        });
    },
    //模拟C#中string.format方法
    replaceString: function (inputString) {
        for (var i = 1; i < arguments.length; i++) {
            var reg = new RegExp('\\{\\{' + i + '\\}\\}', 'g');
            var rep = arguments[i] || "";
            inputString = inputString.replace(reg, rep);
        }
        return inputString;
    },
    //上传照片回调时生成的html语句，只在uploadPhoto方法中使用
    imgResultType: {
        //订单详情页对应html元素
        OrderDetail: new UploadObj(
            '<a id="prescription"  title="查看处方照片" data-name="{{1}}" href="javascript:;" onclick=addPhoto(this,"see") >查看处方</a>',
            'replaceWith',
            '<a id="btnSelect" href="javascript:void();" onclick=addPhoto(this, "new")><img src="../images/takephoto.png" alt="处方拍照" class="imgButton" /></a>'
        ),
        //配送单详情页对应html元素
        DeliverDetail: [
            new UploadObj(
                '<a data-name="{{1}}" data-title="{{2}}" data-visible="{{3}}" href="javascript:;" onclick=addPhoto(this,"see",0)>{{2}}&gt;&gt;</a>',
                'before',
                ''
            ), new UploadObj(
                '<a data-name="{{1}}" data-title="{{2}}" data-visible="{{3}}" href="javascript:;" onclick=addPhoto(this,"see",1)><img style="padding: 5px;" border="0" width="240px" height="240px" src="../Upload/{{1}}" /></a>',
                'append',
                ''
            )]
    },
    /* 
    * 上传照片
    * arguments: item: 触发事件的html元素或者是ID
    *            openType: 打开类型 'new': 新建，'see':查看，默认是'new'
    *            callbackItem: 回调类型，可以认为是一个枚举，对应不同的页面
    */
    uploadPhoto: function (item, openType, callbackItem) {
        var $item;
        if (typeof item == 'string') {
            $item = $('#' + item);
        } else {
            $item = $(item);
        }
        var base = this;
        //先把模态框中的数据清除
        $('#tbImg tr:first td').empty();
        $('#txtImageTitle').val('');
        if ($('#chkOpen').length) {
            $('#chkOpen')[0].checked = false;
        }
        //动态确定按钮
        var btnArr = ['确认'];
        if (openType == 'see') { //查看图片
            btnArr = ['确认', '删除'];
            var curFileName = $item.data('name');
            var curTitle = $item.data('title');
            var curOpen = $item.data('visible');
            if (curFileName) {
                $('#tbImg tr:first td').html('<img src="../Upload/' + curFileName + '" style="height:100%"/>');
                $('#txtImageTitle').val(curTitle);
                if (curOpen && $('#chkOpen').length) {
                    $('#chkOpen')[0].checked = true;
                }
                if ($('#hidDelFiles').length) {
                    var hidValue = $('#hidDelFiles').val();
                    $('#hidDelFiles').val(hidValue);
                }
            }
        } else { //新建图片
            //如果显示的是拍照界面，初始化照相组件
            if ($('.divCamera').length && $('.divCamera').css('display') != 'none') {
                base.initVideo();
            }
        }
        //是否隐藏按钮
        if (base.pageCache.hideBtns) {
            btnArr = [];
        }
        layer.open({
            type: 1,
            title: '上传照片',
            area: ['80%', '90%'],
            shadeClose: false,
            content: $("#LayOutPhoto"),
            btn: btnArr,
            yes: function () {
                layer.closeAll();
                var imgPath = $('#tbImg tr:first td').children('img').attr('src');
                if (!imgPath) {
                    base.simpleAlert("没有图片上传！", 2);
                    return;
                }
                var fileName = imgPath.substring(imgPath.lastIndexOf('/') + 1);
                var txtTitle = $('#txtImageTitle').val();
                if ($('#txtImageTitle').length && !txtTitle) { //配送单详情页面
                    if (item == 'divPicts') {
                        txtTitle = base.getPhotoIndex($item);
                    } else {
                        txtTitle = base.getPhotoIndex($item.parent());
                    }
                }
                if ($('#chkOpen').length) {
                    var visible = $('#chkOpen').is(':checked') ? 1 : 0; //配送单详情页面
                    var toReplacehtml = callbackItem.html;
                    toReplacehtml = base.replaceString(toReplacehtml, fileName, txtTitle, visible);
                    if (openType == 'see') {
                        $item.replaceWith(toReplacehtml);
                    } else {
                        eval('$item.' + callbackItem.add + '(toReplacehtml)');
                    }
                }
                if ($('#hidDeliverManDetail').length) {
                    //配送员维护界面
                    var hidValue = $('#hidDelFiles').val();
                    if (hidValue != "") {
                        $('#userPhoto').html('<a name="showImg" data-name="' + hidValue + '" data-title="' + hidValue + '" href="javascript:;" onclick=seeMediPhoto(this,"see")><img style="height:100px;width:100px" src="../Upload/' + hidValue + '" /></a>');
                    }
                }
            },
            btn2: function () {
                layer.closeAll();
                if (callbackItem.source) {
                    $item.replaceWith(callbackItem.source);
                } else {
                    $item.remove();
                }
            },
            cancel: function () {
            }
        });
    },
    //获取照片编号
    getPhotoIndex: function ($item) {
        var photoIndex = 1;
        $item.children('a').each(function (index, item) {
            if ($(item).data('title')) {
                var title = $(item).data('title');
                if (/^\d+$/.test(title)) {
                    var num = parseInt(title);
                    photoIndex = photoIndex > num ? photoIndex : num + 1;
                }
            }
        });
        return photoIndex;
    },
    //删除照片（不再使用）
    delPhoto: function (hidValue, curFileName) {
        /*
        this.callByAjax(
        "../Handle/DeliverHandler.ashx?op=delImg",
        {
        hidValue: hidValue,
        fileName: curFileName
        },
        function () {
        $('#hidDelFiles').val('');
        }
        );
        */
    },
    switchLayer: function ($item1, $item2, index) {
        if (typeof index == 'number') {
            arguments[index].show();
            var other = 1 - index;
            arguments[other].hide();
        } else {
            if ($item1.css('display') == 'none') {
                $item1.show();
                $item2.hide();
            } else {
                $item1.hide();
                $item2.show();
            }
        }
    },
    //初始化摄像头
    initVideo: function ($item1, $item2) {
        var base = this;
        if (!$('#XwebcamXobjectX').length) {
            var ctx = null;
            var image = [];
            var pos = 0;
            function callback(msg) {
                pos = 0;
                image = new Array();
                var result = JSON.parse(msg);
                if (result && result.fileName) {
                    $('#tbImg tr:first td').empty();
                    $('#tbImg tr:first td').html('<img src="../Upload/' + result.fileName + '" style="height:100%"/>');
                }
                base.switchLayer($('.divUpload'), $('.divCamera'), 0);
            }
            $('#flashCamera').webcam({
                width: 640,
                height: 480,
                mode: 'callback',
                quality: 100,
                swffile: "../Images/jscam_canvas_only.swf", // canvas only doesn't implement a jpeg encoder, so the file is much smaller
                onSave: function (data) {
                    /*var canvas = document.createElement("canvas");
                    canvas.setAttribute('width', 320);
                    canvas.setAttribute('height', 240);
                    if (canvas.toDataURL) {
                    ctx = canvas.getContext("2d");
                    image = ctx.getImageData(0, 0, 320, 240);
                    var col = data.split(";");
                    var img = image;
                    for (var i = 0; i < 320; i++) {
                    var tmp = parseInt(col[i]);
                    img.data[pos + 0] = (tmp >> 16) & 0xff;
                    img.data[pos + 1] = (tmp >> 8) & 0xff;
                    img.data[pos + 2] = tmp & 0xff;
                    img.data[pos + 3] = 0xff;
                    pos += 4;
                    }
                    if (pos >= 4 * 320 * 240) {
                    ctx.putImageData(img, 0, 0);
                    $.post("../Handle/DeliverHandler.ashx?op=webcam", {
                    type: "data",
                    image: canvas.toDataURL("image/jpg")
                    }, function (msg) {
                    callback(msg);
                    });
                    }
                    } else {
                    */
                    image.push(data);
                    pos += 4 * 320;
                    if (pos >= 4 * 320 * 240) {
                        $.post("../Handle/DeliverHandler.ashx?op=webcam", {
                            type: "pixel",
                            image: image.join('|')
                        }, function (msg) {
                            callback(msg);
                        });
                    }
                    //}
                    // Work with the picture. Picture-data is encoded as an array of arrays... Not really nice, though =/
                },
                onCapture: function () {
                    webcam.save();
                    // Show a flash for example
                },
                onLoad: function () {
                    // Page load
                    var cams = webcam.getCameraList();
                    for (var i in cams) {
                        jQuery("#cams").append("<li>" + cams[i] + "</li>");
                    }
                },
                debug: function (type, string) {
                    if (type == "error") {
                        if (!base.pageCache.CameraError) {
                            base.pageCache.CameraError = 1;
                            base.simpleAlert('无法连接到摄像头！', 2, function () {
                                $('#flashCamera').empty().append('<img src="../Images/antenna.png" alt="">');
                                $('#spanCameraAndUpload').hide();
                                base.switchLayer($item1, $item2, 0);
                            });
                        }
                    }
                }
            });
        }
        /*
        try {
        //动态创建一个canvas元，并获取他2Dcontext。如果出现异常则表示不支持                   
        document.createElement("canvas").getContext("2d");
        } catch (e) {
        layer.closeAll();
        this.simpleAlert('当前浏览器不支持！', 2);
        return;
        }
        var canvas = document.getElementById("canvas"),
        context = canvas.getContext("2d"),
        video = document.getElementById("video");
        var getUserMedia = (navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia);
        getUserMedia.call(navigator, {
        video: true,
        audio: true
        }, function (stream) {
        video.src = window.URL.createObjectURL(stream);
        }, function (error) {
        console.log("Video capture error: ", error.code);
        });
        base.pageCache = base.pageCache || {};
        base.pageCache.doPhoto = function (x) {
        context.drawImage(video, 0, 0, 600, 400);
        //以下开始编数据   
        var imgData = canvas.toDataURL();
        //将图像转换为base64数据，将前端截取22位之后的字符串作为图像数据  
        //"data:image/png;base64,"
        var base64Data = imgData.substr(22);
        //开始异步上传          
        $.post("../Handle/DeliverHandler.ashx?op=Camera",
        { "image": base64Data },
        function (data) {
        var result = JSON.parse(data);
        if (result && result.fileName) {
        var fileName = result.fileName;
        if ($('#btnSelect').length) {
        $('#btnSelect').replaceWith('<a id="showPrescription" name="showPrescription" data-name="' + fileName + '" href="javascript:;" onclick=addPrescriptionPhoto(this,1)>处方照片</a>');
        } else {
        var txtTitle = $('#txtImageTitle2').val();
        var visible = $('#chkOpen2').is(':checked') ? 1 : 0;
        if (x) {
        if ($(x).attr('name') != 'addPhoto') {
        if ($(x).attr('name') == 'showImg') {
        $(x).replaceWith('<a name="showImg" data-name="' + fileName + '" data-title="' + txtTitle + '" data-visible="' + visible + '" href="javascript:;" onclick=addMediPhoto(this,1)><img style="padding: 5px;" border="0" width="240px" height="240px" src="../Upload/' + fileName + '" /></a>');
        } else {
        $(x).replaceWith('<a data-name="' + fileName + '" data-title="' + txtTitle + '" data-visible="' + visible + '" href="javascript:;" onclick=addMediPhoto(this,1)>' + txtTitle + '&gt;&gt;</a>');
        }
        } else {
        $(x).before('<a data-name="' + fileName + '" data-title="' + txtTitle + '" data-visible="' + visible + '" href="javascript:;" onclick=addMediPhoto(this,1)>' + txtTitle + '&gt;&gt;</a>');
        }
        } else {
        if ($('#divPicts').length) {
        $('#divPicts').append('<a name="showImg" data-name="' + fileName + '" data-title="' + txtTitle + '" data-visible="' + visible + '" href="javascript:;" onclick=addMediPhoto(this,1)><img style="padding: 5px;" border="0" width="240px" height="240px" src="../Upload/' + fileName + '" /></a>');
        }
        }
        }
        }
        });
        };
        */
    },
    //红框显示错误输入框
    showHighLight: function () {
        var $inArray = arguments;
        for (var i = 0; i < $inArray.length; i++) {
            $inArray[i].addClass('input');
        }
        setTimeout(function () {
            for (var i = 0; i < $inArray.length; i++) {
                $inArray[i].removeClass('input');
                if (!$inArray[i].val()) {
                    $inArray[i].focus();
                }
            }
        }, 2000)
    },
    //报表操作
    operatorTb: function (type, $stb, url, data) {
        var base = this;
        //loading层
        this.loading();
        if (this.pageCache.exportTb) {
            this.pageCache.exportTb = null;
        }
        var tb = document.createElement('table');
        this.pageCache.exportTb = tb;
        $(tb).attr('id', 'exportTest');
        $(tb).addClass('table table-bordered');
        $(tb).append($stb.find('thead').html());
        url = url || this.pagerModel.url;
        data = data || this.pagerModel.searchParams;
        this.callByAjax(url + "&export=1", data, function (result) {
            layer.closeAll();
            //渲染数据
            if (result.rows.length === 0) {
                base.simpleAlert('没有需要导出的数据！', 2);
                return;
            }
            var html = $("#RowTemplate").render(result);
            $(tb).append('<tbody></tbody>').children("tbody").empty().append(html);
            switch (type) {
                case "export": getXlsFromTbl($(tb)[0]);
                    break;
                case "print": base.print($(tb));
                    break;
            }
        });
    },
    //树节点点击操作
    clickNode: function (id, name) {
        if (id) {
            $('#txtDrugType').val(name);
            $('#hidDrugType').val(id);
        } else {
            $('#txtDrugType').val('全部');
            $('#hidDrugType').val(-1);
        }
    },
    //添加药品类别
    addCategory: function (createType) {
        var base = this;
        var selectedId = d.getSelected();
        if (!selectedId) {
            base.simpleAlert('先选中一个节点', 0);
            return;
        }
        /*
        //询问框
        layer.confirm('在选中节点的哪里创建？', {
        btn: ['同级', '下级'] //按钮
        }, function () {
        addCategory('behind', selectedId);
        }, function () {
        addCategory('child', selectedId);
        });
        */
        createType = createType || 'child';
        //prompt层
        layer.prompt({
            title: '输入节点名称(药品类名)',
            formType: 2
        }, function (text, index) {
            layer.close(index);
            base.loading();
            base.callByAjax(
                "../Handle/DrugHandler.ashx?op=addCategory",
                {
                    CategoryName: text,
                    SelectedID: selectedId,
                    CreateType: createType
                },
                function (result) {
                    if (result.flag) {
                        base.simpleAlert(result.msg, 1, function () {
                            base.callByAjax(
                                "../Handle/DrugHandler.ashx?op=getCategory",
                                {},
                                function (data) {
                                    base.loadTree(data);
                                }
                            );
                        });
                    } else {
                        base.simpleAlert(result.msg, 2);
                    }
                }
            );
        });
    },
    //删除药品类别
    delCategory: function () {
        var base = this;
        var selectedId = d.getSelected();
        if (!selectedId) {
            base.simpleAlert('先选中一个节点', 0);
            return;
        }
        //询问框
        layer.confirm('确认删除？', {
            btn: ['确认', '取消'] //按钮
        }, function () {
            base.loading();
            base.callByAjax(
                "../Handle/DrugHandler.ashx?op=delCategory",
                {
                    SelectedID: selectedId
                },
                function (result) {
                    if (result.flag) {
                        base.simpleAlert(result.msg, 1, function () {
                            base.callByAjax(
                                "../Handle/DrugHandler.ashx?op=getCategory",
                                {},
                                function (data) {
                                    base.loadTree(data);
                                }
                            );
                        });
                    } else {
                        base.simpleAlert(result.msg, 2);
                    }
                }
            );
        }, function () {

        });
    },
    //加载药品类别树
    loadTree: function (drugs) {
        d = new dTree('d');
        d.add(0, -1, '全部药品', 'javascript:leonhelper.clickNode()');
        for (var i in drugs) {
            var drug = drugs[i];
            d.add(drug.ID, drug.ParentCategoryID, drug.CategoryName, 'javascript:leonhelper.clickNode(' + drug.ID + ',\'' + drug.CategoryName + '\')');
        }
        $('#categoryTree').html(d.toString());
        d.openAll();
        d.n();
    },
    closePage: function (returnUrl) {
        if (window.opener) {
            window.close();
        } else {
            location.href = returnUrl;
        }
    },
    setDataTable: function (obj) {
        obj.DataTable({
            bDestroy: true,//允许重新实例化Datatables.Default:false
            responsive: false,//响应式
            searching: false,//是否允许Datatables开启本地搜索
            bLengthChange: false, //改变每页显示数据数量
            aoColumnDefs: [{
                bSortable: false,
                aTargets: [0]           //对序号为1列的列不进行排序,如果多行不需要排序的话，可使用 aTargets: [ 0 , 1 , 2 ] ，用逗号分开，列序号以0开始
            }],
            aaSorting: [[1, "desc"]],    //如果是第一行不排序的话，需要加这个，默认从第二行开始排序
            bPaginate: true, //开启分页功能，如果不开启，将会全部显示
            bInfo: true, //是否显示数据信息
            iDisplayLength: 10, //每页显示行数
            oLanguage: objDatatablesLanguage
        });
    },
    setDataTableAllSort: function (obj) {
        obj.DataTable({
            bDestroy: true, //允许重新实例化Datatables.Default:false
            bFilter: false, //开启搜索功能.Default:true
            bLengthChange: false, //允许改变每页显示的数据条数.Default:true
            oLanguage: objDatatablesLanguage
        });
    },
    //不排序、不显示分页设置 2020-09-21
    setDataTableNoSortAndIDisplay: function (obj) {
        obj.DataTable({
            bDestroy: true, //允许重新实例化Datatables.Default:false
            bFilter: false, //开启搜索功能.Default:true
            bLengthChange: false, //允许改变每页显示的数据条数.Default:true
            bSort: false, //不排序.Default:true
            bPaginate: false, //开启分页功能，如果不开启，将会全部显示
            bInfo: false, //是否显示数据信息
            //iDisplayLength: 20, //每页显示行数
            oLanguage: objDatatablesLanguage
        });
    },
    //不排序的设置
    setDataTableNoSort: function (obj) {
        obj.DataTable({
            bDestroy: true, //允许重新实例化Datatables.Default:false
            bFilter: false, //开启搜索功能.Default:true
            bLengthChange: false, //允许改变每页显示的数据条数.Default:true
            bSort: false, //不排序.Default:true
            oLanguage: objDatatablesLanguage
        });
    },
    setDataTableAJAX: function (obj, url, data1, datasss, callback) {
        obj.DataTable({
            bDestroy: true,//允许重新实例化Datatables.Default:false
            responsive: false,//响应式
            searching: false,//是否允许Datatables开启本地搜索
            bLengthChange: false, //改变每页显示数据数量
            //aoColumnDefs: [{
            //    bSortable: false,
            //    aTargets: [0]           //对序号为1列的列不进行排序,如果多行不需要排序的话，可使用 aTargets: [ 0 , 1 , 2 ] ，用逗号分开，列序号以0开始
            //}],
            // aaSorting: [[1, "desc"]],    //如果是第一行不排序的话，需要加这个，默认从第二行开始排序
            bPaginate: true, //开启分页功能，如果不开启，将会全部显示.Default:true
            bInfo: true, //是否显示数据信息.Default:true
            iDisplayLength: 10, //每页显示行数.Default:10
            serverSide: true,  //启用服务器端分页
            sAjaxSource: url, //这个是请求的地址
            language: {
                "thousands": ","
            },
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
            }, //整合AJAX的URL
            fnServerParams: function (aoData) {
                for (var i in data1) {
                    aoData.push({ "name": i, "value": data1[i] });
                }

            }, //设置入参
            aoColumns: datasss, //设置行填充
            fnInitComplete: callback, //回调函数样板如下，JSON中记录了回传的值：function (oSettings, json) {alert(json + "");}
            drawCallback: function () {
                // 取消全选  
                $(":checkbox[name='check']").prop('checked', false);
            },
            oLanguage: objDatatablesLanguage
        });
    },
    //Alere项目报表模式,横向滚动条.
    setDataTableAJAXHscrollBar: function (obj, url, data1, datasss, callback) {
        obj.DataTable({
            bDestroy: true, //允许重新实例化Datatables.Default:false
            responsive: false,//响应式
            bFilter: false, //开启搜索功能.Default:true
            bLengthChange: false, //允许改变每页显示的数据条数.Default:true
            //aaSorting: [[0, "desc"]],//表格初始化排序:如果是第一行不排序的话，需要加这个，默认从第二行开始排序.Default:[[0, 'asc']]
            bServerSide: true,  //启用服务器端分页.Default:false
            sAjaxSource: url, //从 Ajax 源加载数据的表的内容,这个是请求的地址
            language: {
                "thousands": ","
            },
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
            }, //整合AJAX的URL
            fnServerParams: function (aoData) {
                for (var i in data1) {
                    aoData.push({ "name": i, "value": data1[i] });
                }
            }, //设置入参
            aoColumns: datasss, //设置行填充
            fnInitComplete: callback, //表格加载完成回调函数,回调函数样板如下，JSON中记录了回传的值：function (oSettings, json) {alert(json + "");}
            fnDrawCallback: function (resp) {
                // 取消全选  
                $(":checkbox[name='check']").prop('checked', false);
            }, //表格重绘的时候回调函数
            oLanguage: objDatatablesLanguage
        });
    },
    //树形表格
    setTreeDataTable: function (obj, useColumns) {
        if (!$.isArray(useColumns)) return;//判断数组

        var setObj = {
            bDestroy: true,//允许重新实例化Datatables.Default:false
            bFilter: false, //开启搜索功能.Default:true
            bLengthChange: false, //改变每页显示数据数量
            scrollY: 500,
            bSort: false, //不排序.Default:true
            oLanguage: objDatatablesLanguage,
            treeGrid: {
                'left': 15,//每一级之间的间距
                'expandAll': true, //是否默认展开.Default:true 是
                'expandIcon': '<span><i class="fa fa-plus-square"></i></span>',//展开图标
                'collapseIcon': '<span><i class="fa fa-minus-square"></i></span>'//关闭图标
            },
            columns: [
                {
                    className: 'treegrid-control',
                    data: function (item) {
                        if (item.children != null && item.children.length > 0) {
                            return '<span><i class="fa fa-plus-square"></i></span>';
                        }
                        return '';
                    }
                }
            ]
        }
        for (var i = 0; i < useColumns.length; i++) {
            setObj.columns.push(useColumns[i]);
        }
        obj.DataTable(setObj);
    },
    //格式化datatables的自定义列的模板
    getDataTabelColumns: function (datas) {
        var dataArray = [];
        for (var d in datas) {
            var data = new Object();
            data.mData = d;
            if (datas[d] != null && datas[d] != "") {
                data.render = datas[d];
            }
            dataArray.push(data);
        }
        return dataArray;
    },
    //获取url中的参数
    getUrlParam: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    },
    //转时间戳为年月日格式字符串
    getYYMMDD: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy/MM/dd");
        }
        return "";
    },
    //转时间戳为年月日格式字符串(中文)
    getYYMMDDCN: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy-MM-dd");
        }
        return "";
    },
    //转时间戳为年月日时分秒格式字符串
    getYYMMDDHHMMSS: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy/MM/dd hh:mm:ss");
        }
        return "";
    },
    //转时间戳为年月日格式字符串(中文)
    getYYMMDDHHMMSSCN: function (dTime) {
        if (dTime && dTime.length > 2) {
            var date1 = eval('new ' + dTime.substr(1, dTime.length - 2));
            return date1.format("yyyy-MM-dd hh:mm:ss");
        }
        return "";
    },
    bootStrapTableAjax: function (obj, url, data, uniqueId, columnsData) {
        obj.bootstrapTable({
            url: url,     //请求后台的URL
            theadClasses: "thead-blue",//这里设置表头样式
            method: 'GET',//请求方式
            //toolbar: '#toolbar',//工具按钮用哪个容器
            paginationFirstText: "首页",
            paginationPreText: "上一页",
            paginationNextText: "下一页",
            paginationLastText: "末页",
            //searchOnEnterKey: true,              //按回车时触发搜索功能
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
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 20, 50, 100, 500, 1000],     //可供选择的每页的行数（*）
            locale: 'zh-CN',
            search: false,                      //是否显示表格搜索,此搜索是客户端搜索,不进服务端
            uniqueId: uniqueId,                   //每一行的唯一标识，一般为主键列
            clickToSelect: true,                //点击选中checkbox
            singleSelect: false,                //设置True 将禁止多选
            reorderableRows: false,             //设置拖动排序
            useRowAttrFunc: false,              //设置拖动排序
            queryParams: data,                  //传递数据
            columns: columnsData,                //设置列
            showJumpTo: true,                   // 是否显示跳页
            onLoadSuccess: function (res) {

            },
            onLoadError: function () {
            }
            //, formatNoMatches: function () {
            //    return "没有相关的匹配结果.。。。";
            //},
            //formatLoadingMessage: function () {
            //    return "请稍等，正在加载中。。。";
            //}
        });
    },
    bootStrapTableAjax1: function (obj, url, data, uniqueId, columnsData, callback) {
        obj.bootstrapTable({
            url: url,     //请求后台的URL
            method: 'GET',//请求方式
            theadClasses: "thead-blue",//这里设置表头样式
            //toolbar: '#toolbar',//工具按钮用哪个容器
            paginationFirstText: "首页",
            paginationPreText: "上一页",
            paginationNextText: "下一页",
            paginationLastText: "末页",
            //searchOnEnterKey: true,              //按回车时触发搜索功能
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
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [5, 10, 15, 20, 25, 30],     //可供选择的每页的行数（*）
            locale: 'zh-CN',
            search: false,                      //是否显示表格搜索,此搜索是客户端搜索,不进服务端
            uniqueId: uniqueId,                   //每一行的唯一标识，一般为主键列
            clickToSelect: true,                //点击选中checkbox
            singleSelect: false,                //设置True 将禁止多选
            reorderableRows: false,             //设置拖动排序
            useRowAttrFunc: false,              //设置拖动排序
            queryParams: data,                  //传递数据
            columns: columnsData,                //设置列
            showJumpTo: true,                   // 是否显示跳页
            onLoadSuccess: callback,
            onLoadError: function () {
            }
            //, formatNoMatches: function () {
            //    return "没有相关的匹配结果.。。。";
            //},
            //formatLoadingMessage: function () {
            //    return "请稍等，正在加载中。。。";
            //}
        });

    }

});

function AutomateExcel() {
    var elTable = document.getElementById("table1"); //table1改成你的tableID        
    var oRangeRef = document.body.createTextRange();
    oRangeRef.moveToElementText(elTable);
    oRangeRef.execCommand("Copy");
    try {
        var appExcel = new ActiveXObject("Excel.Application");
    } catch (e) {
        alert("无法调用Office对象，请确保您的机器已安装了Office并已将本系统的站点名加入到IE的信任站点列表中！");
        return;
    }
    appExcel.Visible = true;
    appExcel.Workbooks.Add().Worksheets.Item(1).Paste();
    appExcel = null;
}

//时间类型格式化
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

//时间戳转时间类型
String.prototype.stamp2date = function () {
    if (this == undefined) return null;
    if (!/^\/Date\(\d+\)\/$/.test(this)) return null;
    return new Date(parseInt(this.substr(6, 13)));
}

/**
 * null => ''
 * @param {*} data 要处理的数据
 */
function null2str(data) {
    for (let x in data) {
        if (data[x] === null) { // 如果是null 把直接内容转为 ''
            data[x] = '';
        } else {
            if (Array.isArray(data[x])) { // 是数组遍历数组 递归继续处理
                data[x] = data[x].map(function (z) {
                    return null2str(z);
                });
            }
            if (typeof (data[x]) === 'object') { // 是json 递归继续处理
                data[x] = null2str(data[x])
            }
        }
    }
    return data;
}

