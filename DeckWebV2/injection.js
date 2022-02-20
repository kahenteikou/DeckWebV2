function abstrans_234553(motopath) {
    var burl = location.href;
    var url = new URL(motopath, burl);
    return url.href;
}
Notification = function (title, options) {
    var optionskun = options;
    if (options.icon != null) {
        optionskun.icon = abstrans_234553(options.icon);
    }
    chrome.webview.hostObjects.NotificationCustom.showNotification(title, JSON.stringify(optionskun));
};
Notification.requestPermission = function (callback) {
    callback('granted');
};
Notification.requestPermission = function () {
    return new Promise(function (resolve, reject) {
        resolve('granted');
    });
};