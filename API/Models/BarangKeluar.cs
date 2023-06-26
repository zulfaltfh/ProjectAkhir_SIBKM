using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("tb_tr_barang_keluar")]
    public class BarangKeluar
    {
        [Key, Column("id_barang_keluar")]
        public int Id { get; set; }

        [Column("tanggal_keluar", TypeName = "datetime")]
        public DateTime TanggalKeluar { get; set; }

        [Column("nama_pembeli", TypeName ="varchar(50)")]
        public string Pembeli { get; set; }

        //Cardinality
        [JsonIgnore]
        public ICollection<DetailBarkeluar>? DetailBarkeluar { get; set; }
    }
}
