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


$("#add-btn").click(function (event) {
    //don't refresh
    event.preventDefault();

    //retreive data
    let freeTime = new Object();

    freeTime.name = $("#name").val();
    freeTime.startTime = $("#startTime").val();
    freeTime.endTime = $("#endTime").val();

    $.ajax({
        url: "/diary/addPerson",
        type: "POST",
        data: JSON.stringify(freeTime),
        contentType: 'application/json'
    }).done(function (diaryJSON) {
        manipulateHTMLTable($('#diary-tbl'), JSON.parse(diaryJSON));
    });

});

function manipulateHTMLTable(table, json) {
    //remove all rows
    table.find("tr").remove();

    //manipulate headers
    let header = table.find("thead");
    let headerText = '<tr>'
    Object.keys(json[0]).forEach(function (key) {
        headerText+=`<th> ${key} </th>`;
    });
    headerText += '</tr>';
    header.append(headerText);

    //manipulate body
    let body = table.find('tbody');
    let trText ="";
    json.forEach(function (line,index) {
        trText= '<tr>'
        Object.keys(json[index]).forEach(function (key) {
            trText += `<td> ${line[key]} </td>`;
        });
        trText += '</tr>';
        body.append(trText);
    });
   
}

$("#show-btn").click(function (event) {
    //don't refresh
    event.preventDefault();


    $.ajax({
        url: "/diary/getDiary",
    }).done(function (diaryJSON) {
        manipulateHTMLTable($('#diary-tbl'), JSON.parse(diaryJSON));
    });

});