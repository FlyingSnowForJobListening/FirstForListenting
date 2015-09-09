var tableDatas = [];
var viewModel;
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
    filter.OrderNo = $("#ui_orderNoText").val().trim();
    filter.LogisticsNo = $("#ui_logisticsNoText").val().trim();
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
    viewModel = this;
    viewModel.view = function (item) {
        window.location.href = "../Elements/Timeline.aspx?ItemGuid=" + item.ItemGuid;
    }
    viewModel.messages = ko.observableArray(tableDatas);
}

function InitDataFirstLoad(dataStr) {
    var pageInfo = JSON.parse(dataStr);
    $.extend(true, tableDatas, pageInfo.Messages);
    ko.applyBindings(new MessageViewModel());
}

function InitDataSearch(dataStr) {
    var pageInfo = JSON.parse(dataStr);
    tableDatas = [];
    $.extend(true, tableDatas, pageInfo.Messages);
    //ko.applyBindings(new MessageViewModel());
    viewModel.messages.removeAll();
    for (var i in tableDatas) {
        viewModel.messages.push(tableDatas[i]);
    }
}

function LoadMessageTableAjaxSuccess(result) {
    var flag = result.substr(0, 36);
    var dataStr = result.substr(36);
    switch (flag) {
        case "CC6D7081-6756-4465-AEE8-18D374DBF73F":
            InitDataFirstLoad(dataStr);
            break;
        case "E097BB93-B095-46C9-97FA-56D6DD61108C":
            InitDataSearch(dataStr)
            break;
        default:
            break;
    }
}

function LoadMessageTableAjaxError(result) {
    console.log(result);
}

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, '');
}
