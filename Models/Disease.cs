using SQLite;

namespace MedicalHerbs.Models
{
    [Table("Diseases")]
    public class Disease
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }

    }


}

