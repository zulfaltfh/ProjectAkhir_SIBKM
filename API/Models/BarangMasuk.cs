using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("tb_tr_barang_masuk")]
    public class BarangMasuk
    {
        [Key, Column("id_barang_masuk")]
        public int Id { get; set; }

        [Column("tanggal_masuk", TypeName = "datetime")]
        public DateTime TanggalMasuk { get; set; }

        [Column("id_supplier")]
        public int IdSuppllier { get; set; }


        //Cardinality
        [JsonIgnore]
        public ICollection<DetailBarMasuk> DetailBarMasuk { get; set; }
        [JsonIgnore]
        public Supplier? Supplier { get; set; }

    }
}
