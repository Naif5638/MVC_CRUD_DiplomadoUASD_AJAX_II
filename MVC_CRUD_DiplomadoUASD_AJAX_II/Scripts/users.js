function SignUp() {
    var user = {
        UserId : $("#UserId").val(),
        Nombres : $("#Nombres").val(),
        Apellidos : $("#Apellidos").val(),
        UserName : $("#UserName").val(),
        Email : $("#userEmail").val(),
        Password: $("#userPassword").val(),
        ConfirmPassword: $("#ConfirmPassword").val()
    };
    $.ajax({
        url: "/Users/SignUp",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Registro Completado...")
        },
        error: function (errormessage) {
            alert("No se pudo registrar...")
        }
    })
}