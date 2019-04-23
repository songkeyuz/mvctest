using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvctest.Models;

namespace mvctest.Controllers
{
    public class UserController : BaseController
    {
        public static List<SystemUser> UserData = new List<SystemUser> ();

        static UserController()
        {
            for(int i=1;i<100;i++) {
                UserData.Add(new SystemUser(){ SysNo = i ,Gender=Gender.Male,LoginName="admin"+i,UserFullName="tom"+i,CellPhone="189234345"+i.ToString().PadLeft(2,'0')});
            }
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult UserQuery()
        {
            QF_SystemUser filter = BuildQueryFilterEntity<QF_SystemUser>();
            var result = _UserQuery(filter);
            return AjaxGridJson(result);
        }

        private QueryResult<SystemUser> _UserQuery(QF_SystemUser filter) {
            var data = new List<SystemUser> ();
            foreach(var user in UserData) {
                if(
                    (!filter.SysNo.HasValue||filter.SysNo.Value==user.SysNo)
                    && (!filter.CommonStatus.HasValue||filter.CommonStatus.Value==user.CommonStatus)
                    && (string.IsNullOrWhiteSpace(filter.LoginName)||filter.LoginName==user.LoginName)
                    && (string.IsNullOrWhiteSpace(filter.UserFullName)||filter.UserFullName==user.UserFullName)
                    && (string.IsNullOrWhiteSpace(filter.CellPhone)||filter.CellPhone==user.CellPhone)
                ){
                    data.Add(user);
                }
            }

            QueryResult<SystemUser> result = new  QueryResult<SystemUser>();
            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.SortFields = filter.SortFields;
            result.data = data;
            result.recordsTotal = data.Count();
            return result;
        }
    }
}