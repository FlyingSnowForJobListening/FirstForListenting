var PageInfo = {};
$(function () {
    InitEvent();
    CallLoadCacheInfoAjax("7322BBDD-FB89-4FAE-A699-834B085FF09E");
});

function InitEvent() {
    $("#ui_btnSend601").bind("click", function () {
        SendMessage601Now();
    });
    $("#ui_btnAwake").bind("click", function () {
        AwakeFileThread();
    });
    $("#ui_btnDealResidue").bind("click", function () {
    });
}

function CacheViewModel() {
    self.cache601 = ko.observable(PageInfo.cache601);
    self.cacheQueue = ko.observable(PageInfo.cacheQueue);
}

function LoadCacheInfoAjaxSuccess(result) {
    var flag = result.substr(0, 36);
    var dataStr = result.substr(36);
    switch (flag) {
        case "7322BBDD-FB89-4FAE-A699-834B085FF09E":
            InitDataFirstLoad(dataStr);
            break;
        case "6179029E-D073-4354-8FBD-6725D089EC63":
            RefreshMessage601(dataStr);
            break;
        default:
            break;
    }
}

function LoadCacheInfoAjaxError(result) {
}

function InitDataFirstLoad(dataStr) {
    PageInfo = JSON.parse(dataStr);
    ko.applyBindings(new CacheViewModel());
}

function RefreshMessage601(dataStr) {
    PageInfo = JSON.parse(dataStr);
    self.cache601(PageInfo.cache601);
}

function SendMessage601Now() {
    CallLoadCacheInfoAjax("6179029E-D073-4354-8FBD-6725D089EC63");
}

function AwakeFileThread() {
    CallLoadCacheInfoAjax("D5C79A03-2936-47EF-8BD1-432EE77C303A");
}

function DealResidueFile() {
    CallLoadCacheInfoAjax("CF204842-99C3-4B9F-B303-087133491E72");
}