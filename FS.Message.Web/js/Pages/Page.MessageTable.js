/// <reference path="D:\GitHub\FirstForListenting\FS.Message.Web\Pages/Elements/Timeline.aspx" />
var tableDatas = [];

$(function () {
    CallLoadMessageTableAjax("CC6D7081-6756-4465-AEE8-18D374DBF73F");
});

function MessageViewModel() {
    var self = this;
    self.view = function (item) {
        window.location.href = "../Elements/Timeline.aspx?ItemGuid=" + item.ItemGuid;
    }
    self.messages = ko.observableArray(tableDatas);
}

function LoadMessageTableAjaxSuccess(result) {
    var pageInfo = JSON.parse(result);
    $.extend(true, tableDatas, pageInfo.Messages);
    ko.applyBindings(new MessageViewModel());
}

function LoadMessageTableAjaxError(result) {
    console.log(result);
}