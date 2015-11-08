using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPodcast.Site.Controllers
{
  public class InfoController : Controller
  {
    public ActionResult About()
    {
      return View();
    }
  }
}