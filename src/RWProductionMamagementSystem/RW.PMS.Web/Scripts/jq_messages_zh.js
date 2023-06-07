jQuery.extend(jQuery.validator.messages,{
    required: "必选字段",
    remote: "请修正该字段",
    email: "请输入正确格式的电子邮件",
    url: "请输入合法的网址",
    date: "请输入合法的日期",
    dateISO: "请输入合法的日期 (ISO).",
    number: "请输入合法的数字",
    digits: "只能输入整数",
    creditcard: "请输入合法的信用卡号",
    equalTo: "请再次输入相同的值",
    accept: "请输入拥有合法后缀名的字符串",
    maxlength: jQuery.validator.format("最多{0} 个字符"),
    minlength: jQuery.validator.format("最少 {0} 个字符"),
    rangelength: jQuery.validator.format("长度介于 {0} 和 {1} 个字符"),
    range: jQuery.validator.format("介于 {0} 和 {1} 之间的值"),
    max: jQuery.validator.format("最大为{0} "),
    min: jQuery.validator.format("最小为{0}")
});