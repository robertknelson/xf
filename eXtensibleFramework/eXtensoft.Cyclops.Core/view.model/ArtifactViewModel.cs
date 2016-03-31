using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cyclops.Web
{
    public class ArtifactViewModel : ViewModel<Artifact>
    {
        public int ArtifactId { get; set; }

        public int ArtifactTypeId { get; set; }

        public string Mime { get; set; }

        public string OriginalFilename { get; set; }

        public string Location { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Display { get; set; }

        public DateTime Tds { get; set; }

        public string UploadedOn { get; set; }

        public int ArtifactScopeTypeId { get; set; }

        public int ArtifactScopeId { get; set; }

        public string ArtifactType { get; set; }


        public string ArtifactScope { get; set; }

        public string ArtifactScopeType { get; set; }



        [DataType(DataType.Upload)]
        public HttpPostedFileBase FileUpload { get; set; }

        public string RedirectAction { get; set; }

        public string RedirectController { get; set; }

        public ArtifactViewModel() { }

        public ArtifactViewModel(Artifact model)
        {
            ArtifactId = model.ArtifactId;
            ArtifactTypeId = model.ArtifactTypeId;
            Mime = model.Mime;
            OriginalFilename = model.OriginalFilename;
            Location = model.Location;
            Title = model.Title;
            ArtifactScopeTypeId = model.ArtifactScopeTypeId;
            ArtifactScopeId = model.ArtifactScopeId;
            ArtifactScopeType = SelectionConverter.Convert(model.ArtifactScopeTypeId);
            ArtifactType = SelectionConverter.Convert(model.ArtifactTypeId);

            Tds = model.Tds;
            UploadedOn = model.Tds.ToShortDateString();
        }


        public override bool IsValid()
        {
            return true;
        }

        public override Artifact ToModel()
        {
            Artifact model = new Artifact();

            model.ArtifactId = ArtifactId;
            model.ArtifactTypeId = ArtifactTypeId;
            model.Mime = Mime;
            model.OriginalFilename = OriginalFilename;
            model.Location = Location;
            model.Title = Title;
            model.ArtifactScopeTypeId = ArtifactScopeTypeId;
            model.ArtifactScopeId = ArtifactScopeId;
            return model;
        }
    }
}
