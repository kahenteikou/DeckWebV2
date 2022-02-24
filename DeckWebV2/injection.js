function abstrans_234553(motopath) {
    var burl = location.href;
    var url = new URL(motopath, burl);
    return url.href;
}
Notification = function (title, options) {
    var optionskun = options;
    if (options == undefined) {
        optionskun = {}
    }
    if (options?.icon == undefined) {
    } else {
        optionskun.icon = abstrans_234553(options.icon);
        console.log(optionskun.icon);
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
console.log("loaded!")