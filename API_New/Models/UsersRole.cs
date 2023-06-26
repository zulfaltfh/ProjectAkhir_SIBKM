using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API_New.Models
{
    public class UsersRole
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("user_nip", TypeName = "char(8)")]
        public string UserNIP { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        //Cardinality
        [JsonIgnore]
        public Users Users { get; set; }

        [JsonIgnore]
        public Roles Roles { get; set; }
    }
}
