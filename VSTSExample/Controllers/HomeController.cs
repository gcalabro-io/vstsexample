using Microsoft.TeamFoundation.Work.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VSTSExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var accountUri = new Uri(ConfigurationManager.AppSettings["Vsts.Uri"]);
            var personalAccessToken = ConfigurationManager.AppSettings["Vsts.PersonalAccessToken"];

            var vssBasicCredential = new VssBasicCredential(String.Empty, personalAccessToken);

            // Create a connection to the account
            var vssConnection = new VssConnection(accountUri, vssBasicCredential);

            // Hangs here on subsequent request... doesn't happen on development server but does happen when hosted via IIS
            using (var workHttpClient = vssConnection.GetClient<WorkHttpClient>())
            {

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}