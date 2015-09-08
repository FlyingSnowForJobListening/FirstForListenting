$(function () {
    ko.applyBindings(new CacheViewModel());
});

function CacheViewModel() {
    self.cache601 = ko.observable(PageInfo.cache601);
    self.cacheQueue = ko.observable(PageInfo.cacheQueue);
}
