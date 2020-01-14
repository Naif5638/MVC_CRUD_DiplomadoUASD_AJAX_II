$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: '/Home/List',
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log('resultado: ' + result.data);
            data(result.data);
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.EmpleadoID + '</dt>';
                html += '<td>' + item.Nombres + '</dt>';
                html += '<td>' + item.Apellidos + '</dt>';
                html += '<td>' + item.Edad + '</dt>';
                html += '<td>' + item.Estado_Civil + '</dt>';
                html += '<td>' + item.Pais + '</dt>';
                html += '<td><a href="#" onClick="return getbyId(' + item.EmpleadoID + ')">Edit</a> | <a href="#" onClick="Delete(' + item.EmpleadoID + ')">Delete</a></dt>';
                html += '</tr>';
            });
            $('.tbody').html(html);
            console.log(html);
        },
        error: function (errormessEdad) {
            alert(errormessEdad.responseText);
        }
    });
}

function data(result) {
    console.log(result);
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empleadoObject = {
        EmpleadoID: $('#EmpleadoID').val(),
        Nombres: $('#Nombres').val(),
        Apellidos: $('#Apellidos').val(),
        Edad: $('#Edad').val(),
        Estado_Civil: $('#Estado_Civil').val(),
        Pais: $('#Pais').val()
    };
    $.ajax({
        url: '/Home/Add',
        data: JSON.stringify(empleadoObject),
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessEdad) {
            alert(errormessEdad.responseText);
        }
    });
}

function getbyId(id) {
    $('#Nombres').css('border-color', 'lightgrey');
    $('#Edad').css('border-color', 'lightgrey');
    $('#Estado_Civil').css('border-color', 'lightgrey');
    $('#Pais').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyId/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (result) {
            $('#EmpleadoId').val(result.EmpleadoId);
            $('#Nombres').val(result.Nombres);
            $('#Apellidos').val(result.Apellidos);
            $('#Edad').val(result.Edad);
            $('#Estado_Civil').val(result.Estado_Civil);
            $('#Pais').val(result.Pais);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessEdad) {
            alert(errormessEdad.responseText);
        }
    });
    return false;
}


function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empleadoObject = {
        EmpleadoID: $('#EmpleadoID').val(),
        Nombres: $('#Nombres').val(),
        Apellidos: $('#Apellidos').val(),
        Edad: $('#Edad').val(),
        Estado_Civil: $('#Estado_Civil').val(),
        Pais: $('#Pais').val()
    };
    $.ajax({
        url: '/Home/Update',
        data: JSON.stringify(empleadoObject),
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#EmpleadoId').val("");
            $('#Nombres').val("");
            $('#Apellidos').val("");
            $('#Edad').val("");
            $('#Estado_Civil').val("");
            $('#Pais').val("");
        },
        error: function (errormessEdad) {
            alert(errormessEdad.responseText);
        }
    });
}

function Delete(id) {
    var ans = confirm("Are you sure want to delete this record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + id,
            type: "POST",
            contentType: "application/json; charset = utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessEdad) {
                alert(errormessEdad.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#EmpleadoId').val("");
    $('#Nombres').val("");
    $('#Apellidos').val("");
    $('#Edad').val("");
    $('#Estado_Civil').val("");
    $('#Pais').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Nombres').css('border-color', 'lightgrey');
    $('#Edad').css('border-color', 'lightgrey');
    $('#Estado_Civil').css('border-color', 'lightgrey');
    $('#Pais').css('border-color', 'lightgrey');
}

function validate() {
    var isValid = true;
    if ($('#Nombres').val().trim() == "") {
        $('#Nombres').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Nombres').css('border-color', 'lightgrey');
    }
    if ($('#Apellidos').val().trim() == "") {
        $('#Apellidos').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Apellidos').css('border-color', 'lightgrey');
    }
    if ($('#Edad').val().trim() == "") {
        $('#Edad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Edad').css('border-color', 'lightgrey');
    }
    if ($('#Estado_Civil').val().trim() == "") {
        $('#Estado_Civil').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Estado_Civil').css('border-color', 'lightgrey');
    }
    if ($('#Pais').val().trim() == "") {
        $('#Pais').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Pais').css('border-color', 'lightgrey');
    }
    return isValid;
}