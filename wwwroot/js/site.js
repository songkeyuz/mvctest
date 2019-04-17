// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    window.onload = function (ev) {

    var oBtn = document.getElementById("button");

    oBtn.onclick = function (ev1) {
        var user = {
            username:$("#UserName").val(),
            password:$("#Password1").val()
        }
        $.ajax({
            type: "post",
            url: "/account/dologin",
            data: user,
            dataType: "json",
            success: function (response,config) {
                alert(response.responseTxet);
            },
            error: function(){
                alert("用户名或密码错误");
            }
            
        });
    }
}
