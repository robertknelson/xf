using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyclops.Web
{
    public class AppViewModel : ViewModel<App>
    {
        #region properties

        [ScaffoldColumn(false)]
        public int AppId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "App Type")]
        public string AppType { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        public int AppTypeId { get; set; }

        #endregion properties

        public AppViewModel() { }

        public AppViewModel(App model)
        {
            AppId = model.AppId;
            Name = model.Name;
            AppTypeId = model.AppTypeId;
            AppType = SelectionConverter.Convert(model.AppTypeId);
            Alias = model.Alias;
            Description = model.Description;
            Tags = model.Tags;

        }


        public override bool IsValid()
        {
            return true;
        }


        public override App ToModel()
        {
            App model = new App();
            model.Alias = Alias;
            model.AppId = AppId;
            model.AppTypeId = AppTypeId;// SelectionConverter.ConvertToId(AppType);
            model.Description = Description;
            model.Name = Name;
            model.Tags = Tags;
            return model;
        }

    }
}
