var tableDatas = [];

$(function () {
    InitEvent();
    CallLoadMessageTableAjax("CC6D7081-6756-4465-AEE8-18D374DBF73F");
});

function InitEvent() {
    $("#datemask").inputmask("yyyy/mm/dd", { "placeholder": "yyyy/mm/dd" });
    $("[data-mask]").inputmask();
    $("#ui_searchBtn").bind("click", function () {
        SearchMessages();
    });
}

function SearchMessages() {
    var filter = {};
    filter.OrderNo = $("#ui_orderNoText").val();
    filter.LogisticsNo = $("#ui_logisticsNoText").val();
    filter.Start = new Date($("#ui_startText").val());
    filter.End = new Date($("#ui_endText").val());
    filter.Status = $("#ui_isFinish").val();

    if (!isFinite(filter.Start)) {
        delete filter.Start;
    }
    if (!isFinite(filter.End)) {
        delete filter.End;
    }
    CallLoadMessageTableAjax("E097BB93-B095-46C9-97FA-56D6DD61108C" + JSON.stringify(filter));
}

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