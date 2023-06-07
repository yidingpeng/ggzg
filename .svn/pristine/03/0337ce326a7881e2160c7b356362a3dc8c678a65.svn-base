// 百度地图API功能
(function (global,factory) {
    global.UserTrace = factory();
})(this, function (){
    if (window["console"]) {
        console.log("UserTrace创建成功！");
    }
    var st, map,geolocation,data = {
        userid: '',
        corrds: { latitude: '', longitude: '' },
        addressInfo: ""
    },
    url = "/usertrace/save",
    StartAutoTrace = function () {
        st = setInterval(function () {
            if (!map)
            {
                InitMap();
               
            }
            if (geolocation) {
                GetPositionAndPostToServer();
            }
        }, 20000);
    },
    EndAutoTrace = function () {
        if (st) {
            clearInterval(st);
            if (window["console"]) {
                console.log('结束定时提交...');
            }
        }
    };
    //得到位置
    GetPositionAndPostToServer = function () {
        geolocation.getCurrentPosition(function (r) {
            if (this.getStatus() == BMAP_STATUS_SUCCESS) {
                if (window["console"]) {
                    console.log('提交成功！');
                }
                var addressinfo = r.address.province + r.address.city + r.address.street;
                var data = { lng: r.point.lng, lat: r.point.lat, AddressInfo: addressinfo, };
                PostData(data);
            }
            else {
                if (window["console"]) {
                    console.log("获取失败：status：" + this.getStatus());
                }
            }
        }, { enableHighAccuracy: true })
    };
    InitMap = function () {
        if (!map) {
            map = new BMap.Map("allmap");
            var point = new BMap.Point(116.331398, 39.897445);
            map.centerAndZoom(point,12);
            geolocation = new BMap.Geolocation();
        }
    };//提交数据到服务器
    PostData = function (data) {
        $.post("/UserTrace/SaveUserTrace", data, function (result) {
            if (window["console"]) {
                console.log(result);
            }
        });
    };
    var UserTrace = {
        StartTrace: StartAutoTrace,
        EndTrace: EndAutoTrace
    };
    return UserTrace;
})

