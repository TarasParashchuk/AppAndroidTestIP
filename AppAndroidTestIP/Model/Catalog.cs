using SQLite;

namespace AppAndroidTestIP.Model
{
    [Table("Catalog")]
    public class Catalog
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}