namespace AssetManagement.Domain.Models
{
    #nullable disable
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
