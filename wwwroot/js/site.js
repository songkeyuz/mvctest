// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    $("#userLogIn").click(function () {
        login()
    })
    $("#logIn").keydown(function (e) {
        if (e.keyCode == 13) {
            login();
        }
    })
    function login() {
        var user = {
            username: $("#UserName").val(),
            password: $("#Password1").val(),
        }

        if ($.trim($("#UserName").val()).length == 0) {
            $("#user").removeClass("hint");
            setTimeout(function () {
                $("#user").addClass("hint");
            }, 1500);
            return false;
        };
        if ($.trim($("#Password1").val()).length == 0) {
            $("#pwd").removeClass("hint");
            setTimeout(function () {
                $("#pwd").addClass("hint");
            }, 1500);
            return false;
        };
        $.ajax({
            type: "post",
            url: "/account/dologin",
            data: user,
            dataType: "json",
            success: function (res) {
                if (res.code == 200) {
                    alert("跳转中");
                    // window.location.href = "www.baidu.com"
                }
                if (res.code == 400) {
                    alert(res.message);
                }
            },
            error: function () {
                alert("未访问到服务器");
            }

        });
    }
}
