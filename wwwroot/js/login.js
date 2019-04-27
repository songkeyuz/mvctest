// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    $("#userLogIn").click(function () {
        $("#UserLogIn").bootstrapValidator('validate');
    });
    $("#UserLogIn").bootstrapValidator().on("success.form.bv", function (e) {
        var user = {
            username: $("#UserName").val(),
            password: $("#Password1").val(),
        }
        $.ajax({
            type: "post",
            url: "/account/dologin",
            data: user,
            dataType: "json",
            success: function (res) {
                if (res.code == 200) {

                    Notify('登录成功，', 'top-center', '1000', 'success', 'fa-check', true);
                    // alert("跳转中");
                    // window.location.href = "www.baidu.com"
                }
                if (res.code == 400) {
                    Notify('用户名或密码错误', 'top-center', '3000', 'error', 'fa-check', true);
                    //alert(res.message);
                }
            },
            error: function () {
                alert("未访问到服务器");
            }
        })
    })

    function Notify(message, position, timeout, theme, icon, closable) {
        toastr.options.positionClass = 'toast-' + position;
        toastr.options.extendedTimeOut = 0; //1000;
        toastr.options.timeOut = timeout;
        toastr.options.closeButton = closable;
        toastr.options.iconClass = icon + ' toast-' + theme;
        toastr[theme](message);
    }
    // $("#userLogIn").click(function () {
    //     login()
    // })
    // $("#logIn").keydown(function (e) {
    //     if (e.keyCode == 13) {
    //         login();
    //     }
    // })
    // function login() {
    //     var user = {
    //         username: $("#UserName").val(),
    //         password: $("#Password1").val(),
    //     }
        // if ($.trim($("#UserName").val()).length == 0) {
        //     $("#user").removeClass("hint");
        //     $("#UserName").addClass("hind");
        //     return false;
        // };
        // if ($.trim($("#Password1").val()).length == 0) {
        //     $("#pwd").removeClass("hint");
        //     $("#Password1").addClass("hind");
        //     return false;
        // };
    //     $.ajax({
    //         type: "post",
    //         url: "/account/dologin",
    //         data: user,
    //         dataType: "json",
    //         success: function (res) {
    //             if (res.code == 200) {
    //                 alert("跳转中");
    //                 // window.location.href = "www.baidu.com"
    //             }
    //             if (res.code == 400) {
    //                 alert(res.message);
    //             }
    //         },
    //         error: function () {
    //             alert("未访问到服务器");
    //         }

    //     });
    // }
    // $("#UserName").click(function(){
    //     $("#UserName").keydown(function(){
    //         $("#user").addClass("hint");
    //         $("#UserName").removeClass("hind");
    //      });
    // })
    // $("#Password1").click(function(){
    //     $("#Password1").keydown(function(){
    //         $("#pwd").addClass("hint");
    //         $("#Password1").removeClass("hind");
    //      });
    // })

}
