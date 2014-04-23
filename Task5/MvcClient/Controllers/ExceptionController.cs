using System;
using System.Web.Mvc;

using NLog;

namespace MvcClient.Controllers
{
    public class ExceptionController: Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ViewResult Index()
        {            
            Exception e = Session["Exception"] as Exception;

            logger.Warn("Exception controller called, message: {0}", e.Message);

            return View(e);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Session.Remove("Exception");

            logger.Trace("Exception controller finished, session cleared");
        }
    }
}