var PageInfo = {};
$(function () {
    InitEvent();
    CallLoadCacheInfoAjax("7322BBDD-FB89-4FAE-A699-834B085FF09E");
});

function InitEvent() {
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