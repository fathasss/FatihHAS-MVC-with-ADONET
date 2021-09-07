$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ProductId + '</td>';
                html += '<td>' + item.ProductName + '</td>';
                html += '<td>' + item.ProductStok + '</td>';
                html += '<td>' + item.ProductDescription + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ProductId + ')">Düzenle</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(ProductId) {
    $('#ProductName').css('border-color', 'lightgrey');
    $('#ProductStok').css('border-color', 'lightgrey');
    $('#ProductDescription').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + ProductId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ProductId').val(result.ProductId);
            $('#ProductName').val(result.ProductName);
            $('#ProductStok').val(result.ProductStok);
            $('#ProductDescription').val(result.ProductDescription);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        ProductId: $('#ProductId').val(),
        ProductName: $('#ProductName').val(),
        ProductStok: $('#ProductStok').val(),
        ProductDescription: $('#ProductDescription').val(),
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        ProductId: $('#ProductId').val(),
        ProductName: $('#ProductName').val(),
        ProductStok: $('#ProductStok').val(),
        ProductDescription: $('#ProductDescription').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ProductId').val("");
            $('#ProductName').val("");
            $('#ProductStok').val("");
            $('#ProductDescription').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Function for clearing the textboxes
function clearTextBox() {
    $('#ProductId').val("");
    $('#ProductName').val("");
    $('#ProductStok').val("");
    $('#ProductDescription').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#ProductName').css('border-color', 'lightgrey');
    $('#ProductStok').css('border-color', 'lightgrey');
    $('#ProductDescription').css('border-color', 'lightgrey');
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#ProductName').val().trim() == "") {
        $('#ProductName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProductName').css('border-color', 'lightgrey');
    }
    if ($('#ProductStok').val().trim() == "") {
        $('#ProductStok').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProductStok').css('border-color', 'lightgrey');
    }
    if ($('#ProductDescription').val().trim() == "") {
        $('#ProductDescription').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProductDescription').css('border-color', 'lightgrey');
    }
    return isValid;
}

function myFunction(search) {
    $.ajax({
        url: "/Search/List" +search,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ProductId + '</td>';
                html += '<td>' + item.ProductName + '</td>';
                html += '<td>' + item.ProductStok + '</td>';
                html += '<td>' + item.ProductDescription + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ProductId + ')">Düzenle</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}