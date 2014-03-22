using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryDatatables.Models;

namespace JQueryDatatables.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (TestAppContext ent = new TestAppContext())
            {
                var firstCompanyName = ent.Company.FirstOrDefault().CompanyName;
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application. Your first Company Name is " + firstCompanyName;

                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult JQueryDataTablesTest()
        {
            return View();
        }

        public ActionResult FillDataTablesTest(jQueryDataTableParamModel param)
        {
            using (TestAppContext ent = new TestAppContext())
            {
                var nameFilter = Convert.ToString(Request["sSearch_2"]);
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var company = ent.Company.ToList();
                
                if(!string.IsNullOrEmpty(param.sSearch))
                {
                    var filterKey = param.sSearch.Trim().ToLower();
                    company = ent.Company.Where(x => x.CompanyName.Trim().ToLower().Contains(filterKey) || x.CompanyAddress.Trim().ToLower().Contains(filterKey)).ToList();
                }
                    var companyToDisplay = company.Skip(param.iDisplayStart).Take(param.iDisplayLength);
                    var result = from comp in companyToDisplay select new object[] { comp.CompanyID, comp.CompanyID, comp.CompanyName, comp.CompanyAddress };
                    var totalCount = company.Count();
                    return Json(new
                    {
                        sEcho = param.sEcho,
                        iTotalRecords = totalCount,
                        iTotalDisplayRecords = totalCount,
                        aaData = result
                    }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AutoCompleteTest()
        {
            return View();
        }
        public JsonResult AutoComplete(string search)
        {

            var data = new[] {"ActionScript","AppleScript","Asp",
              "BASIC",
              "badfdf",
              "baerere",
              "batest",
              "C","C++","Clojure","COBOL","ColdFusion",
              "Erlang",
              "Fortran",
              "Groovy",
              "Haskell",
              "instinctcoder.com",
              "Java","JavaScript",
              "Lisp",
              "Perl","PHP","Python",
              "Ruby",
              "Scala","Scheme"};

            var result = data.Where(x => x.ToLower().StartsWith(search.ToLower())).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
