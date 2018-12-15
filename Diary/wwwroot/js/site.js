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

    //validate data

    let name  = $('#name');
    if (!name[0].checkValidity()) {
        document.getElementById("error-name").innerHTML = name[0].validationMessage;
        return;
    }
    else {
        document.getElementById("error-name").innerHTML = "";
    }
    let startTime = $('#startTime');
    if (!startTime[0].checkValidity()) {
        document.getElementById("error-startTime").innerHTML = startTime[0].validationMessage;
        return;
    } 
    else {
        document.getElementById("error-startTime").innerHTML = "";
    }
    let endTime = $('#endTime');
    if (!endTime[0].checkValidity()) {
        document.getElementById("error-endTime").innerHTML = endTime[0].validationMessage;
        return;
    } else {
        document.getElementById("error-endTime").innerHTML = "";
    }
    
    let freeTime = {
        name: name.val(),
        startTime: startTime.val(),
        endTime: endTime.val()
    }

    $.ajax({
        url: "/diary/addPerson",
        type: "POST",
        data: JSON.stringify(freeTime),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8'
    }).done(function (diaryJSON) {
        let diary = JSON.parse(diaryJSON);
        if (diary.ErrorCode == 'UNAUTHORIZED_API_METHOD') {
            document.getElementById("error-validation").innerHTML = diary.Description;
        }
        else {
            manipulateHTMLTable($('#diary-tbl'), diary);
        }
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