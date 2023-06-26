using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections;

namespace API.Models
{
    public class Roles
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<UsersRole> UsersRole { get; set; }
    }
}
