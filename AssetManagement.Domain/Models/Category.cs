using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Domain.Models
{
    #nullable disable
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Category Prefix")]
        public string Prefix { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
