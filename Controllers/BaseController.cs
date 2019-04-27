using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvctest.Models;
using System.Web;
using Newtonsoft.Json;

namespace mvctest.Controllers
{
    public class BaseController : Controller
    {
        protected T BuildQueryFilterEntity<T>() where T : QueryFilter, new()
        {
            string data = Request.Form["data"];
            if (string.IsNullOrWhiteSpace(data))
            {
                data = Request.Form["data[]"];
            }
            T t = null;
            if (string.IsNullOrWhiteSpace(data))
            {
                t = new T();
            }
            else
            {
                t = JsonConvert.DeserializeObject<T>(HttpUtility.UrlDecode(data));
            }

            //每页显示条数:
            int pageSize = Convert.ToInt32(Request.Form["length"]);
            if (t is QueryFilter && pageSize > 0)
            {
                //当前页码:
                int pageIndex = Convert.ToInt32(Request.Form["start"]) % pageSize == 0 ? Convert.ToInt32(Request.Form["start"]) / pageSize : Convert.ToInt32(Request.Form["start"]) / pageSize + 1;
                //排序:
                string sortBy = null;
                if (!string.IsNullOrEmpty(Request.Form["order[0][column]"]))
                {
                    string colIndex = Request.Form["order[0][column]"];
                    string sortByField = string.IsNullOrEmpty(Request.Form[string.Format("columns[{0}][name]", colIndex)]) ? Request.Form[string.Format("columns[{0}][data]", colIndex)] : Request.Form[string.Format("columns[{0}][name]", colIndex)];
                    string sortDir = Request.Form["order[0][dir]"];
                    sortBy = string.Format("{0} {1}", sortByField, sortDir.ToUpper());
                }

                t.PageSize = pageSize;
                t.PageIndex = pageIndex;
                t.SortFields = sortBy;
                t.draw = int.Parse(Request.Form["draw"]);
            }

            return (T)t;

        }
    
    
        protected IActionResult AjaxGridJson<T>(QueryResult<T> result) where T : class
        {
            return Json(new
            {
                sEcho = result.draw,
                iTotalRecords = result.recordsTotal,
                iTotalDisplayRecords = result.recordsTotal,
                aaData = result.data
            });
        }
    }
}