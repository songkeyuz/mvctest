using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvctest.Models;

namespace mvctest.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult UserList()
        {
            return View();
        }

        public Result DoLogin(string username,string password)
        {
            if(username=="admin"&&password=="123456")
            {
                return new Result(){message="登陆成功",code=200};
            }
            return new Result(){message="用户名或密码错误",code=400};;
        }
    }

    public class UserAccount
    {
        public string username{get;set;}

        public string password{get;set;}
    }
}