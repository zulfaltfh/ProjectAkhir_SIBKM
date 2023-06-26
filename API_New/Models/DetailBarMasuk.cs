using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_tr_detail_barang_masuk")]
    public class DetailBarMasuk
    {
        [Key, Column("id_masuk")]
        public int IdMasuk { get; set; }

        [Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("nip_employee", TypeName = "char(8)")]
        public string UserNIP { get; set; }

        [Column("jumlah")]
        public int JumlahMasuk { get; set; }

        //Cardinality
        [JsonIgnore]
        public BarangMasuk? BarangMasuk { get; set; }
        [JsonIgnore]
        public Barang? Barang { get; set; }
        [JsonIgnore]
        public Users? Users { get; set; }
    }
}
