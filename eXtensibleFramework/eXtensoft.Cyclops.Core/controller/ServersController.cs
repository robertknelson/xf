

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

    public class ServersController : ServiceController
    {
        // GET: Server
        [Authorize(Roles = "member")]
        public ActionResult Index()
        {
            string sortby;
            var c = GetParameters(Request, out sortby);

            var response = Service.GetAll<Server>(c);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                var unsorted = from x in response
                               select new ServerViewModel(x);
                var items = Sort(unsorted, sortby);
                return View(items);
            }
        }


        // GET: Server/Details/5
        [Authorize(Roles = "member")]
        public ActionResult Details(int id)
        {
            var criterion = new Criterion("ServerId", id);
            var response = Service.Get<Server>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new ServerViewModel(response.Model));
            }
        }

        // GET: Server/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Server/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(ServerViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                return View(viewModel);
            }
            else
            {
                var response = Service.Post<Server>(viewModel.ToModel());
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddApp(ServerViewModel viewModel)
        {

            ServerApp model = new ServerApp()
            {
                ServerId = viewModel.ServerId,
                AppId = viewModel.AppId,
                ZoneId = !String.IsNullOrWhiteSpace(viewModel.Zone) ? SelectionConverter.ConvertToId(viewModel.Zone) : 0,
                Folderpath = "d:\\none",
                BackupFolderpath = "c:\\none"
            };

            var response = Service.Post<ServerApp>(model);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return RedirectToAction("Details", new { id = viewModel.ServerId });
            }

        }

        [Authorize(Roles = "admin")]
        // GET: Server/Edit/5
        public ActionResult Edit(int id)
        {
            var criterion = new Criterion("ServerId", id);
            var response = Service.Get<Server>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new ServerViewModel(response.Model));
            }
        }

        // POST: Server/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(ServerViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                return View(viewModel);
            }
            else
            {
                var response = Service.Put<Server>(viewModel.ToModel(), null);
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

        // GET: Server/Delete/5
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var criterion = new Criterion("ServerId", id);
            var response = Service.Get<Server>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return View(new ServerViewModel(response.Model));
            }
        }

        // POST: Server/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var criterion = new Criterion("ServerId", id);
            var response = Service.Delete<Server>(criterion);
            if (!response.IsOkay)
            {
                return View(ErrorViewName, response.Status);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }




        private static IEnumerable<ServerViewModel> Sort(IEnumerable<ServerViewModel> list, string sortby)
        {
            IEnumerable<ServerViewModel> sorted = null;
            switch (sortby)
            {
                case "domain":
                    sorted = list.OrderBy(x => x.TLD);
                    break;
                case "os":
                    sorted = list.OrderBy(x => x.OperatingSystem);
                    break;
                case "zone":
                    sorted = list.OrderBy(x => x.Zone);
                    break;
                case "platform":
                    sorted = list.OrderBy(x => x.HostPlatform);
                    break;
                case "name":
                    sorted = list.OrderBy(x => x.Name);
                    break;
                case "usage":
                    sorted = list.OrderBy(x => x.Usage);
                    break;
                default:
                    sorted = list.OrderBy(x => x.TLD);
                    break;
            }
            return sorted;
        }



    }
}
