

namespace Cyclops.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using XF.Common;
    using Cyclops.Web;

    public class AppsController : ServiceController
    {
        public ActionResult Index()
        {

            var c = GetParameters(Request);

            var response = Service.GetAll<App>(c);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                var items = from x in response
                            select new AppViewModel(x);
                return View(items);
            }
        }

        // GET: Apps/Details/5
        public ActionResult Details(int id)
        {
            var criterion = new Criterion("AppId", id);
            var response = Service.Get<App>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new AppViewModel(response.Model));
            }
        }

        // GET: Apps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apps/Create
        [HttpPost]
        public ActionResult Create(AppViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                return View(viewModel);
            }
            else
            {
                var response = Service.Post<App>(viewModel.ToModel());
                if (!response.IsOkay)
                {
                    return View(ErrorViewName, response.Status);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Apps/Edit/5
        public ActionResult Edit(int id)
        {
            var criterion = new Criterion("AppId", id);
            var response = Service.Get<App>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new AppViewModel(response.Model));
            }
        }

        // POST: Apps/Edit/5
        [HttpPost]
        public ActionResult Edit(AppViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                return View(viewModel);
            }
            else
            {
                var response = Service.Put<App>(viewModel.ToModel(), null);
                if (!response.IsOkay)
                {
                    return View(ErrorViewName, response.Status);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Apps/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var criterion = new Criterion("AppId", id);
            var response = Service.Get<App>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new AppViewModel(response.Model));
            }
        }

        // POST: Apps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var criterion = new Criterion("AppId", id);
            var response = Service.Delete<App>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
