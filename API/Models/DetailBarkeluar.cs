using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("tb_tr_detail_barang_keluar")]
    public class DetailBarkeluar
    {
        [Key, Column("id_detail_keluar")]
        public int Id { get; set; }

        [Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("id_keluar")]
        public int IdKeluar { get; set; }

        [Column("jumlah")]
        public int JumlahKeluar { get; set; }

        //Cardinality
        [JsonIgnore]
        public BarangKeluar? BarangKeluar { get; set; }
        [JsonIgnore]
        public Barang? Barang { get; set; }
    }
}
