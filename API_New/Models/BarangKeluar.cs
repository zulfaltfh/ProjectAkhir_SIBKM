using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_tr_barang_keluar")]
    public class BarangKeluar
    {
        [Key, Column("id_barang_keluar")]
        public int Id { get; set; }

        [Column("tanggal_keluar", TypeName = "datetime")]
        public DateTime TanggalKeluar { get; set; }

        [Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("jumlah")]
        public int Jumlah { get; set; }

        [Column("nama_pembeli", TypeName ="varchar(50)")]
        public string Pembeli { get; set; }

        [Column("user_nip", TypeName = "char(8)")]
        public string UserNIP { get; set; }

        //Cardinality
        [JsonIgnore]
        public Barang? Barang { get; set; }
        [JsonIgnore]
        public Users? Users { get; set; }
    }
}
