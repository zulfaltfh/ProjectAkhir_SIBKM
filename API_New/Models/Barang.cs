using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_m_barang")]
    public class Barang
    {
        [Key, Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("nama_barang", TypeName = "varchar(255)")]
        public string NamaBarang { get; set; }

        [Column("jenis_barang", TypeName = "varchar(50)")]
        public string JenisBarang { get; set; }

        [Column("stok_barang")]
        public int Stock { get; set; }


        //Cardinality
        [JsonIgnore]
        public ICollection<DetailBarMasuk>? DetailBarMasuk { get; set; }
        [JsonIgnore]
        public ICollection<DetailBarkeluar>? DetailBarkeluar { get; set; }
    }
}
