$(document).ready(function () {

    //get start Times
    $.ajax({
        url: "/diary/getStartTimes"
    }).done(function (result) {
        result.forEach(function (item) {
            $("#startTimes").append($("<option>").text(item));
        });
        });

    //get end Times
    $.ajax({
        url: "/diary/getEndTimes"
    }).done(function (result) {
        result.forEach(function (item) {
            $("#endTimes").append($("<option>").text(item));
        });
    });
});