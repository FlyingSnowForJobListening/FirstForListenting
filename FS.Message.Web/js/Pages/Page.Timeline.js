$(function () {
    ko.applyBindings(new MessageTimelineModel());
});

function MessageTimelineModel() {
    var self = this;
    self.item = ko.observable(item);
    self.Entry301s = ko.observableArray(item.Entry301s);
    self.Entry302s = ko.observableArray(item.Entry302s);
    self.Entry501s = ko.observableArray(item.Entry501s);
    self.Entry502s = ko.observableArray(item.Entry502s);
    self.Entry601s = ko.observableArray(item.Entry601s);
    self.Entry602s = ko.observableArray(item.Entry602s);
}


