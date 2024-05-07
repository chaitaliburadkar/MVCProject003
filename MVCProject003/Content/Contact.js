$(document).ready(function () {
    GetDataList();
    RedirectDetails();
});

var savereg = function () {
    var id = $("#hdnID").val();
    var name = $("#txtName").val();
    var mobile_No = $("#txtMobile_No").val();
    var email_ID = $("#txtEmail_ID").val();
    var address = $("#txtAddress").val();
    var city = $("#txtCity").val();
    var model = {
        ID: id,
        Name: name,
        Mobile_No: mobile_No,
        Email_ID: email_ID,
        Address: address,
        City: city,
    };
    debugger;
    $.ajax({
        url: "/Contact/Savereg",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            GetDataList();
        },
        Error: function (response) {
            alert(response.Message);
        }
    })
}

var GetDataList = function () {
    debugger;
    $.ajax({
        url: "/Contact/GetDataList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var html = "";
            $("#tblContact tbody").empty();
            $.each(response.model,function (index, elementValue) {
                html += "<tr><td>" + elementValue.Srno +
                    "</td><td>" + elementValue.ID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Mobile_No +
                    "</td><td>" + elementValue.Email_ID +
                    "</td><td>" + elementValue.Address +
                    "</td><td>" + elementValue.City +
                    "</td><td><input type='button' value='Edit' class='btn btn-success'onclick='GetContactbyId(" + elementValue.ID + ")'/>&nbsp;<input type='button' value='Delete' class='btn btn-danger'onclick='DeleteContact(" + elementValue.ID + ")'/>&nbsp;<input type='button' value='Redirect Details' class='btn btn-info'onclick='Details(" + elementValue.ID + ")'/></td></tr>";
            });

            $("#tblContact tbody").append(html);
        }
    });
}

var DeleteContact = function (ID) {
    debugger;
    model = { Id: ID }
    $.ajax({
        url: "/Contact/DeleteContact",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetDataList();
        },
        error: function (response) {
            alert(response.model);
        }
    });
}

var GetContactbyId = function (ID) {
    model = { Id: ID }
    $.ajax({
        url: "/Contact/GetContactbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnID").val(response.model.ID);
            $("#txtName").val(response.model.Name);
            $("#txtMobile_No").val(response.model.Mobile_No);
            $("#txtEmail_ID").val(response.model.Email_ID);
            $("#txtAddress").val(response.model.Address);
            $("#txtCity").val(response.model.City);
        }

    });
}

var Details = function (ID) {
    window.location.href = "/Contact/DetailsIndex?ID=" + ID;
}

var RedirectDetails = function () {
    var Id = $("#hdnID").val();
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/Contact/GetContactbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnID").text(response.model.ID);
            $("#txtName").text(response.model.Name);
            $("#txtMobile_No").text(response.model.Mobile_No);
            $("#txtEmail_ID").text(response.model.Email_ID);
            $("#txtAddress").text(response.model.Address);
            $("#txtCity").text(response.model.City);
        }

    });
}




