using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrialDAL;

namespace TrialApp.Controllers
{
    public class UserController : Controller
    {
        TrialRepo context;

        public UserController()
        {
            context = new TrialRepo();
        }

        [HandleError(View="Error")]
        [HttpGet]
        public ActionResult getUser()
        {
            throw new Exception("Error");
       
        } 
    }
}