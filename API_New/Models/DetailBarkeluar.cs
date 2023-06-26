using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_tr_detail_barang_keluar")]
    public class DetailBarkeluar
    {
        [Key, Column("id_keluar")]
        public int IdKeluar { get; set; }

        [Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("nip_employee", TypeName = "char(8)")]
        public string UserNIP { get; set; }

        [Column("jumlah")]
        public int JumlahKeluar { get; set; }

        //Cardinality
        [JsonIgnore]
        public BarangKeluar? BarangKeluar { get; set; }
        [JsonIgnore]
        public Barang? Barang { get; set; }
        [JsonIgnore]
        public Users? Users { get; set; }
    }
}
