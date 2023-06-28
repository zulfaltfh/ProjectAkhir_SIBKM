using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_New.Models
{
    [Table("tb_m_users")]
    public class Users
    {
        [Key, Column("nip", TypeName = "char(8)")]
        public string UserNIP { get; set; }

        [Column("username", TypeName = "varchar(255)")]
        public string Username { get; set; }

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column("full_name", TypeName = "varchar(50)")]
        public string FullName { get; set; }

        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column("no_telepon", TypeName = "varchar(50)")]
        public string PhoneNumber { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<UsersRole>? UsersRole { get; set; }
        [JsonIgnore]
        public ICollection<BarangKeluar>? BarangKeluar { get; set; }
        [JsonIgnore]
        public ICollection<BarangMasuk>? BarangMasuk { get; set; }
    }
}
