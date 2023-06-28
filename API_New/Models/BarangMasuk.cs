using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_tr_barang_masuk")]
    public class BarangMasuk
    {
        [Key, Column("id_barang_masuk")]
        public int Id { get; set; }

        [Column("tanggal_masuk", TypeName = "datetime")]
        public DateTime TanggalMasuk { get; set; }

        [Column("kd_barang", TypeName = "varchar(10)")]
        public string KodeBarang { get; set; }

        [Column("jumlah")]
        public int Jumlah { get; set; }

        [Column("id_supplier")]
        public int IdSuppllier { get; set; }

        [Column("user_nip", TypeName = "char(8)")]
        public string UserNIP { get; set; }


        //Cardinality
        [JsonIgnore]
        public Supplier? Supplier { get; set; }
        [JsonIgnore]
        public Barang? Barang { get; set; }
        [JsonIgnore]
        public Users? Users { get; set; }

    }
}
