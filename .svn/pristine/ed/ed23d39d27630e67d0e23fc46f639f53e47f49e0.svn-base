jQuery.validator.addMethod("userName", function(value, element) {

    return this.optional(element) || /^[\u0391-\uFFE5\w]+$/.test(value);

}, "用户名必须在5-10个字符之间");

jQuery.validator.addMethod("CheckCode", function (value, element) {

    return this.optional(element) || /^([\u4e00-\u9fa5]+|[a-zA-Z0-9]+)$/.test(value);

}, "包含不合法的字符");

jQuery.validator.addMethod("isZipCode", function(value, element) {   

    var tel = /^[0-9]{6}$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写您的邮政编码");

jQuery.validator.addMethod("isDate", function (value, element) {
    var ereg = /^(\d{1,4})(-|\/)(\d{1,2})(-|\/)(\d{1,2})$/;
    var r = value.match(ereg);
    if (r == null) {
        return false;
    }
    var d = new Date(r[1], r[3] - 1, r[5]);
    var result = (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[5]);
    return this.optional(element) || (result);
}, "请输入正确的日期");

jQuery.validator.addMethod("isTelephone", function (value, element) {

    var tel = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写电话号码");
jQuery.validator.addMethod("isPhone", function (value, element) {

    var tel = /^(\+\d{2,3}\-)?\d{11}$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写手机号");
jQuery.validator.addMethod("isMobile", function (value, element) {

    var tel = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写手机号");
jQuery.validator.addMethod("isMobileOrPhone", function (value, element) {
    var flag = false;
    var controlObj = $.trim(value);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^(\+\d{2,3}\-)?\d{11}$/;
    reg2 = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;
    if (reg.test(value)==true || reg2.test(value)==true) {
        flag = true;
    } else {
        flag= false;
    }

    return this.optional(element) || flag;

}, "请正确填写电话号码");
jQuery.validator.addMethod("isNumber", function (value, element) {

    var tel =  /^[-+]?\d+$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写");
jQuery.validator.addMethod("isNumberSection", function (value, element) {

    var tel = /^([1-9]|[1-5][0-9]|9999)$/;

    return this.optional(element) || (tel.test(value));

}, "请正确填写");
jQuery.validator.addMethod("isLenStr", function (value, element) {
    var flag = false;
    value = $.trim(value);
    if (value.length == 0 || value.length > 20)
        flag= false;
    else
        flag= true;

    return this.optional(element) || flag;

}, "请正确填写");
jQuery.validator.addMethod("isLenCode", function (value, element) {
    var flag = false;
    value = $.trim(value);
    if (value.length == 0 || value.length > 10)
        flag = false;
    else
        flag = true;

    return this.optional(element) || flag;

}, "请正确填写");
