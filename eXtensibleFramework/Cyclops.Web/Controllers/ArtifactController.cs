using Cyclops.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cyclops.Controllers
{
    public class ArtifactController : ServiceController
    {
        // GET: Artifact
        public ActionResult Index()
        {
            return View(new ArtifactViewModel());
        }


        [HttpPost]
        public ActionResult Upload(ArtifactViewModel viewModel)
        {

            ActionResult result = null;

            var validMimes = new string[] { "image/png","image/jpeg","image/gif" };


            if (viewModel.IsValid())
            {
                var m = viewModel.ToModel();
                m.Mime = viewModel.FileUpload.ContentType;
                m.ContentLength = viewModel.FileUpload.ContentLength;
                m.OriginalFilename = viewModel.FileUpload.FileName;
                m.Id = Guid.NewGuid();
                


                if (viewModel.FileUpload != null && viewModel.FileUpload.ContentLength > 0)
                {

                    var uploadDirectory = "~/app_files/file-uploads/";
                    m.Location = Path.Combine(Server.MapPath(uploadDirectory), m.Id.ToString().Trim(new char[]{'{','}'}));
                    var response = Service.Post<Artifact>(m);
                    if(response.IsOkay)
                    {
                        viewModel.FileUpload.SaveAs(m.Location);
                    }
                    

                }
                result = RedirectToAction(viewModel.RedirectAction, viewModel.RedirectController);
            }
            else
            {
                result = RedirectToAction("index", viewModel);
            }


            return result;
        }



    }
}