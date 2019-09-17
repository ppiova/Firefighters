using System.ComponentModel.DataAnnotations;

namespace Firefighters.Web.Data.Entities
{
    public class ElementoImage
    {
        public int ElementoImageId { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            //: $"https://myleasing.azurewebsites.net{ImageUrl.Substring(1)}";
              : $"https://localhost:5001{ImageUrl.Substring(1)}";

        public Elemento Elemento { get; set; }
    }
}
