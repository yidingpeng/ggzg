//今天在使用bootstrap table中的数据导出功能时，遇到一个奇怪的问题，在使用测试数据进行测试的时候可以正常的将表格中的数据导出到excel、txt等文件中，
//但当将表格应用到web项目中时，当点击导出时始终没有任何响应。讲过一番调试排查后，最终发现是由于表格数据中含有中文导致的，
//在网页的开发者选项中报一个 Uncaught INVALID_CHARACTER_ERR: DOM Exception 5 问题。这个问题是由于BootStrap table 默认不支持中文，
//只会识别 ASCII字符，为了让bootstrap table 识别出中文，我们需要扩展版的 jQuery.base64.js 插件，让其可以识别出unicode 字符。
//解决该问题的方法时，将默认的jquery.base64.js 文件内容替换成下面提供的扩展版：

jQuery.base64 = (function ($) {

    // private property
    var keyStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

    // private method for UTF-8 encoding
    function utf8Encode(string) {
        string = string.replace(/\r\n/g,"\n");
        var utftext = "";
        for (var n = 0; n < string.length; n++) {
            var c = string.charCodeAt(n);
            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }
        }
        return utftext;
    }

    function encode(input) {
        var output = "";
        var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
        var i = 0;
        input = utf8Encode(input);
        while (i < input.length) {
            chr1 = input.charCodeAt(i++);
            chr2 = input.charCodeAt(i++);
            chr3 = input.charCodeAt(i++);
            enc1 = chr1 >> 2;
            enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
            enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
            enc4 = chr3 & 63;
            if (isNaN(chr2)) {
                enc3 = enc4 = 64;
            } else if (isNaN(chr3)) {
                enc4 = 64;
            }
            output = output +
                keyStr.charAt(enc1) + keyStr.charAt(enc2) +
                keyStr.charAt(enc3) + keyStr.charAt(enc4);
        }
        return output;
    }

    return {
        encode: function (str) {
            return encode(str);
        }
    };

}(jQuery));