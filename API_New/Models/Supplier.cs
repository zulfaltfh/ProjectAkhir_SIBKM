using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_m_supplier")]
    public class Supplier
    {
        [Key, Column("id_supplier")]
        public int Id { get; set; }

        [Column("nama_supplier", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("no_telp", TypeName ="varchar(12)")]
        public string NoTelp { get; set; }

        //Cardinality
        [JsonIgnore]
        public ICollection<BarangMasuk>? BarangMasuk { get; set; }
    }
}
